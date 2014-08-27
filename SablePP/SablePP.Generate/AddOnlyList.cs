using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate
{
    public class AddOnlyList<T>
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
        }
        public void AddRange(IEnumerable<T> items)
        {
            innerList.AddRange(items);
        }
        public void Insert(int index, T item)
        {
            innerList.Insert(index, item);
        }
    }
}
