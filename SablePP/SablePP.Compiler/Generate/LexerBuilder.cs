using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate.CSharp;
using SablePP.Tools.Nodes;
using System.IO;

namespace SablePP.Compiler.Generate
{
    public class LexerBuilder : GenerateVisitor
    {
        private FileElement fileElement;

        private LexerBuilder()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
        }

        public static FileElement BuildCode(string originalFile, Start<PGrammar> astRoot)
        {
            string code;
            using (StreamReader reader = new StreamReader(originalFile))
                code = reader.ReadToEnd();

            LexerBuilder n = new LexerBuilder();
            n.Visit(astRoot);

            return n.fileElement;
        }
    }
}
