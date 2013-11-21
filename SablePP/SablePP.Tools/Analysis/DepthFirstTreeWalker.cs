using System;

using SablePP.Tools.Nodes;

namespace SablePP.Tools.Analysis
{
    public class DepthFirstTreeWalker : TreeWalker
    {
        public override void Visit(Token token)
        {
        }
        public override void Visit(Production production)
        {
            foreach (Nodes.Node node in production.GetChildren())
                Visit(node);
        }
    }
}
