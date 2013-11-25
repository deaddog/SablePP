using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using SablePP.Compiler.Generate;
using SablePP.Compiler.Generate.Analysis;
using SablePP.Compiler.Generate.Productions;
using SablePP.Compiler.Generate.Tokens;
using SablePP.Compiler.Nodes;

using SablePP.Tools.Error;
using SablePP.Tools.Generate;
using SablePP.Tools.Nodes;

namespace SablePP.Compiler
{
    public partial class CompilerExecuter
    {
        private bool runSable;
        public bool RunSable
        {
            get { return runSable; }
            set { runSable = value; }
        }

        public CompilerExecuter(bool runSable)
        {
            this.runSable = runSable;
        }

        partial void PerformValidation(Start<PGrammar> root, ErrorManager errorManager)
        {
            ValidatePreSable(root, errorManager);

            if (errorManager.Count == 0 && runSable)
                ValidateWithSableCC(root, errorManager);
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
                        errorManager.Register(new CompilerError(-1, -1, 0, message));
                }

                if (!grammar.HasProductions)
                {
                    string message = "A SablePP grammar must contain a Productions definition.";
                    if (grammar.HasAstproductions)
                        errorManager.Register((grammar.Astproductions as AAstproductions).Asttoken, message);
                    else
                        errorManager.Register(new CompilerError(-1, -1, 0, message));
                }
            }

            var linktest = new SymbolLinking.DeclarationVisitor(errorManager);
            linktest.Visit(root);
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
                        errorManager.Register(handleSableException(text[i]));
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

            Process proc;
            if ((proc = Process.Start(processInfo)) == null)
                throw new ApplicationException("Java not found - visit Java.com to install.");
            proc.WaitForExit();

            return proc;
        }
        private CompilerError handleSableException(string text)
        {
            Match m = Regex.Match(text, "java.lang.RuntimeException: \\[(?<line>[0-9]+),(?<char>[0-9]+)\\] (?<text>.*)");
            if (m.Success)
            {
                int eLine = int.Parse(m.Groups["line"].Value);
                int eChar = int.Parse(m.Groups["char"].Value);
                string eText = m.Groups["text"].Value;

                return new CompilerError(-1, -1, 1,
                    string.Format("SableCC: {2} at {{{0},{1}}}", eLine, eChar, eText));
            }
            else
                return new CompilerError(-1, -1, 0, text);
        }

        public bool Generate(string input, string directory)
        {
            Start<PGrammar> node;
            using (StringReader reader = new StringReader(input))
            {
                var lexer = GetLexer(reader);
                var parser = GetParser(lexer);

                try { node = parser.Parse(); }
                catch (LexerException e) { node = null; }
                catch (ParserException e) { node = true; }
            }
            if (node != null)
                return Generate(node);
            else
                return false;
        }
        public bool Generate(Start<PGrammar> root)
        {
            ErrorManager manager = new ErrorManager();

            ValidatePreSable(root, manager);
            if (manager.Count > 0)
                return false;

            ValidateWithSableCC(root, manager);
            if (manager.Count > 0)
                return false;

            throw new NotImplementedException();
        }
    }
}
