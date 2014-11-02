using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal partial class BProduction
    {
        private void emitProperties(AbstractProduction node)
        {
            emitProperties(node.SharedElements);
        }
        private void emitProperties(AbstractAlternative node)
        {
            emitProperties(node.UniqueElements);
        }

        private void emitProperties(AbstractAlternative.Element[] elements)
        {
            if (elements.Length > 0)
            {
                foreach (var e in elements)
                    emitElementProperty(e);
                classElement.EmitNewline();
            }
        }

        private void emitElementProperty(AbstractAlternative.Element node)
        {
            switch (node.Modifier)
            {
                case Modifiers.Single:
                    emitSingleElementProperty(node);
                    break;
                case Modifiers.Optional:
                    emitOptionalElementProperty(node);
                    break;
                case Modifiers.OneOrMany:
                case Modifiers.ZeroOrMany:
                    GetPropertyElement property;
                    classElement.Add(property = new GetPropertyElement(AccessModifiers.@public, node.Name, "NodeList<" + node.GeneratedName + ">"));
                    property.Get.Emit("return {0};", variables[node]);
                    break;
            }
        }

        private void emitSingleElementProperty(AbstractAlternative.Element node)
        {
            GetSetPropertyElement property;
            classElement.Add(property = new GetSetPropertyElement(AccessModifiers.@public, node.Name, node.GeneratedName));
            property.Get.Emit("return {0};", variables[node]);

            property.Set.EmitLine("if (value == null)");

            property.Set.IncreaseIndentation();
            property.Set.EmitLine("throw new ArgumentException(\"{0} in {1} cannot be null.\", \"value\");", node.Name, classElement.Name);
            property.Set.DecreaseIndentation();

            property.Set.EmitNewLine();

            property.Set.EmitLine("if ({0} != null)", variables[node]);

            property.Set.IncreaseIndentation();
            property.Set.EmitLine("SetParent({0}, null);", variables[node]);
            property.Set.DecreaseIndentation();

            property.Set.EmitLine("SetParent(value, this);");

            property.Set.EmitNewLine();

            property.Set.Emit("{0} = value;", variables[node]);
        }
        private void emitOptionalElementProperty(AbstractAlternative.Element node)
        {
            GetSetPropertyElement property;
            classElement.Add(property = new GetSetPropertyElement(AccessModifiers.@public, node.Name, node.GeneratedName));
            property.Get.Emit("return {0};", variables[node]);

            property.Set.EmitLine("if ({0} != null)", variables[node]);

            property.Set.IncreaseIndentation();
            property.Set.EmitLine("SetParent({0}, null);", variables[node]);
            property.Set.DecreaseIndentation();

            property.Set.EmitLine("if (value != null)");

            property.Set.IncreaseIndentation();
            property.Set.EmitLine("SetParent(value, this);");
            property.Set.DecreaseIndentation();

            property.Set.EmitNewLine();

            property.Set.Emit("{0} = value;", variables[node]);

            GetPropertyElement hasProperty;
            classElement.Add(hasProperty = new GetPropertyElement(AccessModifiers.@public, "Has" + node.Name, "bool"));
            hasProperty.Get.Emit("return {0} != null;", variables[node]);
        }
    }
}
