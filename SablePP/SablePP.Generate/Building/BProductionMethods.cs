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
    }
}
