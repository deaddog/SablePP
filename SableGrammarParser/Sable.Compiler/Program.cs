using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Sable.Compiler.lexer;
using Sable.Compiler.node;
using Sable.Compiler.parser;

using Sable.Compiler.Generate;
using Sable.Compiler.Generate.Analysis;
using Sable.Compiler.Generate.Productions;
using Sable.Compiler.Generate.Tokens;
using Sable.Tools.Generate;

namespace Sable.Compiler
{
    class Program
    {
        private static string inputFile = @"..\..\..\..\grammar.sablecc";

        private static void Main(string[] args)
        {
            Start ast = Parse(ReadFile(inputFile));

            Error.CompilerError[] errors = Visitor.StartNewVisitor(new Visitor(), ast).GetErrors().ToArray();

            ParserModifier parserMod = new ParserModifier(ast);

            string file = @"..\..\..\..\output\parser.cs";
            string code;

            using (StreamReader reader = new StreamReader(file))
                code = reader.ReadToEnd();

            code = parserMod.ReplaceIn(code);

            using (StreamWriter writer = new StreamWriter(@"..\..\..\..\output\parser2.cs"))
                writer.Write(code);

            using (FileStream fs = new FileStream(@"..\..\..\..\output\tokens2.cs", FileMode.Create))
                CodeStreamWriter.Generate(fs, TokenNodes.BuildCode(ast));
            using (FileStream fs = new FileStream(@"..\..\..\..\output\prods2.cs", FileMode.Create))
                CodeStreamWriter.Generate(fs, ProductionNodes.BuildCode(ast));
            using (FileStream fs = new FileStream(@"..\..\..\..\output\analysis2.cs", FileMode.Create))
                CodeStreamWriter.Generate(fs, AnalysisBuilder.BuildCode(ast));

            if (errors.Length > 0)
            {
                for (int i = 0; i < errors.Length; i++)
                    Console.WriteLine(errors[i]);
                Console.ReadKey(true);
            }
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
            using (StreamReader sr = new StreamReader(File.Open(inputFile, FileMode.Open)))
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