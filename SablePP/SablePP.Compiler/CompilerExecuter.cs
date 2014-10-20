using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using SablePP.Compiler.Execution;
using SablePP.Compiler.Generate;
using SablePP.Compiler.Generate.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Compiler.Validation;
using SablePP.Compiler.Validation.SymbolLinking;

using SablePP.Tools;
using SablePP.Tools.Error;
using SablePP.Tools.Generate;
using SablePP.Tools.Nodes;

namespace SablePP.Compiler
{
    public partial class CompilerExecuter
    {
        private const int SABLE_MAX_WAIT = 500;
        private IdentifierHighlighter identifierHighlighter;

        private SablePP.Generate.Grammar lastGrammar;
        private SablePP.Generate.CompilationResult lastResult;

        public CompilerExecuter()
        {
            this.identifierHighlighter = new IdentifierHighlighter();
            this.lastGrammar = null;
            this.lastResult = null;
        }

        public override void Validate(Start<PGrammar> root, CompilationOptions compilationOptions)
        {
            Rebuild(root, compilationOptions.ErrorManager);
            if (compilationOptions.ErrorManager.Errors.Count > 0)
                return;

            ValidatePreSable(root, compilationOptions.ErrorManager);

            compilationOptions.Highlight(identifierHighlighter);

            if (compilationOptions.ErrorManager.Errors.Count == 0)
            {
                this.lastGrammar = GrammarBuilder.BuildSableCCGrammar(root);
                this.lastResult = lastGrammar.Compile();

                if (lastResult.Error != null)
                    compilationOptions.ErrorManager.Register(ErrorType.Error, "Failed to compile grammar, see details below:\r\n{0}", lastResult.Error.Message);
            }
            else
            {
                this.lastGrammar = null;
                this.lastResult = null;
            }
        }

        private void Rebuild(Start<PGrammar> root, ErrorManager errorManager)
        {
            AGrammar grammar = new AGrammar(null, null, null, null, null, null, null, null);

            { // Packages
                var packages = sections<APackageSection>(root);
                for (int i = 1; i < packages.Length; i++)
                    errorManager.Register(packages[i].Package, "A SablePP grammar cannot contain multiple Package/Namespace sections.");

                if (packages.Length > 0)
                    grammar.Package = packages[0].Package;
            }

            { // Helpers
                var helpers = sections<AHelpersSection>(root);
                var list = new List<PHelper>();
                for (int i = 0; i < helpers.Length; i++)
                    list.AddRange(helpers[i].Helpers.Helpers);

                if (helpers.Length > 0)
                    grammar.Helpers = new AHelpers(new THelperstoken("Helpers"), list);
            }

            { // States
                var states = sections<AStatesSection>(root);
                var list = new List<PState>();
                for (int i = 0; i < states.Length; i++)
                    list.AddRange(states[i].States.States);

                if (states.Length > 0)
                    grammar.States = new AStates(new TStatestoken("States"), list, new TSemicolon(";"));
            }

            { // Tokens
                var tokens = sections<ATokensSection>(root);
                var list = new List<PToken>();
                for (int i = 0; i < tokens.Length; i++)
                    list.AddRange(tokens[i].Tokens.Tokens);

                if (tokens.Length > 0)
                    grammar.Tokens = new ATokens(new TTokenstoken("Tokens"), list);
            }

            { // Ignored
                var ignored = sections<AIgnoreSection>(root);
                var list = new List<TIdentifier>();
                for (int i = 0; i < ignored.Length; i++)
                    list.AddRange(ignored[i].Ignoredtokens.Tokens);

                if (ignored.Length > 0)
                    grammar.Ignoredtokens = new AIgnoredtokens(new TIgnoredtoken("Ignored"), new TTokenstoken("Tokens"), list, new TSemicolon(";"));
            }

            { // Productions
                var productions = sections<AProductionsSection>(root);
                var list = new List<PProduction>();
                for (int i = 0; i < productions.Length; i++)
                    list.AddRange(productions[i].Productions.Productions);

                if (productions.Length > 0)
                    grammar.Productions = new AProductions(new TProductionstoken("Productions"), list);
            }

            { // AST Productions
                var astproductions = sections<AASTSection>(root);
                var list = new List<PProduction>();
                for (int i = 0; i < astproductions.Length; i++)
                    list.AddRange(astproductions[i].Astproductions.Productions);

                if (astproductions.Length > 0)
                    grammar.Astproductions = new AAstproductions(new TAsttoken("Abstract Syntax Tree"), list);
            }

            { // Highlight rules
                var highlight = sections<AHighlightSection>(root);
                var list = new List<PHighlightrule>();
                for (int i = 0; i < highlight.Length; i++)
                    list.AddRange(highlight[i].Highlightrules.Highlightrules);

                if (highlight.Length > 0)
                    grammar.Highlightrules = new AHighlightrules(new THighlighttoken("Token Syntax Highlight"), list);
            }

            root.Root = grammar;
        }

        private TSection[] sections<TSection>(Start<PGrammar> node) where TSection : PSection
        {
            return (from s in (node.Root as ASectionGrammar).Sections where s is TSection select s as TSection).ToArray();
        }

        private void ValidatePreSable(Start<PGrammar> root, ErrorManager errorManager)
        {
            if (!root.Root.HasPackage)
                errorManager.Register(ErrorType.Message, "When a SablePP does not have a Namespace definition, code is generated in the {0} namespace.", PGrammar.DefaultName);

            if (!root.Root.HasTokens)
                errorManager.Register("A SablePP grammar must contain a Tokens definition.");

            if (!root.Root.HasProductions)
                errorManager.Register("A SablePP grammar must contain a Productions definition.");

            new DeclarationVisitor(errorManager).Visit(root);
            new SyntaxHighlightValidator(errorManager).Visit(root);
            if (errorManager.Errors.Count == 0)
                new ExcessiveNodesVisitor(errorManager).Visit(root);
        }

        public bool Generate(Start<PGrammar> root, string directory)
        {
            directory = directory.TrimEnd('\\');

            lastGrammar.GenerateTokens().ToFile(Path.Combine(directory, "tokens.cs"));
            lastGrammar.GenerateProductions().ToFile(Path.Combine(directory, "prods.cs"));
            lastGrammar.GenerateAnalysis().ToFile(Path.Combine(directory, "analysis.cs"));

            lastGrammar.GenerateLexer(lastResult).ToFile(Path.Combine(directory, "lexer.cs"));
            lastGrammar.GenerateParser(lastResult).ToFile(Path.Combine(directory, "parser.cs"));

            lastGrammar.GenerateCompilerExecuter().ToFile(Path.Combine(directory, "CompilerExecuter.cs"));

            return true;
        }
    }
}
