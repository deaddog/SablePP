using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools
{
    /// <summary>
    /// A dictionary that allows the use of scoping for storing key/value pairs.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class ScopedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private Stack<Dictionary<TKey, TValue>> stack;
        private KeyCollection keys;
        private ValueCollection values;

        private int count = 0;

        public ScopedDictionary()
            : this(new Dictionary<TKey, TValue>())
        {
        }
        public ScopedDictionary(IDictionary<TKey, TValue> dictionary)
            : this(new Dictionary<TKey, TValue>(dictionary))
        {
        }
        public ScopedDictionary(IEqualityComparer<TKey> comparer)
            : this(new Dictionary<TKey, TValue>(comparer))
        {
        }
        public ScopedDictionary(int capacity)
            : this(new Dictionary<TKey, TValue>(capacity))
        {
        }
        public ScopedDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
            : this(new Dictionary<TKey, TValue>(dictionary, comparer))
        {
        }
        public ScopedDictionary(int capacity, IEqualityComparer<TKey> comparer)
            : this(new Dictionary<TKey, TValue>(comparer))
        {
        }

        public ScopedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
            : this(collection.ToDictionary(k => k.Key, k => k.Value))
        {
        }

        public ScopedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
            : this(collection.ToDictionary(k => k.Key, k => k.Value), comparer)
        {

        }

        protected ScopedDictionary(Dictionary<TKey, TValue> rootDictionary)
        {
            if (rootDictionary == null)
                throw new ArgumentNullException("rootDictionary");

            this.stack = new Stack<Dictionary<TKey, TValue>>();
            this.stack.Push(rootDictionary);

            this.keys = new KeyCollection(this);
            this.values = new ValueCollection(this);
        }

        /// <summary>
        /// Opens a new scope, allowing all keys to be reused.
        /// </summary>
        public void OpenScope()
        {
            stack.Push(new Dictionary<TKey, TValue>());
        }

        /// <summary>
        /// Closes the top-most scope, removing all key/value pairs defined in that scope.
        /// Keys in lower scopes are not removed.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Cannot close the outermost scope in a ScopedDictionary.</exception>
        public void CloseScope()
        {
            if (stack.Count == 0)
                throw new InvalidOperationException("Cannot close the outermost scope in a ScopedDictionary.");
            else
                stack.Pop();
        }

        #region IDictionary<TKey,TValue> Members

        public void Add(TKey key, TValue value)
        {
            if (!ContainsKey(key, false))
                count++;

            stack.Peek().Add(key, value);
        }

        bool IDictionary<TKey, TValue>.ContainsKey(TKey key)
        {
            return ContainsKey(key, false);
        }
        public bool ContainsKey(TKey key, bool currentScopeOnly)
        {
            if (currentScopeOnly)
                return stack.Peek().ContainsKey(key);

            foreach (var d in stack)
                if (d.ContainsKey(key))
                    return true;

            return false;
        }

        public KeyCollection Keys
        {
            get { return keys; }
        }
        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get { return keys; }
        }

        public bool Remove(TKey key)
        {
            bool removed = false;

            foreach (var d in stack)
                if (d.Remove(key))
                    removed = true;

            if (removed)
                count--;

            return removed;
        }

        bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
        {
            return TryGetValue(key, out value, false);
        }
        public bool TryGetValue(TKey key, out TValue value, bool currentScopeOnly)
        {
            if (currentScopeOnly)
                return stack.Peek().TryGetValue(key, out value);

            foreach (var d in stack)
                if (d.TryGetValue(key, out value))
                    return true;

            value = default(TValue);
            return false;
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
            get
            {
                if (key == null)
                    throw new ArgumentNullException("key");

                foreach (var d in stack)
                    if (d.ContainsKey(key))
                        return d[key];

                throw new KeyNotFoundException("The key \"" + key.ToString() + "\" was not found in either of the open scopes.");
            }
            set { stack.Peek()[key] = value; }
        }

        #endregion

        #region ICollection<KeyValuePair<TKey,TValue>> Members

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            count = 0;
            stack.Clear();
            stack.Push(new Dictionary<TKey, TValue>());
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            foreach (var d in stack)
                if ((d as ICollection<KeyValuePair<TKey, TValue>>).Contains(item))
                    return true;

            return false;
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            int i = 0;
            foreach (var key in keys)
                array[(i++) + arrayIndex] = new KeyValuePair<TKey, TValue>(key, this[key]);
        }

        public int Count
        {
            get { return count; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            bool removed = false;

            foreach (var d in stack)
                if ((d as ICollection<KeyValuePair<TKey, TValue>>).Remove(item))
                    removed = true;

            if (removed)
                count--;

            return removed;
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey,TValue>> Members

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            foreach (var k in keys)
                yield return new KeyValuePair<TKey, TValue>(k, this[k]);
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (var k in keys)
                yield return new KeyValuePair<TKey, TValue>(k, this[k]);
        }

        #endregion

        public sealed class KeyCollection : ICollection<TKey>
        {
            private ScopedDictionary<TKey, TValue> dictionary;

            public KeyCollection(ScopedDictionary<TKey, TValue> dictionary)
            {
                this.dictionary = dictionary;
            }

            #region ICollection<TKey> Members

            void ICollection<TKey>.Add(TKey item)
            {
                throw new InvalidOperationException("Cannot add keys directly to the Keys collection.");
            }

            void ICollection<TKey>.Clear()
            {
                throw new InvalidOperationException("Cannot clear keys directly in the Keys collection.");
            }

            bool ICollection<TKey>.Contains(TKey item)
            {
                return Contains(item, false);
            }
            public bool Contains(TKey key, bool currentScopeOnly)
            {
                return dictionary.ContainsKey(key, currentScopeOnly);
            }

            void ICollection<TKey>.CopyTo(TKey[] array, int arrayIndex)
            {
                CopyTo(array, arrayIndex, false);
            }
            public void CopyTo(TKey[] array, int arrayIndex, bool currentScopeOnly)
            {
                if (currentScopeOnly)
                    dictionary.stack.Peek().Keys.CopyTo(array, arrayIndex);
                else
                {
                    int i = 0;
                    foreach (var k in this)
                        array[(i++) + arrayIndex] = k;
                }
            }

            public int Count
            {
                get { return dictionary.count; }
            }

            public bool IsReadOnly
            {
                get { return true; }
            }

            bool ICollection<TKey>.Remove(TKey item)
            {
                throw new InvalidOperationException("Cannot remove keys directly from the Keys collection.");
            }

            #endregion

            #region IEnumerable<TKey> Members

            IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
            {
                List<TKey> yieldedKeys = new List<TKey>();
                foreach (var d in dictionary.stack)
                    foreach (var k in d.Keys)
                        if (!yieldedKeys.Contains(k))
                        {
                            yieldedKeys.Add(k);
                            yield return k;
                        }
            }

            #endregion

            #region IEnumerable Members

            IEnumerator IEnumerable.GetEnumerator()
            {
                return (this as IEnumerable<TKey>).GetEnumerator();
            }

            #endregion
        }
        public sealed class ValueCollection : ICollection<TValue>
        {
            private ScopedDictionary<TKey, TValue> dictionary;

            public ValueCollection(ScopedDictionary<TKey, TValue> dictionary)
            {
                this.dictionary = dictionary;
            }

            #region ICollection<TKey> Members

            void ICollection<TValue>.Add(TValue item)
            {
                throw new InvalidOperationException("Cannot add values directly to the Values collection.");
            }

            void ICollection<TValue>.Clear()
            {
                throw new InvalidOperationException("Cannot clear values directly in the Values collection.");
            }

            bool ICollection<TValue>.Contains(TValue item)
            {
                throw new InvalidOperationException("Cannot determine if a value is part of the collection.");
            }

            void ICollection<TValue>.CopyTo(TValue[] array, int arrayIndex)
            {
                CopyTo(array, arrayIndex, false);
            }
            public void CopyTo(TValue[] array, int arrayIndex, bool currentScopeOnly)
            {
                if (currentScopeOnly)
                    dictionary.stack.Peek().Values.CopyTo(array, arrayIndex);
                else
                {
                    int i = 0;
                    foreach (var k in dictionary.Keys)
                        array[(i++) + arrayIndex] = dictionary[k];
                }
            }

            public int Count
            {
                get { return dictionary.count; }
            }

            public bool IsReadOnly
            {
                get { return true; }
            }

            bool ICollection<TValue>.Remove(TValue item)
            {
                throw new InvalidOperationException("Cannot remove values directly from the Values collection.");
            }

            #endregion

            #region IEnumerable<TValue> Members

            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
            {
                List<TKey> yieldedKeys = new List<TKey>();
                foreach (var d in dictionary.stack)
                    foreach (var k in d)
                        if (!yieldedKeys.Contains(k.Key))
                        {
                            yieldedKeys.Add(k.Key);
                            yield return k.Value;
                        }
            }

            #endregion

            #region IEnumerable Members

            IEnumerator IEnumerable.GetEnumerator()
            {
                return (this as IEnumerable<TValue>).GetEnumerator();
            }

            #endregion
        }
    }
}
