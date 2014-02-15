using System;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate;
using SablePP.Tools.Generate.CSharp;

namespace SablePP.Compiler.Generate.Productions
{
    public class ToStringMethodBuilder : ProductionVisitor
    {
        private ClassElement classElement;
        private MethodElement method;
        private PatchElement parenthesis;
        private bool first = true;

        private string buildingString = "";
        private int count = 0;

        public ToStringMethodBuilder(ClassElement classElement)
        {
            this.classElement = classElement;
        }

        public override void CaseAAlternative(AAlternative node)
        {
            classElement.Add(method = new MethodElement("public override string ToString()"));

            parenthesis = new PatchElement();

            method.Body.Emit("return string.Format(");
            method.Body.InsertElement(parenthesis);
            method.Body.EmitLine(");");

            base.CaseAAlternative(node);
            parenthesis.Emit("\"{0}\"", buildingString);

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
                parenthesis.Emit(", {0}", GetFieldName(node));

            count++;
        }
    }
}
