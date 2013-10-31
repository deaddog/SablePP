using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sable.Tools.Nodes;

namespace Sable.Tools.Analysis
{
    public abstract class TreeWalker
    {
        public abstract void Visit(Token token);
        public abstract void Visit(Production production);
        public void Visit(Node node)
        {
            if (node is Token)
                Visit(node as Token);
            else if (node is Production)
                Visit(node as Production);
        }
    }
}
