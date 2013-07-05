using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sable.Compiler.analysis;
using Sable.Compiler.node;
using Sable.Tools.Generate.CSharp;

namespace Sable.Compiler.Generate.Tokens
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
        }

        public static FileElement BuildCode(Start astRoot)
        {
            TokenNodes n = new TokenNodes();
            astRoot.Apply(n);
            return n.fileElement;
        }

        private string GetTokenName(PToken element)
        {
            if (element is AToken)
                return "T" + ToCamelCase((element as AToken).GetIdentifier().Text);
            else
                throw new NotImplementedException("Unknown token type.");
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.GetPackage() != null)
                node.GetPackage().Apply(this);

            string packageName = node.PackageName;

            nameElement = fileElement.CreateNamespace(packageName + ".Nodes");
            fileElement.Using.Add(packageName + ".Analysis");

            if (node.GetTokens() != null)
                node.GetTokens().Apply(this);
        }

        public override void CaseAToken(AToken node)
        {
            string name = GetTokenName(node);

            classElement = nameElement.CreateClass(name, AccessModifiers.@public | AccessModifiers.partial, "Token<" + name + ">");

            EmitConstructor1();
            EmitConstructor2();
            classElement.EmitNewLine();
            EmitCloneMethod();
            classElement.EmitNewLine();
            EmitApplyVoidMethod();
            EmitApplyTypeMethod();
        }

        private void EmitConstructor1()
        {
            MethodElement construct = classElement.CreateConstructor(AccessModifiers.@public, true);

            construct.Parameters.Add("text", "string");

            construct.Chain.EmitIdentifier("text");
        }
        private void EmitConstructor2()
        {
            MethodElement construct = classElement.CreateConstructor(AccessModifiers.@public, true);

            construct.Parameters.Add("text", "string");
            construct.Parameters.Add("line", "int");
            construct.Parameters.Add("pos", "int");

            construct.Chain.EmitIdentifier("text");
            construct.Chain.EmitComma();
            construct.Chain.EmitIdentifier("line");
            construct.Chain.EmitComma();
            construct.Chain.EmitIdentifier("pos");
        }

        private void EmitCloneMethod()
        {
            MethodElement method = classElement.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "Clone", classElement.Name);

            method.EmitReturn();
            method.EmitNew();
            method.EmitIdentifier(classElement.Name);
            using (var par = method.EmitParenthesis())
            {
                par.EmitIdentifier("Text");
                par.EmitComma();
                par.EmitIdentifier("Line");
                par.EmitComma();
                par.EmitIdentifier("Position");
            }
            method.EmitSemicolon(true);
        }

        private void EmitApplyVoidMethod()
        {
            MethodElement method = classElement.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "Apply", "void");
            method.Parameters.Add("a", "IAnalysis");

            method.EmitIdentifier("a");
            method.EmitPeriod();
            method.EmitIdentifier("Case" + classElement.Name);
            using (var par = method.EmitParenthesis())
            {
                par.EmitThis();
            }
            method.EmitSemicolon(true);
        }
        private void EmitApplyTypeMethod()
        {
            MethodElement method = classElement.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "Apply", "T");
            method.Parameters.Add("a", "IAnalysis<T>");
            method.Parameters.Add("arg", "T");
            method.TypeParameters.Add("T");

            method.EmitReturn();
            method.EmitIdentifier("a");
            method.EmitPeriod();
            method.EmitIdentifier("Case" + classElement.Name);
            using (var par = method.EmitParenthesis())
            {
                par.EmitThis();
                par.EmitComma();
                par.EmitIdentifier("arg");
            }
            method.EmitSemicolon(true);
        }
    }
}
