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
using SablePP.Compiler.Generate.Productions;
using SablePP.Compiler.Generate.Tokens;
using SablePP.Compiler.Nodes;
using SablePP.Compiler.Validation;

using SablePP.Tools;
using SablePP.Tools.Error;
using SablePP.Tools.Generate;
using SablePP.Tools.Nodes;
using SablePP.Compiler.Generate.Parsing;

namespace SablePP.Compiler
{
    public partial class CompilerExecuter
    {
        private const int SABLE_MAX_WAIT = 500;
        private bool runSable;
        private IdentifierHighlighter identifierHighlighter;

        public bool RunSable
        {
            get { return runSable; }
            set { runSable = value; }
        }

        public CompilerExecuter(bool runSable)
        {
            this.runSable = runSable;
            this.identifierHighlighter = new IdentifierHighlighter();
        }

        public override void Validate(Start<PGrammar> root, CompilationOptions compilationOptions)
        {
            Rebuild(root, compilationOptions.ErrorManager);
            if (compilationOptions.ErrorManager.Errors.Count > 0)
                return;

            ValidatePreSable(root, compilationOptions.ErrorManager);

            compilationOptions.Highlight(identifierHighlighter);

            if (compilationOptions.ErrorManager.Errors.Count == 0 && runSable)
                ValidateWithSableCC(root, compilationOptions.ErrorManager);
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
                var list = new List<PIdentifierListitem>();
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
                var list = new List<PIdentifierListitem>();
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

            var linktest = new Validation.SymbolLinking.DeclarationVisitor(errorManager);
            linktest.Visit(root);

            var syntaxtest = new SyntaxHighlightValidator(errorManager);
            syntaxtest.Visit(root);
        }
        private void ValidateWithSableCC(Start<PGrammar> root, ErrorManager errorManager)
        {
            using (FileStream fss = new FileStream(PathInformation.TemporarySableGrammarPath, FileMode.Create))
            {
                SableGrammarEmitter emitter = new SableGrammarEmitter(fss);
                emitter.Visit(root);
            }

            using (Process proc = StartSableCC())
            {
                if (proc.ExitCode != 0)
                {
                    string[] text = proc.StandardError.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i].StartsWith("\tat "))
                            break;
                        handleSableException(errorManager, text[i]);
                    }
                }
                else
                {
                    string lexerDestination = Path.Combine(PathInformation.SableOutputDirectory, "sablecc_lexer.cs");
                    string parserDestination = Path.Combine(PathInformation.SableOutputDirectory, "sablecc_parser.cs");

                    if (File.Exists(lexerDestination))
                        File.Delete(lexerDestination);
                    File.Move(Path.Combine(PathInformation.SableOutputDirectory, "lexer.cs"), lexerDestination);

                    if (File.Exists(parserDestination))
                        File.Delete(parserDestination);
                    File.Move(Path.Combine(PathInformation.SableOutputDirectory, "parser.cs"), parserDestination);
                }
                proc.Close();
            }
        }
        private Process StartSableCC()
        {
            var processInfo = new ProcessStartInfo(
                PathInformation.JavaExecutable,
                "-jar sablecc.jar -d \"" + PathInformation.SableOutputDirectory + "\" -t csharp \"" + PathInformation.TemporarySableGrammarPath + "\"")
            {
                CreateNoWindow = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                WorkingDirectory = PathInformation.ExecutingDirectory
            };

            int wait = 0;
            Process proc;
            if ((proc = Process.Start(processInfo)) == null)
                throw new ApplicationException("Java not found - visit Java.com to install.");

            while (!proc.WaitForExit(100))
            {
                wait += 100;
                int err = proc.StandardError.Peek();
                if (err > 0 && wait >= SABLE_MAX_WAIT)
                    proc.Kill();
            }

            return proc;
        }
        private void handleSableException(ErrorManager errorManager, string text)
        {
            Match m = Regex.Match(text, "java.lang.RuntimeException: \\[(?<line>[0-9]+),(?<char>[0-9]+)\\] (?<text>.*)");
            if (m.Success)
            {
                int eLine = int.Parse(m.Groups["line"].Value);
                int eChar = int.Parse(m.Groups["char"].Value);
                string eText = m.Groups["text"].Value;

                if (eLine == 0 || eChar == 0)
                    errorManager.Register("SableCC: {2} at {{{0},{1}}}", eLine, eChar, eText);
                else
                {
                    Position start = new Position(eLine, eChar);
                    Position end = new Position(eLine, eChar);
                    errorManager.Register(new CompilerError(ErrorType.Error, start, end, "SableCC: " + eText));
                }
            }
            else
                errorManager.Register(text);
        }

        public bool Generate(Start<PGrammar> root, string directory)
        {
            ErrorManager manager = new ErrorManager();
            if (!runSable)
                ValidateWithSableCC(root, manager);

            if (manager.Count > 0)
                return false;

            string output = PathInformation.SableOutputDirectory;

            TokenNodes.BuildCode(root).ToFile(Path.Combine(output, "tokens.cs"));
            ProductionNodes.BuildCode(root).ToFile(Path.Combine(output, "prods.cs"));
            AnalysisBuilder.BuildCode(root).ToFile(Path.Combine(output, "analysis.cs"));

            LexerBuilder.BuildCode(Path.Combine(output, "sablecc_lexer.cs"), root).ToFile(Path.Combine(output, "lexer.cs"));
            ParserBuilder.BuildCode(Path.Combine(output, "sablecc_parser.cs"), root).ToFile(Path.Combine(output, "parser.cs"));

            CompilerExecuterBuilder.Build(root).ToFile(Path.Combine(output, "CompilerExecuter.cs"));

            directory = directory.TrimEnd('\\');

            foreach (var file in new[] { "tokens.cs", "prods.cs", "analysis.cs", "parser.cs", "lexer.cs", "CompilerExecuter.cs" })
                File.Copy(Path.Combine(output, file), Path.Combine(directory, file), true);

            return true;
        }
    }
}
