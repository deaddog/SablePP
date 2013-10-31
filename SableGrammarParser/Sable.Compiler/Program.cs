using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Sable.Compiler.Lexing;
using Sable.Compiler.Nodes;
using Sable.Compiler.Parsing;

using Sable.Compiler.Generate;
using Sable.Compiler.Generate.Analysis;
using Sable.Compiler.Generate.Productions;
using Sable.Compiler.Generate.Tokens;
using Sable.Tools.Generate;

using System.Diagnostics;

namespace Sable.Compiler
{
    class Program
    {
        private static ArgumentCollection arguments;

        private static void Main(string[] args)
        {
            arguments = new ArgumentCollection(args);

            string inputGrammar = arguments["grammar"][0];
            File.Copy(inputGrammar, PathInformation.TemporaryGrammarPath, true);

            string outputDirectory = arguments["out"][0];
            outputDirectory = outputDirectory.TrimEnd('\\');

            Console.WriteLine("Loading grammar file \"{0}\".", PathInformation.TemporaryGrammarPath);
            Console.WriteLine();

            Console.WriteLine("Validating grammar.");
            Start ast = Parse(ReadFile(PathInformation.TemporaryGrammarPath));
            Error.CompilerError[] errors = Visitor.StartNewVisitor(new Visitor(), ast).GetErrors().ToArray();
            if (errors.Length > 0)
            {
                Console.WriteLine("Validation failed:");

                for (int i = 0; i < errors.Length; i++)
                    Console.WriteLine(errors[i]);
#if DEBUG
                Console.ReadKey(true);
#endif
                return;
            }
            Console.WriteLine("Validation completed.\n");

            var processInfo = new ProcessStartInfo(PathInformation.JavaExecutable, "-jar sablecc.jar -d \"" + PathInformation.SableOutputDirectory + "\" -t csharp \"" + PathInformation.TemporaryGrammarPath + "\"")
            {
                CreateNoWindow = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                WorkingDirectory = PathInformation.ExecutingDirectory
            };

            Console.WriteLine("Verifying Java.");
            Process proc;
            if ((proc = Process.Start(processInfo)) == null)
            {
                Console.WriteLine("Java not found - visit Java.com to install.");
#if DEBUG
                Console.ReadKey(true);
#endif
                return;
            }
            Console.WriteLine("Java {0} found.\n\nRunning SableCC", PathInformation.JavaVersion);
            proc.WaitForExit();
            int exitCode = proc.ExitCode;
            if (exitCode != 0)
            {
                Console.WriteLine("SableCC failed to compile, see error-message below:");
                string[] text = proc.StandardError.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                proc.Close();
                int to = int.MaxValue;
                for (int i = 0; i < text.Length; i++)
                    if (text[i].StartsWith("\tat "))
                    {
                        to = i;
                        break;
                    }
                Console.WriteLine("----- SABLE-ERROR-BEGIN -----");
                for (int i = 0; i < to; i++)
                    Console.WriteLine(text[i]);
                Console.WriteLine("-----  SABLE-ERROR-END  -----");
#if DEBUG
                Console.ReadKey(true);
#endif
                return;
            }
            proc.Close();
            Console.WriteLine("SableCC completed successfully.\n");

            Console.WriteLine("Starting Post-Sable Process.");
            Console.WriteLine("Generating token definitions.");
            using (FileStream fs = new FileStream(PathInformation.SableOutputDirectory + "\\tokens.cs", FileMode.Create))
                CodeStreamWriter.Generate(fs, TokenNodes.BuildCode(ast));

            Console.WriteLine("Generating production definitions.");
            using (FileStream fs = new FileStream(PathInformation.SableOutputDirectory + "\\prods.cs", FileMode.Create))
                CodeStreamWriter.Generate(fs, ProductionNodes.BuildCode(ast));

            Console.WriteLine("Generating analysis.");
            using (FileStream fs = new FileStream(PathInformation.SableOutputDirectory + "\\analysis.cs", FileMode.Create))
                CodeStreamWriter.Generate(fs, AnalysisBuilder.BuildCode(ast));

            Console.WriteLine("Rewriting parser.");
            ParserModifier.ApplyToFile(PathInformation.SableOutputDirectory + "\\parser.cs", ast);
            Console.WriteLine("Rewriting lexer.");
            LexerModifier.ApplyToFile(PathInformation.SableOutputDirectory + "\\lexer.cs", ast);

            foreach (var file in new[] { "tokens.cs", "prods.cs", "analysis.cs", "parser.cs", "lexer.cs" })
                File.Copy(PathInformation.SableOutputDirectory + "\\" + file, outputDirectory + "\\" + file, true);

            Console.WriteLine("Done.");
#if DEBUG
            Console.ReadKey(true);
#endif
        }

        private class Visitor : Error.ErrorVisitor
        {
            public override void CaseStart(Start node)
            {
                foreach (var v in Visitors)
                {
                    StartVisitor(v, node);
                    if (GetErrors().Any())
                        break;
                }
            }

            private IEnumerable<Error.ErrorVisitor> Visitors
            {
                get
                {
                    yield return new SymbolLinking.DeclarationVisitor();
                }
            }
        }

        private static string ReadFile(string filepath)
        {
            string result;
            using (StreamReader sr = new StreamReader(File.Open(filepath, FileMode.Open)))
                result = sr.ReadToEnd();
            return result;
        }
        private static Start Parse(string code)
        {
            StringReader reader = new StringReader(code);

            Lexer lexer = new Lexer(reader);
            Parser parser = new Parser(lexer);

            Start ast = parser.Parse();

            reader.Dispose();
            return ast;
        }
    }

    public class ArgumentCollection
    {
        private Dictionary<string, string[]> dict;
        private static readonly string[] emptyArray = new string[0];

        public ArgumentCollection(string[] args)
        {
            Dictionary<string, List<string>> builder = new Dictionary<string, List<string>>();
            builder.Add(string.Empty, new List<string>());

            string currentarg = string.Empty;

            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                if (arg.StartsWith("-"))
                {
                    currentarg = arg.Substring(1);
                    if (!builder.ContainsKey(currentarg))
                        builder.Add(currentarg, new List<string>());
                }
                else
                {
                    builder[currentarg].Add(arg);
                }
            }

            dict = new Dictionary<string, string[]>();
            foreach (string s in builder.Keys)
                dict.Add(s, builder[s].ToArray());
        }

        public string[] this[string argument]
        {
            get
            {
                if (argument == null)
                    return NoArgument;
                else if (dict.ContainsKey(argument))
                    return dict[argument];
                else
                    return emptyArray;
            }
        }

        public string[] NoArgument
        {
            get { return dict[string.Empty]; }
        }
    }
}