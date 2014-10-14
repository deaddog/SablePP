using SablePP.Tools.Generate;
using SablePP.Tools.Generate.CSharp;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate.Building
{
    internal class BLexer
    {
        private Grammar grammar;
        private CompilationResult tables;

        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private ClassElement classElement;

        private PatchElement getTokenMethod, getNextStateMethod;

        private NameTable<State> names;

        private BLexer(Grammar grammar, CompilationResult tables)
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");

            this.grammar = grammar;
            this.tables = tables;

            this.names = new NameTable<State>();
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
            classElement.EmitField("private static int[][][][] gotoTable", tables.LexerGotoTable);
            classElement.EmitNewline();
            classElement.EmitRegionEnd();

            classElement.EmitNewline();
            classElement.EmitRegionStart("Accept Table");
            classElement.EmitNewline();
            classElement.EmitField("private static int[][] acceptTable", tables.LexerAcceptTable);
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

        private void Visit(Token[] tokens)
        {
            for (int tokenIndex = 0; tokenIndex < tokens.Length; tokenIndex++)
            {
                getTokenMethod.EmitLine("case {1}: return new {0}(text, line, position);", tokens[tokenIndex].Name, tokenIndex);

                var states = tokens[tokenIndex].States.Where(item => item.To != null);
                if (states.Any())
                {
                    getNextStateMethod.EmitLine("case {0}:", tokenIndex);
                    getNextStateMethod.IncreaseIndentation();
                    getNextStateMethod.EmitLine("switch (currentState)");
                    getNextStateMethod.EmitLine("{");
                    getNextStateMethod.IncreaseIndentation();

                    Visit(states);

                    getNextStateMethod.EmitLine("default: return -1;");
                    getNextStateMethod.DecreaseIndentation();
                    getNextStateMethod.EmitLine("}");
                    getNextStateMethod.DecreaseIndentation();
                }
            }
        }

        private void Visit(IEnumerable<Token.TokenState> states)
        {
            foreach (var state in states)
                getNextStateMethod.EmitLine("case {0}: return {1};", names[state.From], names[state.To]);
        }

        private void Visit(State[] states)
        {
            for (int index = 0; index < states.Length; index++)
            {
                string name = names.Add("STATE", states[index]);

                classElement.EmitField("private const int " + name, index.ToString());
            }
            if (states.Length > 0)
                classElement.EmitNewline();
        }

        public static FileElement BuildCode(Grammar grammar, CompilationResult result)
        {
            BLexer lexer = new BLexer(grammar, result);
            lexer.Visit(grammar);

            return lexer.fileElement;
        }
    }
}
