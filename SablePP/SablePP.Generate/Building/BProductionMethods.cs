using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal partial class BProduction
    {
        private static readonly string newChild = "newChild";
        private static readonly string oldChild = "oldChild";

        private void emitCloneMethod(AbstractAlternative node)
        {
            AbstractAlternative.Element[] elements = node.Elements;

            MethodElement replaceMethod = new MethodElement("public override {0} Clone()", true, node.Production.Name);
            replaceMethod.Body.Emit("return new {0}({1});", classElement.Name, string.Join(", ", elements.Select(getCloneMethodArgument)));

            classElement.Add(replaceMethod);
            classElement.EmitNewline();
        }
        private string getCloneMethodArgument(AbstractAlternative.Element node)
        {
            switch (node.Modifier)
            {
                case Modifiers.Single:
                case Modifiers.Optional:
                    return node.Name + ".Clone()";
                case Modifiers.ZeroOrMany:
                case Modifiers.OneOrMany:
                    break;
                default:
                    return node.Name;
            }
            throw new InvalidOperationException("Unknown modifier.");
        }

        private void emitGetChildrenMethod(AbstractAlternative node)
        {
            AbstractAlternative.Element[] elements = node.Elements;

            MethodElement getChildrenMethod = new MethodElement("protected override IEnumerable<Node> GetChildren()");

            foreach (var e in elements)
                emitGetChildrenMethodElement(getChildrenMethod, e);

            classElement.Add(getChildrenMethod);
            classElement.EmitNewline();
        }
        private void emitGetChildrenMethodElement(MethodElement method, AbstractAlternative.Element node)
        {
            switch (node.Modifier)
            {
                case Modifiers.Single:
                    method.Body.EmitLine("yield return {0};", node.Name);
                    break;

                case Modifiers.Optional:
                    method.Body.EmitLine("if (Has{0})", node.Name);
                    method.Body.IncreaseIndentation();
                    method.Body.EmitLine("yield return {0};", node.Name);
                    method.Body.DecreaseIndentation();
                    break;

                case Modifiers.OneOrMany:
                case Modifiers.ZeroOrMany:
                    method.Body.EmitLine("{");
                    method.Body.IncreaseIndentation();

                    method.Body.EmitLine("{0}[] temp = new {0}[{1}.Count];", node.GeneratedName, node.Name);
                    method.Body.EmitLine("{0}.CopyTo(temp, 0);", node.Name);
                    method.Body.EmitLine("for (int i = 0; i < temp.Length; i++)");
                    method.Body.IncreaseIndentation();
                    method.Body.EmitLine("yield return temp[i];");
                    method.Body.DecreaseIndentation();

                    method.Body.DecreaseIndentation();
                    method.Body.EmitLine("}");
                    break;
            }
        }

        private void emitReplaceChildMethod(AbstractAlternative node)
        {
            var elements = node.Elements;

            MethodElement replaceChildMethod = new MethodElement("public override void ReplaceChild(Node {0}, Node {1})", true, oldChild, newChild);

            foreach (var e in elements)
                emitReplaceChildMethodElement(replaceChildMethod, e);

            replaceChildMethod.Body.EmitLine("throw new ArgumentException(\"Node to be replaced is not a child in this production.\");");

            classElement.Add(replaceChildMethod);
        }
        private void emitReplaceChildMethodElement(MethodElement method, AbstractAlternative.Element node)
        {
            switch (node.Modifier)
            {
                case Modifiers.Single:
                case Modifiers.Optional:
                    {
                        method.Body.EmitLine("if ({0} == {1})", node.Name, oldChild);
                        method.Body.EmitLine("{");
                        method.Body.IncreaseIndentation();

                        if (node.Modifier == Modifiers.Single)
                        {
                            method.Body.EmitLine("if ({0} == null)", newChild);
                            method.Body.IncreaseIndentation();
                            method.Body.EmitLine("throw new ArgumentException(\"{0} in {1} cannot be null.\", \"{2}\");", node.Name, classElement.Name, newChild);
                            method.Body.DecreaseIndentation();
                        }

                        method.Body.EmitLine("if (!({0} is {1}) && {0} != null)", newChild, node.GeneratedName);
                        method.Body.IncreaseIndentation();
                        method.Body.EmitLine("throw new ArgumentException(\"Child replaced must be of same type as child being replaced with.\");");
                        method.Body.DecreaseIndentation();

                        method.Body.EmitLine("{0} = {1} as {2};", node.Name, newChild, node.GeneratedName);

                        method.Body.DecreaseIndentation();
                        method.Body.EmitLine("}");
                        method.Body.Emit("else ");
                    }
                    break;

                case Modifiers.OneOrMany:
                case Modifiers.ZeroOrMany:
                    {
                        method.Body.EmitLine("if ({0} is {1} && {2}.Contains({0} as {1}))", oldChild, node.GeneratedName, node.Name);
                        method.Body.EmitLine("{");
                        method.Body.IncreaseIndentation();

                        method.Body.EmitLine("if (!({0} is {1}) && {0} != null)", newChild, node.GeneratedName);
                        method.Body.IncreaseIndentation();
                        method.Body.EmitLine("throw new ArgumentException(\"Child replaced must be of same type as child being replaced with.\");");
                        method.Body.DecreaseIndentation();
                        method.Body.EmitNewLine();

                        method.Body.EmitLine("int index = {0}.IndexOf({1} as {2});", node.Name, oldChild, node.GeneratedName);
                        method.Body.EmitLine("if ({0} == null)", newChild);
                        method.Body.IncreaseIndentation();
                        method.Body.EmitLine("{0}.RemoveAt(index);", node.Name);
                        method.Body.DecreaseIndentation();
                        method.Body.EmitLine("else");
                        method.Body.IncreaseIndentation();
                        method.Body.EmitLine("{0}[index] = {1} as {2};", node.Name, newChild, node.GeneratedName);
                        method.Body.DecreaseIndentation();

                        method.Body.DecreaseIndentation();
                        method.Body.EmitLine("}");
                        method.Body.Emit("else ");
                    }
                    break;
            }
        }
    }
}
