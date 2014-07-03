using SablePP.Compiler.Generate.Productions;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Generate.Parsing
{
    public class SimpleReductionBuilder : ReductionBuilder
    {
        public override void CaseAAlternative(AAlternative node)
        {
            var elements = ProductionElement.GetAllElements(node);

            CreateNewCase();

            for (int i = elements.Length - 1; i >= 0; i--)
                Pop(elements[i]);

            code.EmitLine("{0} {1} = new {0} (", node.ClassName, GetVariable(node));
            code.IncreaseIndentation();

            for (int i = 0; i < elements.Length; i++)
            {
                string name = GetVariable(elements[i]);
                code.EmitLine("{0}{1}", name, i < elements.Length - 1 ? "," : "");
            }

            code.DecreaseIndentation();
            code.EmitLine(");");
        }

        private void Pop(ProductionElement node)
        {
            switch (node.ElementType)
            {
                case ElementTypes.Simple:
                    var name = GetVariable(node);
                    code.EmitLine("{0} {1} = Pop<{0}>();", node.ProductionOrTokenClass, GetVariable(node));
                    break;
            }
        }
    }
}
