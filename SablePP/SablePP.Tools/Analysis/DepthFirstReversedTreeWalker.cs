using System;
using System.Linq;

using SablePP.Tools.Nodes;

namespace SablePP.Tools.Analysis
{
    public class DepthFirstReversedTreeWalker : TreeWalker
    {
        public override void Visit(Token token)
        {
        }
        public override void Visit(Production production)
        {
            foreach (Node node in production.GetChildren().Reverse())
                Visit(node);
        }
    }
}
