using System;

using SablePP.Tools.Generate.CSharp;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Generate.Productions
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
            classElement.Add(method = new MethodElement("public override void ReplaceChild(Node {0}, Node {1})", true, oldChild, newChild));

            base.InAAlternative(node);
        }
        public override void OutAAlternative(AAlternative node)
        {
            base.OutAAlternative(node);

            method.Body.EmitLine("throw new ArgumentException(\"Node to be replaced is not a child in this production.\";");
        }

        public override void CaseASimpleElement(ASimpleElement node)
        {
            TIdentifier typeId = node.Elementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));

            method.Body.EmitLine("if ({0} == {1})", GetPropertyName(node), oldChild);
            method.Body.EmitLine("{");
            method.Body.IncreaseIndentation();

            method.Body.EmitLine("if ({0} == null)", newChild);
            method.Body.IncreaseIndentation();
            method.Body.EmitLine("throw new ArgumentException(\"{0} in {1} cannot be null.\");", GetPropertyName(node), classElement.Name);
            method.Body.DecreaseIndentation();

            method.Body.EmitLine("if (!({0} is {1}) && {0} != null)", newChild, type);
            method.Body.IncreaseIndentation();
            method.Body.EmitLine("throw new ArgumentException(\"Child replaced must be of same type as child being replaced with.\");");
            method.Body.DecreaseIndentation();

            method.Body.EmitLine("{0} = {1} as {2};", GetPropertyName(node), newChild, type);

            method.Body.DecreaseIndentation();
            method.Body.EmitLine("}");
            method.Body.Emit("else");
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            TIdentifier typeId = node.Elementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));

            method.Body.EmitLine("if ({0} == {1})", GetPropertyName(node), oldChild);
            method.Body.EmitLine("{");
            method.Body.IncreaseIndentation();

            method.Body.EmitLine("if (!({0} is {1}) && {0} != null)", newChild, type);
            method.Body.IncreaseIndentation();
            method.Body.EmitLine("throw new ArgumentException(\"Child replaced must be of same type as child being replaced with.\");");
            method.Body.DecreaseIndentation();

            method.Body.EmitLine("{0} = {1} as {2};", GetPropertyName(node), newChild, type);

            method.Body.DecreaseIndentation();
            method.Body.EmitLine("}");
            method.Body.Emit("else");
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
            TIdentifier typeId = node.PElementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));

            method.Body.EmitLine("{");
            method.Body.IncreaseIndentation();

            method.Body.EmitLine("if ({0} is {1} && {2}.Contains({0} as {1}))", oldChild, type, GetFieldName(node));
            method.Body.IncreaseIndentation();
            method.Body.EmitLine("throw new ArgumentException(\"Child replaced must be of same type as child being replaced with.\");");
            method.Body.DecreaseIndentation();
            method.Body.EmitNewLine();

            method.Body.EmitLine("int index = {0}.IndexOf({1} as {2});", GetFieldName(node), oldChild, type);
            method.Body.EmitLine("if ({0} == null)", newChild);
            method.Body.IncreaseIndentation();
            method.Body.EmitLine("{0}.RemoveAt(index);", GetFieldName(node));
            method.Body.DecreaseIndentation();

            method.Body.EmitLine("else");
            method.Body.IncreaseIndentation();
            method.Body.EmitLine("{0}[index] = {1} as {2};", GetFieldName(node), newChild, type);
            method.Body.DecreaseIndentation();

            method.Body.DecreaseIndentation();
            method.Body.EmitLine("}");
            method.Body.Emit("else");
        }
    }
}
