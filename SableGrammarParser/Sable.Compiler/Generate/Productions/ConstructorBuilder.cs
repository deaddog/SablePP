using System;

using Sable.Tools.Generate.CSharp;
using Sable.Compiler.node;

namespace Sable.Compiler.Generate.Productions
{
    public class ConstructorBuilder : ProductionVisitor
    {
        private ClassElement classElement;
        private MethodElement constructor;

        public ConstructorBuilder(ClassElement classElement)
        {
            this.classElement = classElement;
        }

        public override void InAAlternative(AAlternative node)
        {
            constructor = classElement.CreateConstructor(AccessModifiers.@public);
            base.InAAlternative(node);
        }

        public override void CaseASimpleElement(ASimpleElement node)
        {
            Emit(node, false);
        }
        public override void CaseAStarElement(AStarElement node)
        {
            Emit(node, true);
        }
        public override void CaseAPlusElement(APlusElement node)
        {
            Emit(node, true);
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            Emit(node, false);
        }

        private void Emit(PElement node, bool list)
        {
            TIdentifier typeId = node.Elementid.Identifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));

            if (list)
                constructor.Parameters.Add(GetFieldName(node), "IEnumerable<" + type + ">");
            else
                constructor.Parameters.Add(GetFieldName(node), type);

            constructor.EmitThis();
            constructor.EmitPeriod();
            constructor.EmitIdentifier(list ? GetFieldName(node) : GetPropertyName(node));
            constructor.EmitAssignment();
            if (list)
            {
                constructor.EmitNew();
                constructor.EmitIdentifier("NodeList");
                using (var par = constructor.EmitParenthesis(ParenthesisElement.Types.Angled))
                    par.EmitIdentifier(type);
                using (var par = constructor.EmitParenthesis(ParenthesisElement.Types.Round))
                {
                    par.EmitThis();
                    par.EmitComma();
                    par.EmitIdentifier(GetFieldName(node));
                    par.EmitComma();
                    if (node is AStarElement)
                        par.EmitTrue();
                    else
                        par.EmitFalse();
                }
            }
            else
                constructor.EmitIdentifier(GetFieldName(node));
            constructor.EmitSemicolon(true);
        }
    }
}
