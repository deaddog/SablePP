using System;
using System.Collections.Generic;
using System.Text;

namespace SablePP.Tools.Nodes
{
    /// <summary>
    /// Represents a production (an inner node) in an AST.
    /// </summary>
    /// <typeparam name="T">The type of the base production.</typeparam>
    public abstract class Production<T> : Production where T : Production
    {
        /// <summary>
        /// Clones this instance and returns an element of type <typeparamref name="T"/>.
        /// </summary>
        /// <returns>A new <typeparamref name="T"/> production element that is a copy of this instance.</returns>
        public abstract T Clone();
        /// <summary>
        /// Creates a new <see cref="Node"/> object that is a copy of this instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="Node"/> object that is a copy of this instance.
        /// </returns>
        public override Node CloneNode()
        {
            return Clone();
        }
        /// <summary>
        /// Replaces this <see cref="Production{T}"/> element by another node in its parent <see cref="Production"/> if one exists.
        /// </summary>
        /// <param name="node">The node to replace this node with.</param>
        public void ReplaceBy(T node)
        {
            if (this.GetParent() != null)
                this.GetParent().ReplaceChild(this, node);
        }
    }

    /// <summary>
    /// Represents a production (an inner node) in an AST.
    /// </summary>
    public abstract class Production : Node
    {
        /// <summary>
        /// Replaces a child node in this <see cref="Production"/> by another child node.
        /// </summary>
        /// <param name="oldChild">The old child node.</param>
        /// <param name="newChild">The new child node.</param>
        public abstract void ReplaceChild(Node oldChild, Node newChild);

        /// <summary>
        /// Gets all children associated with this node in order.
        /// </summary>
        /// <returns></returns>
        protected internal abstract IEnumerable<Node> GetChildren();

        public class NodeList<T> : IList<T> where T : Node
        {
            private Production parent;
            private List<T> list;
            private bool emptyAllowed;

            public NodeList(Production parent, bool emptyAllowed)
            {
                if (parent == null)
                    throw new ArgumentNullException("parent");

                this.parent = parent;
                this.emptyAllowed = emptyAllowed;
                this.list = new List<T>();
            }

            public NodeList(Production parent, IEnumerable<T> collection, bool emptyAllowed)
                : this(parent, emptyAllowed)
            {
                AddRange(collection);
            }

            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i > 0)
                        builder.Append(" ");
                    builder.Append(list[i]);
                }
                return builder.ToString();
            }

            public void AddRange(IEnumerable<T> collection)
            {
                foreach (var t in collection)
                    Add(t);
            }

            #region IList<T> Members

            public int IndexOf(T item)
            {
                return list.IndexOf(item);
            }

            public void Insert(int index, T item)
            {
                SetParent(item, parent);
                list.Insert(index, item);
            }

            public void RemoveAt(int index)
            {
                if (index < 0 || index >= list.Count)
                    throw new ArgumentOutOfRangeException("index");
                else
                {
                    T obj = list[index];
                    SetParent(obj, null);
                    RemoveAt(index);
                }
            }

            public T this[int index]
            {
                get { return list[index]; }
                set
                {
                    RemoveAt(index);
                    Insert(index, value);
                }
            }

            #endregion

            #region ICollection<T> Members

            public void Add(T item)
            {
                Insert(list.Count, item);
            }

            public void Clear()
            {
                while (list.Count > 0)
                    RemoveAt(0);
            }

            public bool Contains(T item)
            {
                return list.Contains(item);
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                list.CopyTo(array, arrayIndex);
            }

            public int Count
            {
                get { return list.Count; }
            }

            bool ICollection<T>.IsReadOnly
            {
                get { return false; }
            }

            public bool Remove(T item)
            {
                int index = IndexOf(item);
                if (index == -1)
                    return false;
                else
                {
                    RemoveAt(index);
                    return true;
                }
            }

            #endregion

            #region IEnumerable<T> Members

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                foreach (var t in list)
                    yield return t;
            }

            #endregion

            #region IEnumerable Members

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                foreach (var t in list)
                    yield return t;
            }

            #endregion
        }
    }
}
