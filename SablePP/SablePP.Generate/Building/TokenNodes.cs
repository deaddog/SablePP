using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal class TokenNodes
    {
        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private ClassElement classElement;

        private TokenNodes()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Collections.Generic");
            fileElement.Using.Add(SablePP.Generate.Namespaces.Nodes);
        }

        public static FileElement BuildCode(Grammar grammar)
        {
            TokenNodes n = new TokenNodes();
            n.Visit(grammar);
            return n.fileElement;
        }
        private void Visit(Grammar node)
        {
            fileElement.Add(nameElement = new NameSpaceElement(node.Namespace + ".Nodes"));
            fileElement.Using.Add(node.Namespace + ".Analysis");

            foreach (var t in node.Tokens)
                Visit(t);
        }

        private void Visit(Token node)
        {
            nameElement.Add(classElement = new ClassElement("public partial class {0} : Token<{0}>", node.Name));

            EmitNoArgsConstructor(node);

            classElement.Add(new MethodElement("public {0}(string text)", "base(text)", true, classElement.Name));
            classElement.Add(new MethodElement("public {0}(string text, int line, int pos)", "base(text, line, pos)", true, classElement.Name));

            classElement.EmitNewline();

            EmitCloneMethod();
        }

        private void EmitNoArgsConstructor(Token node)
        {
            if (!(node.Expression is RegularExpressions.LiteralRegExp))
                return;

            RegularExpressions.LiteralRegExp exp = node.Expression as RegularExpressions.LiteralRegExp;

            string content = exp.IsChar ? exp.Char.Value.ToString() : exp.Content;
            content = content.Replace("\"", "\\\"");

            classElement.Add(new MethodElement("public {0}()", "base(@\"{1}\")", true, classElement.Name, content));
        }

        private void EmitCloneMethod()
        {
            MethodElement method = new MethodElement("public override {0} Clone()", true, classElement.Name);
            method.Body.EmitLine("return new {0}(Text, Line, Position);", classElement.Name);

            classElement.Add(method);
        }
    }
}
