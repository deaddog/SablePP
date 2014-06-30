using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate;
using SablePP.Tools.Generate.CSharp;
using SablePP.Tools.Nodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Generate.Parsing
{
    public class ParserBuilder : GenerateVisitor
    {
        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private ClassElement classElement;

        private ParserBuilder()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
        }

        public static FileElement BuildCode(string originalFile, Start<PGrammar> astRoot)
        {
            string code;
            using (StreamReader reader = new StreamReader(originalFile))
                code = reader.ReadToEnd();

            ParserBuilder n = new ParserBuilder();
            n.Visit(astRoot);

            return n.fileElement;
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            string packageName = node.PackageName;

            fileElement.Add(nameElement = new NameSpaceElement(packageName + ".Parsing"));
            fileElement.Using.Add(packageName + ".Nodes");

            nameElement.Add(classElement = new ClassElement("public class Parser : {0}.Parser<{1}>", ToolsNamespace.Parsing, node.RootProduction));
        }
    }
}
