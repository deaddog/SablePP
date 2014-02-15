using System;

using SablePP.Tools.Generate.CSharp;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Generate.Productions
{
    public class FieldBuilder : ProductionVisitor
    {
        private ClassElement classElement;

        public FieldBuilder(ClassElement classElement)
        {
            this.classElement = classElement;
        }

        public override void CaseASimpleElement(ASimpleElement node)
        {
            TIdentifier typeId = node.Elementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetFieldName(node);

            classElement.EmitField("private " + type + " " + name);
        }
        public override void CaseAStarElement(AStarElement node)
        {
            TIdentifier typeId = node.Elementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetFieldName(node);

            classElement.EmitField("private NodeList<" + type + "> " + name);
        }
        public override void CaseAPlusElement(APlusElement node)
        {
            TIdentifier typeId = node.Elementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetFieldName(node);

            classElement.EmitField("private NodeList<" + type + "> " + name);
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            TIdentifier typeId = node.Elementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetFieldName(node);

            classElement.EmitField("private " + type + " " + type);
        }
    }
}
