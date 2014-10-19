using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal partial class BProduction
    {
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
    }
}
