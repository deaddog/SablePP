using SablePP.Compiler.Lexing;
using SablePP.Compiler.Nodes;
using SablePP.Compiler.Parsing;
using SablePP.Tools.Error;
using SablePP.Tools.Nodes;
using System;
using System.IO;

namespace SablePP.Compiler.Execution
{
    public class ConsoleCompiler : CompilerBase
    {
        protected override void Main()
        {
            string inputGrammar = Arguments["grammar"][0];
            File.Copy(inputGrammar, PathInformation.TemporaryGrammarPath, true);

            string outputDirectory = Arguments["out"][0];
            outputDirectory = outputDirectory.TrimEnd('\\');

            CompilerExecuter executer = new CompilerExecuter(true);

            Console.WriteLine("Input:\n" + inputGrammar + "\n\nValidating grammar.");
            Start<PGrammar> ast = Parse(ReadFile(PathInformation.TemporaryGrammarPath), executer);

            ErrorManager errorManager = new ErrorManager();
            executer.Validate(ast, new SablePP.Tools.CompilationOptions(errorManager, (h) => { }));

            if (errorManager.Count > 0)
            {
                Console.WriteLine("Validation failed:");
                foreach (var err in errorManager)
                    Console.WriteLine(err);
#if DEBUG
                Console.ReadKey(true);
#endif
                return;
            }
            else
                Console.WriteLine("Validated.\n");

            Console.WriteLine("Starting Post-Sable Process.");
            executer.Generate(ast, outputDirectory);

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
    }
}
