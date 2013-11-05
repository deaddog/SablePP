using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sable.Tools.Nodes;

namespace Sable.Tools.Analysis
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
