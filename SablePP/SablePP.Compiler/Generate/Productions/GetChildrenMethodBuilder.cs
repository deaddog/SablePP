using System;

using SablePP.Tools.Generate.CSharp;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Generate.Productions
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
            classElement.Add(method = new MethodElement("protected override IEnumerable<Node> GetChildren()"));

            base.InAAlternative(node);
        }

        public override void CaseASimpleElement(ASimpleElement node)
        {
            method.Body.EmitLine("yield return {0};", GetFieldName(node));
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            method.Body.EmitLine("if (Has{0})", ToCamelCase(node.LowerName));
            method.Body.IncreaseIndentation();
            method.Body.EmitLine("yield return {0};", GetFieldName(node));
            method.Body.DecreaseIndentation();
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
            method.Body.EmitLine("{");
            method.Body.IncreaseIndentation();

            method.Body.EmitLine("{0}[] temp = new {0}[{1}.Count];", type, name);
            method.Body.EmitLine("{0}.CopyTo(temp, 0)", name);
            method.Body.EmitLine("for (int i = 0; i < temp.Length; i++)");
            method.Body.IncreaseIndentation();
            method.Body.EmitLine("yield return temp[i];");
            method.Body.DecreaseIndentation();

            method.Body.DecreaseIndentation();
            method.Body.EmitLine("}");
        }
    }
}
