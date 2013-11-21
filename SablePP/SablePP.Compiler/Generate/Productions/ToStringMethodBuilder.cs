using System;

using Sable.Tools.Generate.CSharp;
using Sable.Compiler.Nodes;

namespace Sable.Compiler.Generate.Productions
{
    public class ToStringMethodBuilder : ProductionVisitor
    {
        private ClassElement classElement;
        private MethodElement method;
        private ParenthesisElement parenthesis;
        private bool first = true;

        private string buildingString = "";
        private int count = 0;

        public ToStringMethodBuilder(ClassElement classElement)
        {
            this.classElement = classElement;
        }

        public override void CaseAAlternative(AAlternative node)
        {
            method = classElement.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "ToString", "string");

            method.EmitReturn();
            method.EmitIdentifier("string");
            method.EmitPeriod();
            method.EmitIdentifier("Format");
            parenthesis = method.EmitParenthesis();
            method.EmitSemicolon(true);

            base.CaseAAlternative(node);
            parenthesis.EmitStringValue(buildingString);

            buildingString = null;
            first = true;
            count = 0;

            base.CaseAAlternative(node);
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
            if (buildingString != null)
            {
                if (!first)
                    buildingString += " ";
                else
                    first = false;
                buildingString += "{" + count + "}";
            }
            else
            {
                parenthesis.EmitComma();
                parenthesis.EmitIdentifier(GetFieldName(node));
            }

            count++;
        }
    }
}
