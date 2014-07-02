using System;

using SablePP.Tools.Generate.CSharp;
using SablePP.Compiler.Nodes;
using System.Collections.Generic;

namespace SablePP.Compiler.Generate.Productions
{
    public class PropertiesBuilder : ProductionVisitor
    {
        private ClassElement classElement;

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

        }

        public override void CaseASimpleElement(ASimpleElement node)
        {
            string field = GetFieldName(node);

            GetSetPropertyElement property = CreateProperty(node);
            EmitGet(node, property);

            property.Set.EmitLine("if (value == null)");

            property.Set.IncreaseIndentation();
            property.Set.EmitLine("throw new ArgumentException(\"{0} in {1} cannot be null.\", \"value\");", GetPropertyName(node), classElement.Name);
            property.Set.DecreaseIndentation();

            property.Set.EmitLine("SetParent(value, this);");

            property.Set.EmitNewLine();

            property.Set.Emit("{0} = value;", field);
        }
        public override void CaseAStarElement(AStarElement node)
        {
            GetPropertyElement property = CreateProperty(node);
            EmitGet(node, property);
        }
        public override void CaseAPlusElement(APlusElement node)
        {
            GetPropertyElement property = CreateProperty(node);
            EmitGet(node, property);
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            string field = GetFieldName(node);

            GetSetPropertyElement property = CreateProperty(node);
            EmitGet(node, property);

            property.Set.EmitLine("if ({0} != null)", field);

            property.Set.IncreaseIndentation();
            property.Set.EmitLine("SetParent({0}, null);", field);
            property.Set.DecreaseIndentation();

            property.Set.EmitLine("if (value != null)");

            property.Set.IncreaseIndentation();
            property.Set.EmitLine("SetParent(value, this);");
            property.Set.DecreaseIndentation();

            property.Set.EmitNewLine();

            property.Set.Emit("{0} = value;", field);

            GetPropertyElement hasProperty;
            classElement.Add(hasProperty = new GetPropertyElement(AccessModifiers.@public, "Has" + GetPropertyName(node), "bool"));
            hasProperty.Get.Emit("return {0} != null;", GetFieldName(node));
        }

        private GetSetPropertyElement CreateProperty(ASimpleElement node)
        {
            TIdentifier typeId = node.PElementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetPropertyName(node);

            GetSetPropertyElement property;
            classElement.Add(property = new GetSetPropertyElement(AccessModifiers.@public, name, type));
            return property;
        }
        private GetSetPropertyElement CreateProperty(AQuestionElement node)
        {
            TIdentifier typeId = node.PElementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetPropertyName(node);

            GetSetPropertyElement property;
            classElement.Add(property = new GetSetPropertyElement(AccessModifiers.@public, name, type));
            return property;
        }
        private GetPropertyElement CreateProperty(APlusElement node)
        {
            TIdentifier typeId = node.PElementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetPropertyName(node);

            GetPropertyElement property;
            classElement.Add(property = new GetPropertyElement(AccessModifiers.@public, name, "NodeList<" + type + ">"));
            return property;
        }
        private GetPropertyElement CreateProperty(AStarElement node)
        {
            TIdentifier typeId = node.PElementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetPropertyName(node);

            GetPropertyElement property;
            classElement.Add(property = new GetPropertyElement(AccessModifiers.@public, name, "NodeList<" + type + ">"));
            return property;
        }

        private void EmitGet(PElement node, IGetProperty property)
        {
            property.Get.Emit("return {0};", GetFieldName(node));
        }
    }
}
