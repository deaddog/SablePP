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

using Sable.Tools.Editor;
using Sable.Tools.Error;
using Sable.Tools.Generate;
using Sable.Tools.Nodes;

using System.Diagnostics;
using System.Windows.Forms;

namespace Sable.Compiler
{
    class Program
    {
        private static ArgumentCollection arguments;

#if WINFORMS
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CompilerExecuter executer = new CompilerExecuter(false);

            EditorForm edit = new EditorForm()
            {
                Executer = executer,
                Text = "SPP Editor",
                FileExtension = "sablecc"
            };

            Application.Run(edit);
        }
#else
        private static void Main(string[] args)
        {
            arguments = new ArgumentCollection(args);

            string inputGrammar = arguments["grammar"][0];
            File.Copy(inputGrammar, PathInformation.TemporaryGrammarPath, true);

            string outputDirectory = arguments["out"][0];
            outputDirectory = outputDirectory.TrimEnd('\\');

            CompilerExecuter executer = new CompilerExecuter(true);

            Console.WriteLine("Input:\n" + inputGrammar + "\n\nValidating grammar.");
            Start<PGrammar> ast = Parse(ReadFile(PathInformation.TemporaryGrammarPath), executer);

            ErrorManager errorManager = new ErrorManager();
            executer.Validate(ast, errorManager);

            if (errorManager.Count > 0)
            {
                Console.WriteLine("Validation failed:");
                foreach(var err in errorManager)
                    Console.WriteLine(err);
#if DEBUG
                Console.ReadKey(true);
#endif
                return;
            }
            else
                Console.WriteLine("Validated.\n");

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

            Console.WriteLine("Generating CompilerExecuter.");
            using (FileStream fs = new FileStream(PathInformation.SableOutputDirectory + "\\CompilerExecuter.cs", FileMode.Create))
                CodeStreamWriter.Generate(fs, CompilerExecuterBuilder.Build(ast));

            foreach (var file in new[] { "tokens.cs", "prods.cs", "analysis.cs", "parser.cs", "lexer.cs", "CompilerExecuter.cs" })
                File.Copy(PathInformation.SableOutputDirectory + "\\" + file, outputDirectory + "\\" + file, true);

            Console.WriteLine("Done.");
#if DEBUG
            Console.ReadKey(true);
#endif
        }

        private static string ReadFile(string filepath)
        {
            string result;
            using (StreamReader sr = new StreamReader(File.Open(filepath, FileMode.Open)))
                result = sr.ReadToEnd();
            return result;
        }
        private static Start<PGrammar> Parse(string code, CompilerExecuter executer)
        {
            StringReader reader = new StringReader(code);

            Lexer lexer = executer.GetLexer(reader);
            Parser parser = executer.GetParser(lexer);

            Start<PGrammar> ast = parser.Parse();

            reader.Dispose();
            return ast;
        }
#endif
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