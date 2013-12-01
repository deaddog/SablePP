using SablePP.Compiler.Lexing;
using SablePP.Compiler.Nodes;
using SablePP.Compiler.Parsing;
using SablePP.Tools.Nodes;
using System;
using System.IO;

namespace SablePP.Compiler.Execution
{
    public class ConsoleCompiler : CompilerBase
    {
        protected override void Main()
        {
            throw new NotImplementedException();
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
