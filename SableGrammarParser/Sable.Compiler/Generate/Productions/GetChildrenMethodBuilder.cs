using System;

using Sable.Tools.Generate.CSharp;
using Sable.Compiler.Nodes;

namespace Sable.Compiler.Generate.Productions
{
    public class GetChildrenMethodBuilder : ProductionVisitor
    {
        private ClassElement classElement;
        private MethodElement method;

        public GetChildrenMethodBuilder(ClassElement classElement)
        {
            this.classElement = classElement;
        }

        public override void InAAlternative(AAlternative node)
        {
            method = classElement.CreateMethod(AccessModifiers.@protected | AccessModifiers.@override, "GetChildren", "IEnumerable<Node>");

            base.InAAlternative(node);
        }

        public override void CaseASimpleElement(ASimpleElement node)
        {
            method.EmitYield();
            method.EmitReturn();
            method.EmitIdentifier(GetFieldName(node));
            method.EmitSemicolon(true);
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            using (var iff = method.EmitIf())
                iff.EmitIdentifier("Has" + ToCamelCase(node.LowerName));
            method.EmitNewLine();
            method.IncreaseIndentation();

            method.EmitYield();
            method.EmitReturn();
            method.EmitIdentifier(GetFieldName(node));
            method.EmitSemicolon(true);

            method.DecreaseIndentation();
        }

        public override void CaseAStarElement(AStarElement node)
        {
            TIdentifier typeId = node.Elementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetFieldName(node);

            EmitListWalking(type, name, node);
        }
        public override void CaseAPlusElement(APlusElement node)
        {
            TIdentifier typeId = node.Elementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = GetFieldName(node);

            EmitListWalking(type, name, node);
        }

        private void EmitListWalking(string type, string name, PElement node)
        {
            method.EmitBlockStart();

            //PAssignment[] temp = new PAssignment[_assignment.Count];
            method.EmitIdentifier(type + "[]");
            method.EmitIdentifier("temp");
            method.EmitAssignment();
            method.EmitNew();
            method.EmitIdentifier(type);
            using (var par = method.EmitParenthesis(ParenthesisElement.Types.Square))
            {
                par.EmitIdentifier(name);
                par.EmitPeriod();
                par.EmitIdentifier("Count");
            }
            method.EmitSemicolon(true);

            //_assignment.CopyTo(temp, 0);
            method.EmitIdentifier(name);
            method.EmitPeriod();
            method.EmitIdentifier("CopyTo");
            using (var par = method.EmitParenthesis())
            {
                par.EmitIdentifier("temp");
                par.EmitComma();
                par.EmitIntValue(0);
            }
            method.EmitSemicolon(true);

            //for (int i = 0; i < temp.Length; i++)
            using (var par = method.EmitFor())
            {
                par.EmitInt();
                par.EmitIdentifier("i");
                par.EmitAssignment();
                par.EmitIntValue(0);
                par.EmitSemicolon(false);
                par.EmitIdentifier("i");
                par.EmitLessThan();
                par.EmitIdentifier("temp");
                par.EmitPeriod();
                par.EmitIdentifier("Length");
                par.EmitSemicolon(false);
                par.EmitIdentifier("i");
                par.EmitPlusPlus();
            }
            method.EmitNewLine();

            //    yield return temp[i];
            method.IncreaseIndentation();
            method.EmitYield();
            method.EmitReturn();
            method.EmitIdentifier("temp");
            using (var square = method.EmitParenthesis(ParenthesisElement.Types.Square))
                square.EmitIdentifier("i");
            method.EmitSemicolon(true);
            method.DecreaseIndentation();

            method.EmitBlockEnd();
        }
    }
}
