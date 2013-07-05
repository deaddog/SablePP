using System;

using Sable.Tools.Generate.CSharp;
using Sable.Compiler.node;

namespace Sable.Compiler.Generate.Productions
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

            PropertyElement property = CreateProperty(node);
            EmitGet(node, property);

            //if (value == null)
            using (var par = property.Set.EmitIf())
            {
                par.EmitIdentifier("value");
                par.EmitEqual();
                par.EmitNull();
            }
            property.Set.EmitNewLine();
            property.Set.IncreaseIndentation();

            //throw new ArgumentException("Identifier in AAssignment cannot be null.", "value");
            property.Set.EmitThrow();
            property.Set.EmitNew();
            property.Set.EmitIdentifier("ArgumentException");
            using (var par = property.Set.EmitParenthesis())
            {
                par.EmitStringValue(GetPropertyName(node) + " in " + classElement.Name + " cannot be null.");
                par.EmitComma();
                par.EmitStringValue("value");
            }
            property.Set.EmitSemicolon(true);
            property.Set.DecreaseIndentation();

            //SetParent(value, this);
            property.Set.EmitIdentifier("SetParent");
            using (var par = property.Set.EmitParenthesis())
            {
                par.EmitIdentifier("value");
                par.EmitComma();
                par.EmitThis();
            }
            property.Set.EmitSemicolon(true);

            // _identifier_ = value;
            property.Set.EmitNewLine();
            property.Set.EmitIdentifier(field);
            property.Set.EmitAssignment();
            property.Set.EmitIdentifier("value");
            property.Set.EmitSemicolon(true);
        }
        public override void CaseAStarElement(AStarElement node)
        {
            PropertyElement property = CreateProperty(node);
            EmitGet(node, property);
        }
        public override void CaseAPlusElement(APlusElement node)
        {
            PropertyElement property = CreateProperty(node);
            EmitGet(node, property);
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            string field = GetFieldName(node);

            PropertyElement property = CreateProperty(node);
            EmitGet(node, property);

            //if (_identifier_ != null)
            using (var par = property.Set.EmitIf())
            {
                par.EmitIdentifier(field);
                par.EmitNotEqual();
                par.EmitNull();
            }
            property.Set.EmitNewLine();
            property.Set.IncreaseIndentation();

            //SetParent(_identifier_, null);
            property.Set.EmitIdentifier("SetParent");
            using (var par = property.Set.EmitParenthesis())
            {
                par.EmitIdentifier(field);
                par.EmitComma();
                par.EmitNull();
            }
            property.Set.EmitSemicolon(true);
            property.Set.DecreaseIndentation();

            //if (value != null)
            using (var par = property.Set.EmitIf())
            {
                par.EmitIdentifier("value");
                par.EmitNotEqual();
                par.EmitNull();
            }
            property.Set.EmitNewLine();
            property.Set.IncreaseIndentation();

            //SetParent(value, this);
            property.Set.EmitIdentifier("SetParent");
            using (var par = property.Set.EmitParenthesis())
            {
                par.EmitIdentifier("value");
                par.EmitComma();
                par.EmitThis();
            }
            property.Set.EmitSemicolon(true);
            property.Set.DecreaseIndentation();

            // _identifier_ = value;
            property.Set.EmitNewLine();
            property.Set.EmitIdentifier(field);
            property.Set.EmitAssignment();
            property.Set.EmitIdentifier("value");
            property.Set.EmitSemicolon(true);

            PropertyElement hasProperty = classElement.CreateGetProperty(AccessModifiers.@public, "Has" + GetPropertyName(node), "bool");
            hasProperty.Get.EmitReturn();
            hasProperty.Get.EmitIdentifier(GetFieldName(node));
            hasProperty.Get.EmitNotEqual();
            hasProperty.Get.EmitNull();
            hasProperty.Get.EmitSemicolon(false);
        }

        private PropertyElement CreateProperty(PElement node)
        {
            TIdentifier typeId = node.Elementid.Identifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetPropertyName(node);

            if (node is AStarElement || node is APlusElement)
                return classElement.CreateGetProperty(AccessModifiers.@public, name, "NodeList<" + type + ">");
            else
                return classElement.CreateProperty(AccessModifiers.@public, name, type);
        }

        private void EmitGet(PElement node, PropertyElement property)
        {
            property.Get.EmitReturn();
            property.Get.EmitIdentifier(GetFieldName(node));
            property.Get.EmitSemicolon(false);
        }
    }
}
