using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate.CSharp;
using SablePP.Tools.Nodes;

namespace SablePP.Compiler.Generate.Tokens
{
    public class TokenNodes : GenerateVisitor
    {
        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private ClassElement classElement;

        private TokenNodes()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Collections.Generic");
            fileElement.Using.Add(ToolsNamespace.Nodes);
        }

        public static FileElement BuildCode(Start<PGrammar> astRoot)
        {
            TokenNodes n = new TokenNodes();
            n.Visit(astRoot);
            return n.fileElement;
        }

        private string GetTokenName(PToken element)
        {
            if (element is AToken)
                return "T" + ToCamelCase((element as AToken).Identifier.Text);
            else
                throw new NotImplementedException("Unknown token type.");
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            string packageName = node.PackageName;

            fileElement.Add(nameElement = new NameSpaceElement(packageName + ".Nodes"));
            fileElement.Using.Add(packageName + ".Analysis");

            if (node.HasTokens)
                Visit(node.Tokens);
        }

        public override void CaseAToken(AToken node)
        {
            string name = GetTokenName(node);

            nameElement.Add(classElement = new ClassElement("public partial class {0} : Token<{0}>", name));

            EmitConstructor1();
            EmitConstructor2();
            classElement.EmitNewline();
            EmitCloneMethod();
        }

        private void EmitConstructor1()
        {
            classElement.Add(new MethodElement("public {0}(string text)", "base(text)", true, classElement.Name));
        }
        private void EmitConstructor2()
        {
            classElement.Add(new MethodElement("public {0}(string text, int line, int pos)", "base(text, line, pos)", true, classElement.Name));
        }

        private void EmitCloneMethod()
        {
            MethodElement method = new MethodElement("public override {0} Clone()", true, classElement.Name);
            method.Body.EmitLine("return new {0}(Text, Line, Position);", classElement.Name);

            classElement.Add(method);
        }
    }
}
