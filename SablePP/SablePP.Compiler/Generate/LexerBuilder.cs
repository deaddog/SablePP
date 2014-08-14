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
        private Dictionary<string, int> states;
        private int tokenIndex = 0;

        private PatchElement getTokenMethod, getNextStateMethod;

        private LexerBuilder(PatchElement gotoElement, PatchElement acceptElement)
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");

            this.gotoElement = gotoElement;
            this.acceptElement = acceptElement;

            this.states = new Dictionary<string, int>();
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            string packageName = node.PackageName;

            fileElement.Add(nameElement = new NameSpaceElement(packageName + ".Lexing"));
            fileElement.Using.Add(packageName + ".Nodes");

            nameElement.Add(classElement = new ClassElement("public class Lexer : {0}.Lexer", ToolsNamespace.Lexing));

            if (node.HasStates)
                Visit(node.States);

            if (node.HasStates)
                classElement.EmitNewline();

            string initialState = node.HasStates ? states.Keys.Where(s => states[s] == 0).First() : "0";
            classElement.Add(new MethodElement(
                "public Lexer(System.IO.TextReader input)",
                "base(input, " + initialState + ", gotoTable, acceptTable)", true));

            classElement.EmitNewline();
            classElement.Add(emitGetToken());
            if (node.HasStates)
                classElement.Add(emitGetNextState());

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

        private MethodElement emitGetToken()
        {
            var method = new MethodElement("protected override SablePP.Tools.Nodes.Token getToken(int tokenIndex, string text, int line, int position)");

            method.Body.EmitLine("switch (tokenIndex)");
            method.Body.EmitLine("{");
            method.Body.IncreaseIndentation();

            method.Body.InsertElement(getTokenMethod = new PatchElement());
            method.Body.EmitLine("default:");
            method.Body.IncreaseIndentation();
            method.Body.EmitLine("throw new ArgumentException(\"Unknown token index.\", \"tokenIndex\");");
            method.Body.DecreaseIndentation();

            method.Body.DecreaseIndentation();
            method.Body.EmitLine("}");

            return method;
        }
        private MethodElement emitGetNextState()
        {
            var method = new MethodElement("protected override int getNextState(int tokenIndex, int currentState)");

            method.Body.EmitLine("switch (tokenIndex)");
            method.Body.EmitLine("{");
            method.Body.IncreaseIndentation();

            method.Body.InsertElement(getNextStateMethod = new PatchElement());
            method.Body.EmitLine("default: return -1;");

            method.Body.DecreaseIndentation();
            method.Body.EmitLine("}");

            return method;
        }

        public override void CaseAToken(AToken node)
        {
            getTokenMethod.EmitLine("case {1}: return new {0}(text, line, position);", node.ClassName, tokenIndex);

            if(node.Statelist.Any(item=>item is ATransitionTokenState))
            {
                getNextStateMethod.EmitLine("case {0}:", tokenIndex);
                getNextStateMethod.IncreaseIndentation();
                getNextStateMethod.EmitLine("switch (currentState)");
                getNextStateMethod.EmitLine("{");
                getNextStateMethod.IncreaseIndentation();

                Visit(node.Statelist);

                getNextStateMethod.EmitLine("default: return -1;");
                getNextStateMethod.DecreaseIndentation();
                getNextStateMethod.EmitLine("}");
                getNextStateMethod.DecreaseIndentation();
            }

            tokenIndex++;
        }

        public override void CaseATokenState(ATokenState node)
        {
        }
        public override void CaseATransitionTokenState(ATransitionTokenState node)
        {
            getNextStateMethod.EmitLine("case {0}: return {1};", node.From.AsState.LexerName, node.To.AsState.LexerName);
        }

        public override void CaseAStates(AStates node)
        {
            int index = 0;
            foreach (var state in node.States)
            {
                states.Add(state.LexerName, index);
                classElement.EmitField("private const int " + state.LexerName, index.ToString());

                index++;
            }
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
