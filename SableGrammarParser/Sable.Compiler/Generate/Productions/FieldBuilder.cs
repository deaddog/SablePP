﻿using System;

using Sable.Tools.Generate.CSharp;
using Sable.Compiler.node;

namespace Sable.Compiler.Generate.Productions
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
            TIdentifier typeId = node.GetElementid().Identifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetFieldName(node);

            classElement.EmitField(name, type, AccessModifiers.@private);
        }
        public override void CaseAStarElement(AStarElement node)
        {
            TIdentifier typeId = node.GetElementid().Identifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetFieldName(node);

            classElement.EmitField(name, "NodeList<" + type + ">", AccessModifiers.@private);
        }
        public override void CaseAPlusElement(APlusElement node)
        {
            TIdentifier typeId = node.GetElementid().Identifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetFieldName(node);

            classElement.EmitField(name, "NodeList<" + type + ">", AccessModifiers.@private);
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            TIdentifier typeId = node.GetElementid().Identifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetFieldName(node);

            classElement.EmitField(name, type, AccessModifiers.@private);
        }
    }
}
