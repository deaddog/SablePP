using System;
using System.IO;
using SableGrammarParser.lexer;
using SableGrammarParser.node;
using SableGrammarParser.parser;

namespace AST
{
    class Program
    {
        private static string inputFile = "..\\..\\..\\..\\sablegrammarparser.sablecc";

        private static void Main(string[] args) 
        {
            string text = ReadFile(inputFile);
        }

        private static string ReadFile(string filepath)
        {
            string result;
            using (StreamReader sr = new StreamReader(File.Open(inputFile, FileMode.Open)))
                result = sr.ReadToEnd();
            return result;
        }

        private static void Lexer(string filepath)
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
                    Exit(ex.ToString());
                }
            }
        }
        private static void Parser(string filepath)
        {
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
                    Exit(ex.ToString());
                }

                // Print tree
                Console.BufferHeight += 600;
                SimplePrinter printer = new SimplePrinter(false, ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.Red, ConsoleColor.Blue);
                ast.Apply(printer);
            }
        }
        private static void Exit(string msg)
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