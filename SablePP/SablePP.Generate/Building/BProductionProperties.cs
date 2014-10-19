using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal partial class BProduction
    {
        public static void Emit(ClassElement classElement, AProduction node)
        {
            var fields = ProductionElement.GetSharedElements(node);
            if (fields.Length > 0)
            {
                emit(classElement, fields);
                classElement.EmitNewline();
            }
        }
        public static void Emit(ClassElement classElement, AAlternative node)
        {
            var fields = ProductionElement.GetUniqueElements(node);
            if (fields.Length > 0)
            {
                emit(classElement, fields);
                classElement.EmitNewline();
            }
        }

        private static void emit(ClassElement classElement, IEnumerable<ProductionElement> elements)
        {
            PropertiesBuilder builder = new PropertiesBuilder() { classElement = classElement };
            foreach (var e in elements)
                builder.emitElement(e);
        }

        private void emitElement(ProductionElement node)
        {
            switch (node.ElementType)
            {
                case ElementTypes.Simple:
                    emitSimpleElement(node);
                    break;
                case ElementTypes.Question:
                    emitQuestionElement(node);
                    break;
                case ElementTypes.Plus:
                case ElementTypes.Star:
                    GetPropertyElement property;
                    classElement.Add(property = new GetPropertyElement(AccessModifiers.@public, node.PropertyName, "NodeList<" + node.ProductionOrTokenClass + ">"));
                    EmitGet(node, property);
                    break;
            }
        }

        private void emitSimpleElement(ProductionElement node)
        {
            GetSetPropertyElement property;
            classElement.Add(property = new GetSetPropertyElement(AccessModifiers.@public, node.PropertyName, node.ProductionOrTokenClass));
            EmitGet(node, property);

            property.Set.EmitLine("if (value == null)");

            property.Set.IncreaseIndentation();
            property.Set.EmitLine("throw new ArgumentException(\"{0} in {1} cannot be null.\", \"value\");", node.PropertyName, classElement.Name);
            property.Set.DecreaseIndentation();

            property.Set.EmitNewLine();

            property.Set.EmitLine("if ({0} != null)", node.FieldName);

            property.Set.IncreaseIndentation();
            property.Set.EmitLine("SetParent({0}, null);", node.FieldName);
            property.Set.DecreaseIndentation();

            property.Set.EmitLine("SetParent(value, this);");

            property.Set.EmitNewLine();

            property.Set.Emit("{0} = value;", node.FieldName);
        }
        private void emitQuestionElement(ProductionElement node)
        {
            GetSetPropertyElement property;
            classElement.Add(property = new GetSetPropertyElement(AccessModifiers.@public, node.PropertyName, node.ProductionOrTokenClass));
            EmitGet(node, property);

            property.Set.EmitLine("if ({0} != null)", node.FieldName);

            property.Set.IncreaseIndentation();
            property.Set.EmitLine("SetParent({0}, null);", node.FieldName);
            property.Set.DecreaseIndentation();

            property.Set.EmitLine("if (value != null)");

            property.Set.IncreaseIndentation();
            property.Set.EmitLine("SetParent(value, this);");
            property.Set.DecreaseIndentation();

            property.Set.EmitNewLine();

            property.Set.Emit("{0} = value;", node.FieldName);

            GetPropertyElement hasProperty;
            classElement.Add(hasProperty = new GetPropertyElement(AccessModifiers.@public, "Has" + node.PropertyName, "bool"));
            hasProperty.Get.Emit("return {0} != null;", node.FieldName);
        }

        private void EmitGet(ProductionElement node, IGetProperty property)
        {
            property.Get.Emit("return {0};", node.FieldName);
        }
    }
}
