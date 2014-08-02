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
    }
}
