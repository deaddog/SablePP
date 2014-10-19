using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal partial class BProduction
    {
        private void emitElementFields(AbstractProduction node)
        {
            emitElementFields(node.SharedElements);
        }
        private void emitElementFields(AbstractAlternative node)
        {
            emitElementFields(node.UniqueElements);
        }

        private void emitElementFields(AbstractAlternative.Element[] elements)
        {
            if (elements.Length > 0)
            {
                foreach (var e in elements)
                    emitElementField(e);

                classElement.EmitNewline();
            }
        }

        private void emitElementField(AbstractAlternative.Element node)
        {
            string name = variables.Add("member", node);
            string type = (node is AbstractAlternative.TokenElement) ?
                (node as AbstractAlternative.TokenElement).Token.Name :
                (node as AbstractAlternative.ProductionElement).Production.Name;

            switch (node.Modifier)
            {
                case Modifiers.Single:
                case Modifiers.Optional:
                    classElement.EmitField("private " + type + " " + name);
                    break;
                case Modifiers.OneOrMany:
                case Modifiers.ZeroOrMany:
                    classElement.EmitField("private NodeList<" + type + "> " + name);
                    break;
            }
        }
    }
}
