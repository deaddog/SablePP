using System;
using System.IO;
using SableGrammarParser.lexer;
using SableGrammarParser.node;
using SableGrammarParser.parser;

namespace AST
{
    class Program
    {
        private static void Main(string[] args)
        {
            /*
            if (args.Length != 1)
                exit("Usage: Simplecalc.exe filename");
            */
            using (StreamReader sr = new StreamReader(File.Open("test", FileMode.Open)))
            {
                // Read source
                Lexer lexer = new Lexer(sr);
                
                // Parse source
                Parser parser = new Parser(lexer);
                Start ast = null;

                try
                {
                    ast = parser.Parse();
                }
                catch (Exception ex)
                {
                    exit(ex.ToString());
                }

                // Print tree
                SimplePrinter printer = new SimplePrinter(true, ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.Red, ConsoleColor.Blue);
                ast.Apply(printer);
            }

            exit("Done");
        }

        private static void exit(string msg)
        {
            if (msg != null)
                Console.WriteLine(msg);
            else
                Console.WriteLine();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }
}