using System;

using Sable.Tools.Generate.CSharp;
using Sable.Compiler.Nodes;

namespace Sable.Compiler.Generate.Productions
{
    public class ReplaceMethodBuilder : ProductionVisitor
    {
        private static readonly string newChild = "newChild";
        private static readonly string oldChild = "oldChild";

        private ClassElement classElement;
        private MethodElement method;

        public ReplaceMethodBuilder(ClassElement classElement)
        {
            this.classElement = classElement;
        }

        public override void InAAlternative(AAlternative node)
        {
            method = classElement.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "ReplaceChild", "void");
            method.Parameters.Add(oldChild, "Node");
            method.Parameters.Add(newChild, "Node");

            base.InAAlternative(node);
        }
        public override void OutAAlternative(AAlternative node)
        {
            base.OutAAlternative(node);
            method.EmitThrow();
            method.EmitNew();
            method.EmitIdentifier("ArgumentException");
            using (var par = method.EmitParenthesis())
                par.EmitStringValue("Node to be replaced is not a child in this production.");
            method.EmitSemicolon(true);
        }

        public override void CaseASimpleElement(ASimpleElement node)
        {
            TIdentifier typeId = node.GetElementid().Identifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));

            using (var par = method.EmitIf())
            {
                par.EmitIdentifier(GetPropertyName(node));
                par.EmitEqual();
                par.EmitIdentifier(oldChild);
            }
            method.EmitBlockStart();
            /*
                if (newChild == null)
                    throw new ArgumentException("Assign in assignment cannot be null.");*/
            using (var par = method.EmitIf())
            {
                par.EmitIdentifier(newChild);
                par.EmitEqual();
                par.EmitNull();
            }
            method.EmitNewLine();
            method.IncreaseIndentation();
            method.EmitThrow();
            method.EmitNew();
            method.EmitIdentifier("ArgumentException");
            using (var par = method.EmitParenthesis())
            {
                par.EmitStringValue(GetPropertyName(node) + " in " + classElement.Name + " cannot be null.");
                par.EmitComma();
                par.EmitStringValue(newChild);
            }
            method.EmitSemicolon(true);
            method.DecreaseIndentation();

            using (var ifPar = method.EmitIf())
            {
                ifPar.EmitLogicNot();
                using (var par = ifPar.EmitParenthesis())
                {
                    par.EmitIdentifier(newChild);
                    par.EmitIs();
                    par.EmitIdentifier(type);
                }
                ifPar.EmitLogicAnd();
                ifPar.EmitIdentifier(newChild);
                ifPar.EmitNotEqual();
                ifPar.EmitNull();
            }
            method.EmitNewLine();
            method.IncreaseIndentation();
            method.EmitThrow();
            method.EmitNew();
            method.EmitIdentifier("ArgumentException");
            using (var par = method.EmitParenthesis())
                par.EmitStringValue("Child replaced must be of same type as child being replaced with.");
            method.EmitSemicolon(true);
            method.DecreaseIndentation();
            method.EmitIdentifier(GetPropertyName(node));
            method.EmitAssignment();
            method.EmitIdentifier(newChild);
            method.EmitAs();
            method.EmitIdentifier(type);
            method.EmitSemicolon(true);

            method.EmitBlockEnd();
            method.EmitElse();
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            TIdentifier typeId = node.GetElementid().Identifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));

            using (var par = method.EmitIf())
            {
                par.EmitIdentifier(GetPropertyName(node));
                par.EmitEqual();
                par.EmitIdentifier(oldChild);
            }
            method.EmitBlockStart();
            using (var ifPar = method.EmitIf())
            {
                ifPar.EmitLogicNot();
                using (var par = ifPar.EmitParenthesis())
                {
                    par.EmitIdentifier(newChild);
                    par.EmitIs();
                    par.EmitIdentifier(type);
                }
                ifPar.EmitLogicAnd();
                ifPar.EmitIdentifier(newChild);
                ifPar.EmitNotEqual();
                ifPar.EmitNull();
            }
            method.EmitNewLine();
            method.IncreaseIndentation();
            method.EmitThrow();
            method.EmitNew();
            method.EmitIdentifier("ArgumentException");
            using (var par = method.EmitParenthesis())
                par.EmitStringValue("Child replaced must be of same type as child being replaced with.");
            method.EmitSemicolon(true);
            method.DecreaseIndentation();
            method.EmitIdentifier(GetPropertyName(node));
            method.EmitAssignment();
            method.EmitIdentifier(newChild);
            method.EmitAs();
            method.EmitIdentifier(type);
            method.EmitSemicolon(true);

            method.EmitBlockEnd();
            method.EmitElse();
        }

        public override void CaseAStarElement(AStarElement node)
        {
            EmitListElement(node);
        }
        public override void CaseAPlusElement(APlusElement node)
        {
            EmitListElement(node);
        }

        private void EmitListElement(PElement node)
        {
            TIdentifier typeId = node.Elementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));

            using (var par = method.EmitIf())
            {
                par.EmitIdentifier(oldChild);
                par.EmitIs();
                par.EmitIdentifier(type);
                par.EmitLogicAnd();
                par.EmitIdentifier(GetFieldName(node));
                par.EmitPeriod();
                par.EmitIdentifier("Contains");
                using (var argpar = par.EmitParenthesis())
                {
                    argpar.EmitIdentifier(oldChild);
                    argpar.EmitAs();
                    argpar.EmitIdentifier(type);
                }
            }
            method.EmitBlockStart();

            using (var ifPar = method.EmitIf())
            {
                ifPar.EmitLogicNot();
                using (var par = ifPar.EmitParenthesis())
                {
                    par.EmitIdentifier(newChild);
                    par.EmitIs();
                    par.EmitIdentifier(type);
                }
                ifPar.EmitLogicAnd();
                ifPar.EmitIdentifier(newChild);
                ifPar.EmitNotEqual();
                ifPar.EmitNull();
            }
            method.EmitNewLine();
            method.IncreaseIndentation();
            method.EmitThrow();
            method.EmitNew();
            method.EmitIdentifier("ArgumentException");
            using (var par = method.EmitParenthesis())
                par.EmitStringValue("Child replaced must be of same type as child being replaced with.");
            method.EmitSemicolon(true);
            method.DecreaseIndentation();
            method.EmitNewLine();

            method.EmitInt();
            method.EmitIdentifier("index");
            method.EmitAssignment();
            method.EmitIdentifier(GetFieldName(node));
            method.EmitPeriod();
            method.EmitIdentifier("IndexOf");
            using (var par = method.EmitParenthesis())
            {
                par.EmitIdentifier(oldChild);
                par.EmitAs();
                par.EmitIdentifier(type);
            }
            method.EmitSemicolon(true);
            using (var par = method.EmitIf())
            {
                par.EmitIdentifier(newChild);
                par.EmitEqual();
                par.EmitNull();
            }
            method.EmitNewLine();
            method.IncreaseIndentation();

            method.EmitIdentifier(GetFieldName(node));
            method.EmitPeriod();
            method.EmitIdentifier("RemoveAt");
            using (var par = method.EmitParenthesis())
                par.EmitIdentifier("index");
            method.EmitSemicolon(true);
            method.DecreaseIndentation();

            method.EmitElse();
            method.EmitNewLine();
            method.IncreaseIndentation();

            method.EmitIdentifier(GetFieldName(node));
            using (var par = method.EmitParenthesis(ParenthesisElement.Types.Square))
                par.EmitIdentifier("index");
            method.EmitAssignment();
            method.EmitIdentifier(newChild);
            method.EmitAs();
            method.EmitIdentifier(type);
            method.EmitSemicolon(true);
            method.DecreaseIndentation();

            method.EmitBlockEnd();
            method.EmitElse();
        }
    }
}
