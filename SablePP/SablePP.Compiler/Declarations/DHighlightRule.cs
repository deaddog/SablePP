using SablePP.Compiler.Nodes;
using System;

namespace SablePP.Compiler
{
    public class DHighlightRule : Declaration
    {
        public DHighlightRule(AHighlightrule node)
            : base(node.Name)
        {
        }

        public override string ToString()
        {
            return "S:" + base.ToString();
        }
    }
}
