using System;
using System.IO;
using SableGrammarParser.lexer;
using SableGrammarParser.node;
using SableGrammarParser.parser;

namespace AST
{
    class Program
    {
        private static string inputFile = "test";

        private static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(File.Open(inputFile, FileMode.Open)))
            {
                Token t;
                Lexer lexer = new Lexer(sr);
                try
                {
                    while (!((t = lexer.Next()) is EOF))
                        Console.WriteLine("{0}: {1}", t.GetType().Name, t.Text);
                }
                catch (LexerException ex)
                {
                    exit(ex.ToString());
                }
            }

            using (StreamReader sr = new StreamReader(File.Open(inputFile, FileMode.Open)))
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
                Console.BufferHeight += 600;
                SimplePrinter printer = new SimplePrinter(false, ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.Red, ConsoleColor.Blue);
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