using System;

namespace Sable.Tools.Nodes
{
    public abstract class Node : ICloneable
    {
        private Production parent;
        public Production GetParent()
        {
            return parent;
        }

        protected static void SetParent(Node node, Production parent)
        {
            node.parent = parent;
        }

        public abstract Node CloneNode();
        object ICloneable.Clone()
        {
            return CloneNode();
        }
    }
}
