using SablePP.Compiler.Nodes;
using SablePP.Tools.Error;

namespace SablePP.Compiler.Validation
{
    public class ExcessiveNodesVisitor : ErrorVisitor
    {
        public ExcessiveNodesVisitor(ErrorManager errorManager)
            : base(errorManager)
        {
        }

        protected override void HandlePProdtranslation(PProdtranslation node)
        {
            var prod = node.GetFirstParent<PProduction>();
            var prodA = node.Identifier.AsPProduction;

            if (prod != null && prodA != null && prod.ClassName == prodA.ClassName)
                RegisterMessage(node, "It is not required to add a production translation for \"{0} -> {0}\".", node.Identifier.Text);

            base.HandlePProdtranslation(node);
        }
    }
}
