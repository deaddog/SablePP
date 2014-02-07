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

        /// <summary>
        /// Represents a list of nodes listed in a <see cref="Production"/> node.
        /// This type is used to represent [item]* and [item]+ elements in productions.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        public class NodeList<T> : IList<T> where T : Node
        {
            private Production parent;
            private List<T> list;
            private bool emptyAllowed;

            /// <summary>
            /// Initializes a new instance of the <see cref="NodeList{T}"/> class.
            /// </summary>
            /// <param name="parent">The <see cref="Production"/> node that will contain this <see cref="NodeList{T}"/>.</param>
            /// <param name="emptyAllowed">if set to <c>true</c> this element can be empty (an [item]* element); otherwise it cannot (an [item]+ element).</param>
            public NodeList(Production parent, bool emptyAllowed)
            {
                if (parent == null)
                    throw new ArgumentNullException("parent");

                this.parent = parent;
                this.emptyAllowed = emptyAllowed;
                this.list = new List<T>();
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="NodeList{T}"/> class that contains elements copied from the specified <see cref="IEnumerable{T}"/>.
            /// </summary>
            /// <param name="parent">The <see cref="Production"/> node that will contain this <see cref="NodeList{T}"/>.</param>
            /// <param name="collection">The <see cref="IEnumerable{T}"/> whose elements are copied to the new <see cref="ScopedDictionary{TKey, TValue}"/>.</param>
            /// <param name="emptyAllowed">if set to <c>true</c> this element can be empty (an [item]* element); otherwise it cannot (an [item]+ element).</param>
            public NodeList(Production parent, IEnumerable<T> collection, bool emptyAllowed)
                : this(parent, emptyAllowed)
            {
                AddRange(collection);
            }

            /// <summary>
            /// Returns a <see cref="System.String"/> that is a list of the string representation of all elements contained by this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
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

            /// <summary>
            /// Adds a collection of items the end of this <see cref="NodeList{T}"/>.
            /// </summary>
            /// <param name="collection">The <see cref="IEnumerable{T}"/> whose elements are added to the end of the list.</param>
            public void AddRange(IEnumerable<T> collection)
            {
                foreach (var t in collection)
                    Add(t);
            }

            #region IList<T> Members

            /// <summary>
            /// Determines the index of a specific node in the <see cref="NodeList{T}"/>.
            /// </summary>
            /// <param name="item">The object to locate in the <see cref="NodeList{T}"/>.</param>
            /// <returns>
            /// The index of <paramref name="item" /> if found in the list; otherwise, -1.
            /// </returns>
            public int IndexOf(T item)
            {
                return list.IndexOf(item);
            }

            /// <summary>
            /// Inserts a node in the <see cref="NodeList{T}"/> at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
            /// <param name="item">The node to insert into the <see cref="NodeList{T}"/>.</param>
            public void Insert(int index, T item)
            {
                SetParent(item, parent);
                list.Insert(index, item);
            }

            /// <summary>
            /// Removes the node at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index of the item to remove.</param>
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

            /// <summary>
            /// Gets or sets the node at the specified index.
            /// </summary>
            /// <param name="index">The index.</param>
            /// <returns>The <typeparamref name="T"/> located at <paramref name="index"/> in the <see cref="NodeList{T}"/>.</returns>
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

            /// <summary>
            /// Adds a node to the <see cref="NodeList{T}"/>.
            /// </summary>
            /// <param name="item">The node to add to the <see cref="NodeList{T}"/>.</param>
            public void Add(T item)
            {
                Insert(list.Count, item);
            }

            /// <summary>
            /// Removes all items from the <see cref="NodeList{T}"/>.
            /// </summary>
            public void Clear()
            {
                while (list.Count > 0)
                    RemoveAt(0);
            }

            /// <summary>
            /// Determines whether the <see cref="NodeList{T}"/> contains a specific node.
            /// </summary>
            /// <param name="item">The <typeparamref name="T"/> node to locate in the <see cref="NodeList{T}"/>.</param>
            /// <returns>
            /// true if <paramref name="item" /> is found in the <see cref="NodeList{T}"/>; otherwise, false.
            /// </returns>
            public bool Contains(T item)
            {
                return list.Contains(item);
            }

            /// <summary>
            /// Copies the elements of the <see cref="NodeList{T}"/> to a <see cref="System.Array"/>, starting at a particular index.
            /// </summary>
            /// <param name="array">The one-dimensional System.Array that is the destination of the elements <see cref="NodeList{T}"/>. The System.Array must have zero-based indexing.</param>
            /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
            public void CopyTo(T[] array, int arrayIndex)
            {
                list.CopyTo(array, arrayIndex);
            }

            /// <summary>
            /// Gets the number of elements contained in the <see cref="NodeList{T}"/>.
            /// </summary>
            public int Count
            {
                get { return list.Count; }
            }

            bool ICollection<T>.IsReadOnly
            {
                get { return false; }
            }

            /// <summary>
            /// Removes the first occurrence of a specific node from the <see cref="NodeList{T}"/>.
            /// </summary>
            /// <param name="item">The node to remove from the <see cref="NodeList{T}"/>.</param>
            /// <returns>
            /// true if <paramref name="item" /> was successfully removed from the <see cref="NodeList{T}"/>; otherwise, false.
            /// </returns>
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
