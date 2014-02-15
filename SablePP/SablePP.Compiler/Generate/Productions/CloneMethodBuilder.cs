using System;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate;
using SablePP.Tools.Generate.CSharp;

namespace SablePP.Compiler.Generate.Productions
{
    public class CloneMethodBuilder : ProductionVisitor
    {
        private ClassElement classElement;
        private readonly string implements;
        private MethodElement method;
        private PatchElement parenthesis;
        private bool first = true;

        public CloneMethodBuilder(ClassElement classElement, string implements)
        {
            this.classElement = classElement;
            this.implements = implements;
        }

        public override void InAAlternative(AAlternative node)
        {
            classElement.Add(method = new MethodElement("public override " + implements + " Clone()"));

            parenthesis = new PatchElement();

            method.Body.Emit("return new {0}(", classElement.Name);
            method.Body.InsertElement(parenthesis);
            method.Body.EmitLine(");");

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
                parenthesis.Emit(", ");
            else
                first = false;

            parenthesis.Emit(GetFieldName(node));
            if (!list)
                parenthesis.Emit(".Clone()");
        }
    }
}
