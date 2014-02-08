using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            ValidatePreSable(root, compilationOptions.ErrorManager);

            compilationOptions.Highlight(identifierHighlighter);

            if (compilationOptions.ErrorManager.Count == 0 && runSable)
                ValidateWithSableCC(root, compilationOptions.ErrorManager);
        }

        private void ValidatePreSable(Start<PGrammar> root, ErrorManager errorManager)
        {
            if (root.Root is AGrammar)
            {
                AGrammar grammar = root.Root as AGrammar;
                if (!grammar.HasTokens)
                {
                    string message = "A SablePP grammar must contain a Tokens definition.";
                    if (grammar.HasIgnoredtokens)
                        errorManager.Register((grammar.Ignoredtokens as AIgnoredtokens).Ignoredtoken, message);
                    else if (grammar.HasProductions)
                        errorManager.Register((grammar.Productions as AProductions).Productionstoken, message);
                    else if (grammar.HasAstproductions)
                        errorManager.Register((grammar.Astproductions as AAstproductions).Asttoken, message);
                    else
                        errorManager.Register(message);
                }

                if (!grammar.HasProductions)
                {
                    string message = "A SablePP grammar must contain a Productions definition.";
                    if (grammar.HasAstproductions)
                        errorManager.Register((grammar.Astproductions as AAstproductions).Asttoken, message);
                    else
                        errorManager.Register(message);
                }
            }

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

                errorManager.Register("SableCC: {2} at {{{0},{1}}}", eLine, eChar, eText);
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

            TokenNodes.BuildCode(root).ToFile(Path.Combine(PathInformation.SableOutputDirectory, "tokens.cs"));
            ProductionNodes.BuildCode(root).ToFile(Path.Combine(PathInformation.SableOutputDirectory, "prods.cs"));
            AnalysisBuilder.BuildCode(root).ToFile(Path.Combine(PathInformation.SableOutputDirectory, "analysis.cs"));

            ParserModifier.ApplyToFile(PathInformation.SableOutputDirectory + "\\parser.cs", root);
            LexerModifier.ApplyToFile(PathInformation.SableOutputDirectory + "\\lexer.cs", root);

            CompilerExecuterBuilder.Build(root).ToFile(Path.Combine(PathInformation.SableOutputDirectory, "CompilerExecuter.cs"));

            directory = directory.TrimEnd('\\');

            foreach (var file in new[] { "tokens.cs", "prods.cs", "analysis.cs", "parser.cs", "lexer.cs", "CompilerExecuter.cs" })
                File.Copy(PathInformation.SableOutputDirectory + "\\" + file, directory + "\\" + file, true);

            return true;
        }
    }
}
