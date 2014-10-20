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

            foreach (var v in node.Elements)
                variables.Add("arg", v);
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
            switch (node.Modifier)
            {
                case Modifiers.Single:
                case Modifiers.Optional:
                    classElement.EmitField("private " + node.GeneratedName + " " + variables.Add("member", node));
                    break;
                case Modifiers.OneOrMany:
                case Modifiers.ZeroOrMany:
                    classElement.EmitField("private NodeList<" + node.GeneratedName + "> " + variables.Add("member_list", node));
                    break;
            }
        }
    }
}
