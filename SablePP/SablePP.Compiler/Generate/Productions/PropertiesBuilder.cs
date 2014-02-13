using System;

using SablePP.Tools.Generate.CSharp;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Generate.Productions
{
    public class PropertiesBuilder : ProductionVisitor
    {
        private ClassElement classElement;

        public PropertiesBuilder(ClassElement classElement)
        {
            this.classElement = classElement;
        }

        public override void CaseASimpleElement(ASimpleElement node)
        {
            string field = GetFieldName(node);

            GetSetPropertyElement property = CreateProperty(node);
            EmitGet(node, property);

            property.Set.EmitLine("if (value == null)");

            property.Set.IncreaseIndentation();
            property.Set.EmitLine("throw new ArgumentException(\"{0} in {1} cannot be null.\", \"value\");",GetPropertyName(node),classElement.Name);
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

            GetPropertyElement hasProperty = classElement.CreateGetProperty(AccessModifiers.@public, "Has" + GetPropertyName(node), "bool");
            hasProperty.Get.Emit("return {0} != null;", GetFieldName(node));
        }

        private GetSetPropertyElement CreateProperty(ASimpleElement node)
        {
            TIdentifier typeId = node.PElementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetPropertyName(node);

            return classElement.CreateProperty(AccessModifiers.@public, name, type);
        }
        private GetSetPropertyElement CreateProperty(AQuestionElement node)
        {
            TIdentifier typeId = node.PElementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetPropertyName(node);

            return classElement.CreateProperty(AccessModifiers.@public, name, type);
        }
        private GetPropertyElement CreateProperty(APlusElement node)
        {
            TIdentifier typeId = node.PElementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetPropertyName(node);

            return classElement.CreateGetProperty(AccessModifiers.@public, name, "NodeList<" + type + ">");
        }
        private GetPropertyElement CreateProperty(AStarElement node)
        {
            TIdentifier typeId = node.PElementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetPropertyName(node);

            return classElement.CreateGetProperty(AccessModifiers.@public, name, "NodeList<" + type + ">");
        }

        private void EmitGet(PElement node, IGetProperty property)
        {
            property.Get.Emit("return {0};", GetFieldName(node));
        }
    }
}
