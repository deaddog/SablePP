using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using Sable.Compiler.Nodes;
using Sable.Tools.Error;
using Sable.Tools.Nodes;

namespace Sable.Compiler
{
    public partial class CompilerExecuter
    {
        partial void PerformValidation(Start<PGrammar> root, ErrorManager errorManager)
        {
            var linktest = new SymbolLinking.DeclarationVisitor(errorManager);
            linktest.Visit(root);

            if (errorManager.Count == 0)
                ValidateWithSableCC(root, errorManager);
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
    }
}
