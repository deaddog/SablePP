using System;
using System.Collections.Generic;
using System.Text;

namespace Sable.Tools.Nodes
{
    public abstract class Production<T> : Production where T : Production
    {
        public abstract T Clone();
        public override Node CloneNode()
        {
            return Clone();
        }

        public void ReplaceBy(T node)
        {
            if (this.GetParent() != null)
                this.GetParent().ReplaceChild(this, node);
        }
    }

    public abstract class Production : Node
    {
        public abstract void ReplaceChild(Node oldChild, Node newChild);

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
