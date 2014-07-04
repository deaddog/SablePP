using SablePP.Compiler.Generate.Productions;
using SablePP.Compiler.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Compiler.Generate.Parsing
{
    public class SimpleReductionBuilder : ReductionBuilder
    {
        private List<ProductionElement> questions;
        private int caseCounter;

        public override void CaseAAlternative(AAlternative node)
        {
            var elements = ProductionElement.GetAllElements(node);

            this.questions = elements.Where(x => x.ElementType == ElementTypes.Question).ToList();

            int max = 1 << questions.Count;
            for (caseCounter = 0; caseCounter < max; caseCounter++)
            {
                CreateNewCase();

                for (int i = elements.Length - 1; i >= 0; i--)
                    Pop(elements[i]);

                code.EmitLine("{0} {1} = new {0} (", node.ClassName, GetVariable(node));
                code.IncreaseIndentation();

                for (int i = 0; i < elements.Length; i++)
                {
                    string name = GetVariable(elements[i]);
                    if (elements[i].ElementType == ElementTypes.Question && ((1 << questions.IndexOf(elements[i])) & caseCounter) == 0)
                        name = "null";

                    code.EmitLine("{0}{1}", name, i < elements.Length - 1 ? "," : "");
                }

                code.DecreaseIndentation();
                code.EmitLine(");");

                code.EmitLine("Push({0}, {1});", GoTo, GetVariable(node));
            }
        }

        private void Pop(ProductionElement node)
        {
            switch (node.ElementType)
            {
                case ElementTypes.Simple:
                    var name = GetVariable(node);
                    code.EmitLine("{0} {1} = Pop<{0}>();", node.ProductionOrTokenClass, GetVariable(node));
                    break;

                case ElementTypes.Question:
                    int index = 1 << questions.IndexOf(node);
                    if ((index & caseCounter) > 0)
                        code.EmitLine("{0} {1} = Pop<{0}>();", node.ProductionOrTokenClass, GetVariable(node));
                    break;
            }
        }
    }
}
