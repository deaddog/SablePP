using System;

namespace SablePP.Tools.Nodes
{
    /// <summary>
    /// Represents a node in an AST.
    /// </summary>
    public abstract class Node : ICloneable
    {
        private Production parent;
        /// <summary>
        /// Gets the <see cref="Production"/> which this <see cref="Node"/> is a part of.
        /// </summary>
        /// <returns>A <see cref="Production"/> node that is the parent of this <see cref="Node"/>, or <c>null</c> if this is a root node.</returns>
        public Production GetParent()
        {
            return parent;
        }

        /// <summary>
        /// Sets the parent <see cref="Production"/> of a <see cref="Node"/>.
        /// </summary>
        /// <param name="node">The node whose parent <see cref="Production"/> is set.</param>
        /// <param name="parent">The parent <see cref="Production"/> node that should be the parent of <paramref name="node"/>, or <c>null</c> if <paramref name="node"/> is to be a root node.</param>
        protected static void SetParent(Node node, Production parent)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            node.parent = parent;
        }

        /// <summary>
        /// Creates a new <see cref="Node"/> object that is a copy of this instance.
        /// </summary>
        /// <returns>A new <see cref="Node"/> object that is a copy of this instance.</returns>
        public abstract Node CloneNode();
        object ICloneable.Clone()
        {
            return CloneNode();
        }
    }
}
