using System;

using Sable.Tools.Generate.CSharp;
using Sable.Compiler.Nodes;

namespace Sable.Compiler.Generate.Productions
{
    public class CloneMethodBuilder : ProductionVisitor
    {
        private ClassElement classElement;
        private MethodElement method;
        private ParenthesisElement parenthesis;
        private bool first = true;

        public CloneMethodBuilder(ClassElement classElement)
        {
            this.classElement = classElement;
        }

        public override void InAAlternative(AAlternative node)
        {
            method = classElement.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "Clone", classElement.Implements);

            method.EmitReturn();
            method.EmitNew();
            method.EmitIdentifier(classElement.Name);
            parenthesis = method.EmitParenthesis();
            method.EmitSemicolon(true);

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
            if (!first)
                parenthesis.EmitComma();
            else
                first = false;

            parenthesis.EmitIdentifier(GetFieldName(node));
            if (!list)
            {
                parenthesis.EmitPeriod();
                parenthesis.EmitIdentifier("Clone");
                parenthesis.EmitParenthesis();
            }
        }
    }
}
