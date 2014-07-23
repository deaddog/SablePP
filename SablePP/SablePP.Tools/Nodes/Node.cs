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
        /// Traverses the tree from this <see cref="Node"/> and up, until a <see cref="Production"/> of type <typeparamref name="T"/> is found.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Production"/> node to find.</typeparam>
        /// <returns>The first <see cref="Production"/> node of type <typeparamref name="T"/> found in the search; or <c>null</c> is no node is found.</returns>
        public T GetFirstParent<T>() where T : Production
        {
            if (parent == null || parent is T)
                return parent as T;
            else
                return parent.GetFirstParent<T>();
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
