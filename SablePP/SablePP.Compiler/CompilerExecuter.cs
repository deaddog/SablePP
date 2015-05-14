using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using SablePP.Compiler.Execution;
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
            {
                var packages = sections<APackageSection>(root);
                for (int i = 1; i < packages.Length; i++)
                    compilationOptions.ErrorManager.Register(packages[i], "A SablePP grammar cannot contain multiple Package/Namespace sections.");
            }

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
