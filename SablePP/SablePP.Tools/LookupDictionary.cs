using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sable.Tools
{
    public class LookupDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dictionary;
        private KeyCollection keys;
        private ValueCollection values;

        public LookupDictionary()
            : this(new Dictionary<TKey, TValue>())
        {
        }
        public LookupDictionary(IDictionary<TKey, TValue> dictionary)
            : this(new Dictionary<TKey, TValue>(dictionary))
        {
        }
        public LookupDictionary(IEqualityComparer<TKey> comparer)
            : this(new Dictionary<TKey, TValue>(comparer))
        {
        }
        public LookupDictionary(int capacity)
            : this(new Dictionary<TKey, TValue>(capacity))
        {
        }
        public LookupDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
            : this(new Dictionary<TKey, TValue>(dictionary, comparer))
        {
        }
        public LookupDictionary(int capacity, IEqualityComparer<TKey> comparer)
            : this(new Dictionary<TKey, TValue>(comparer))
        {
        }

        public LookupDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
            : this(collection.ToDictionary(k => k.Key, k => k.Value))
        {
        }

        protected LookupDictionary(Dictionary<TKey, TValue> rootDictionary)
        {
            this.dictionary = rootDictionary;

            this.keys = new KeyCollection(this);
            this.values = new ValueCollection(this);
        }

        #region IDictionary<TKey,TValue> Members

        void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
        {
            throw new InvalidOperationException();
        }

        public bool ContainsKey(TKey key)
        {
            return dictionary.ContainsKey(key);
        }

        public KeyCollection Keys
        {
            get { return keys; }
        }
        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get { return keys; }
        }

        bool IDictionary<TKey, TValue>.Remove(TKey key)
        {
            throw new InvalidOperationException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return dictionary.TryGetValue(key, out value);
        }

        public ValueCollection Values
        {
            get { return values; }
        }
        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get { return values; }
        }

        public TValue this[TKey key]
        {
            get { return dictionary[key]; }
        }
        TValue IDictionary<TKey, TValue>.this[TKey key]
        {
            get { return this[key]; }
            set { throw new InvalidOperationException(); }
        }

        #endregion

        #region ICollection<KeyValuePair<TKey,TValue>> Members

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            throw new InvalidOperationException();
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Clear()
        {
            throw new InvalidOperationException();
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            return dictionary.ContainsKey(item.Key) && dictionary[item.Key].Equals(item.Value);
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            int i = 0;
            foreach (var item in dictionary)
                array[(i++) + arrayIndex] = new KeyValuePair<TKey, TValue>(item.Key, item.Value);
        }

        public int Count
        {
            get { return dictionary.Count; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return true; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new InvalidOperationException();
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey,TValue>> Members

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        #endregion

        public sealed class KeyCollection : ICollection<TKey>
        {
            private LookupDictionary<TKey, TValue> dictionary;

            public KeyCollection(LookupDictionary<TKey, TValue> dictionary)
            {
                this.dictionary = dictionary;
            }

            #region ICollection<TKey> Members

            void ICollection<TKey>.Add(TKey item)
            {
                throw new InvalidOperationException();
            }

            void ICollection<TKey>.Clear()
            {
                throw new InvalidOperationException();
            }

            public bool Contains(TKey item)
            {
                return dictionary.dictionary.ContainsKey(item);
            }

            public void CopyTo(TKey[] array, int arrayIndex)
            {
                dictionary.dictionary.Keys.CopyTo(array, arrayIndex);
            }

            public int Count
            {
                get { return dictionary.Count; }
            }

            bool ICollection<TKey>.IsReadOnly
            {
                get { return true; }
            }

            bool ICollection<TKey>.Remove(TKey item)
            {
                throw new InvalidOperationException();
            }

            #endregion

            #region IEnumerable<TKey> Members

            public IEnumerator<TKey> GetEnumerator()
            {
                return dictionary.dictionary.Keys.GetEnumerator();
            }

            #endregion

            #region IEnumerable Members

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return dictionary.dictionary.Keys.GetEnumerator();
            }

            #endregion
        }
        public sealed class ValueCollection : ICollection<TValue>
        {
            private LookupDictionary<TKey, TValue> dictionary;

            public ValueCollection(LookupDictionary<TKey, TValue> dictionary)
            {
                this.dictionary = dictionary;
            }

            #region ICollection<TValue> Members

            void ICollection<TValue>.Add(TValue item)
            {
                throw new InvalidOperationException();
            }

            void ICollection<TValue>.Clear()
            {
                throw new InvalidOperationException();
            }

            public bool Contains(TValue item)
            {
                return dictionary.dictionary.ContainsValue(item);
            }

            public void CopyTo(TValue[] array, int arrayIndex)
            {
                dictionary.dictionary.Values.CopyTo(array, arrayIndex);
            }

            public int Count
            {
                get { return dictionary.Count; }
            }

            bool ICollection<TValue>.IsReadOnly
            {
                get { return true; }
            }

            bool ICollection<TValue>.Remove(TValue item)
            {
                throw new InvalidOperationException();
            }

            #endregion

            #region IEnumerable<TValue> Members

            public IEnumerator<TValue> GetEnumerator()
            {
                return dictionary.dictionary.Values.GetEnumerator();
            }

            #endregion

            #region IEnumerable Members

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return dictionary.dictionary.Values.GetEnumerator();
            }

            #endregion
        }
    }
}
