using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate;
using SablePP.Tools.Generate.CSharp;
using SablePP.Tools.Nodes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SablePP.Compiler.Generate
{
    public class LexerBuilder : GenerateVisitor
    {
        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private ClassElement classElement;

        private PatchElement gotoElement, acceptElement;

        private LexerBuilder(PatchElement gotoElement, PatchElement acceptElement)
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");

            this.gotoElement = gotoElement;
            this.acceptElement = acceptElement;
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            string packageName = node.PackageName;

            fileElement.Add(nameElement = new NameSpaceElement(packageName + ".Lexing"));
            fileElement.Using.Add(packageName + ".Analysis");

            nameElement.Add(classElement = new ClassElement("public class Lexer : {0}.Lexer", ToolsNamespace.Lexing));

            if (node.HasStates)
                Visit(node.States);

            if (node.HasTokens)
                Visit(node.Tokens);

            classElement.EmitNewline();
            classElement.EmitRegionStart("Goto Table");
            classElement.EmitNewline();
            classElement.EmitField("private static int[][][][] gotoTable", gotoElement);
            classElement.EmitNewline();
            classElement.EmitRegionEnd();

            classElement.EmitNewline();
            classElement.EmitRegionStart("Accept Table");
            classElement.EmitNewline();
            classElement.EmitField("private static int[][] acceptTable", acceptElement);
            classElement.EmitNewline();
            classElement.EmitRegionEnd();
        }

        public static FileElement BuildCode(string originalFile, Start<PGrammar> astRoot)
        {
            string code;
            using (StreamReader reader = new StreamReader(originalFile))
                code = reader.ReadToEnd();

            PatchElement gotoElement = new PatchElement(), acceptElement = new PatchElement();

            getGotoTable(code, gotoElement);
            getAcceptTable(code, acceptElement);

            LexerBuilder n = new LexerBuilder(gotoElement, acceptElement);
            n.Visit(astRoot);

            return n.fileElement;
        }

        private static void getGotoTable(string lexerCode, PatchElement element)
        {
            getTable(Regex.Match(lexerCode, @"int\[\]\[\]\[\]\[\] gotoTable[^{]+(?<table>{[^;]*);").Groups["table"].Value, element);
        }
        private static void getAcceptTable(string lexerCode, PatchElement element)
        {
            getTable(Regex.Match(lexerCode, @"int\[\]\[\] accept[^{]+(?<table>{[^;]*);").Groups["table"].Value, element);
        }

        private static void getTable(string code, PatchElement element)
        {
            string[] strings = getNonEmpty(code.Split(new char[] { '\r', '\n' })).ToArray();

            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].StartsWith("}"))
                    element.DecreaseIndentation();

                element.Emit(strings[i]);
                if (i < strings.Length - 1)
                    element.EmitNewLine();

                if (strings[i].EndsWith("{"))
                    element.IncreaseIndentation();
            }
        }

        private static IEnumerable<string> getNonEmpty(IEnumerable<string> collection)
        {
            foreach (var s in collection)
            {
                var t = s.Trim();
                if (t.Length > 0)
                    yield return t;
            }
        }
    }
}
