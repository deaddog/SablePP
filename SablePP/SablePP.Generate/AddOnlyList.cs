using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate
{
    public class AddOnlyList<T> : IEnumerable<T>
    {
        private List<T> innerList;

        public AddOnlyList()
        {
            this.innerList = new List<T>();
        }
        public AddOnlyList(IEnumerable<T> items)
        {
            this.innerList = new List<T>(items);
        }

        internal event EventHandler<AddEventArgs> ItemAdded;

        public int Count
        {
            get { return innerList.Count; }
        }

        public T this[int index]
        {
            get { return innerList[index]; }
        }

        public void Add(T item)
        {
            innerList.Add(item);

            if (ItemAdded != null)
                ItemAdded(this, new AddEventArgs(item));
        }
        public void AddRange(IEnumerable<T> items)
        {
            foreach (var e in items)
                Add(e);
        }
        public void Insert(int index, T item)
        {
            innerList.Insert(index, item);

            if (ItemAdded != null)
                ItemAdded(this, new AddEventArgs(item));
        }
        public void InsertRange(int index, IEnumerable<T> items)
        {
            foreach (var e in items)
                Insert(index++, e);
        }

        internal class AddEventArgs : EventArgs
        {
            private T item;

            public AddEventArgs(T item)
            {
                this.item = item;
            }

            public T Item
            {
                get { return item; }
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var item in innerList)
                yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (var item in innerList)
                yield return item;
        }
    }
}
