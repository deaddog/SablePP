using SablePP.Tools;
using SablePP.Tools.Generate;
using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SablePP.Generate.Building
{
    public class Lexer
    {
        private Grammar grammar;
        private CompilationResult tables;

        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private ClassElement classElement;

        private PatchElement getTokenMethod, getNextStateMethod;

        private Dictionary<string, object> objects;
        private Dictionary<object, string> names;
        private SafeNameDictionary<object> safe;

        private Lexer(Grammar grammar, CompilationResult tables)
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");

            this.grammar = grammar;
            this.tables = tables;

            this.objects = new Dictionary<string, object>();
            this.names = new Dictionary<object, string>();
            this.safe = new SafeNameDictionary<object>(this.objects);
        }

        private string addName(string name, object obj)
        {
            name = safe.Add(name, obj);
            names.Add(obj, name);
            return name;
        }

        private void Visit(Grammar node)
        {
            fileElement.Add(nameElement = new NameSpaceElement(node.Namespace + ".Lexing"));
            fileElement.Using.Add(node.Namespace + ".Nodes");

            nameElement.Add(classElement = new ClassElement("public class Lexer : {0}.Lexer", SablePP.Generate.Namespaces.Lexing));

            Visit(node.States);

            string initialState = node.States.Length > 0 ? names[node.States[0]] : "0";
            classElement.Add(new MethodElement(
                "public Lexer(System.IO.TextReader input)",
                "base(input, " + initialState + ", gotoTable, acceptTable)", true));

            classElement.EmitNewline();
            classElement.Add(emitGetToken());
            if (node.States.Length > 0)
                classElement.Add(emitGetNextState());

            if (node.Tokens.Length > 0)
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

        private void Visit(Token[] node)
        {
            for (int tokenIndex = 0; tokenIndex < node.Length; tokenIndex++)
            {
                getTokenMethod.EmitLine("case {1}: return new {0}(text, line, position);", node[tokenIndex].Name, tokenIndex);

                if (node[tokenIndex].States.Any(item => item.To != null))
                {
                    getNextStateMethod.EmitLine("case {0}:", tokenIndex);
                    getNextStateMethod.IncreaseIndentation();
                    getNextStateMethod.EmitLine("switch (currentState)");
                    getNextStateMethod.EmitLine("{");
                    getNextStateMethod.IncreaseIndentation();

                    Visit(node[tokenIndex].States);

                    getNextStateMethod.EmitLine("default: return -1;");
                    getNextStateMethod.DecreaseIndentation();
                    getNextStateMethod.EmitLine("}");
                    getNextStateMethod.DecreaseIndentation();
                }
            }
        }

        private void Visit(Token.TokenState[] node)
        {
            foreach (var state in node)
                getNextStateMethod.EmitLine("case {0}: return {1};", names[state.From], names[state.To]);
        }

        private void Visit(State[] states)
        {
            for (int index = 0; index < states.Length; index++)
            {
                string name = addName("STATE", states[index]);

                classElement.EmitField("private const int " + name, index.ToString());
            }
            if (states.Length > 0)
                classElement.EmitNewline();
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
    }
}
