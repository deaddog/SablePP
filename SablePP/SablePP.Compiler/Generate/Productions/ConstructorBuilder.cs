using System;

using SablePP.Tools.Generate.CSharp;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Generate.Productions
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
            classElement.Add(constructor = new MethodElement("public {0}()", true, classElement.Name));
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
            TIdentifier typeId = node.PElementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));

            if (list)
            {
                constructor.Parameters.Add("IEnumerable<{0}> {1}", type, GetFieldName(node));
                constructor.Body.EmitLine("this.{0} = new NodeList<{1}>(this, {0}, {2});", GetFieldName(node), type, node is AStarElement ? "true" : "false");
            }
            else
            {
                constructor.Parameters.Add("{0} {1}", type, GetFieldName(node));
                constructor.Body.EmitLine("this.{0} = {1};", GetPropertyName(node), GetFieldName(node));
            }
        }
    }
}
