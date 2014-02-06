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
        private IEqualityComparer<TKey> comparer;
        private Stack<Dictionary<TKey, TValue>> stack;
        private KeyCollection keys;
        private ValueCollection values;

        private int count = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScopedDictionary{TKey, TValue}"/> class that is empty, has the default initial capacity, and uses the default equality comparer for the key type.
        /// </summary>
        public ScopedDictionary()
            : this(new Dictionary<TKey, TValue>(), null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScopedDictionary{TKey, TValue}"/> class that contains elements copied from the specified <see cref="IDictionary{TKey,TValue}"/> and uses the default equality comparer for the key type.
        /// </summary>
        /// <param name="dictionary">The <see cref="IDictionary{TKey,TValue}"/> whose elements are copied to the new <see cref="ScopedDictionary{TKey, TValue}"/>.</param>
        public ScopedDictionary(IDictionary<TKey, TValue> dictionary)
            : this(new Dictionary<TKey, TValue>(dictionary), null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScopedDictionary{TKey, TValue}"/> class that is empty, has the default initial capacity, and uses the specified <see cref="IEqualityComparer{TKey}"/>.
        /// </summary>
        /// <param name="comparer">The <see cref="IEqualityComparer{TKey}"/> implementation to use when comparing keys, or null to use the default <see cref="IEqualityComparer{TKey}"/> for the type of the key.</param>
        public ScopedDictionary(IEqualityComparer<TKey> comparer)
            : this(new Dictionary<TKey, TValue>(comparer), comparer)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScopedDictionary{TKey, TValue}"/> class that is empty, has the specified initial capacity, and uses the default equality comparer for the key type.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the <see cref="ScopedDictionary{TKey, TValue}"/> can contain.</param>
        public ScopedDictionary(int capacity)
            : this(new Dictionary<TKey, TValue>(capacity), null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScopedDictionary{TKey, TValue}"/> class that contains elements copied from the specified <see cref="IDictionary{TKey,TValue}"/> and uses the specified <see cref="IEqualityComparer{TKey}"/>.
        /// </summary>
        /// <param name="dictionary">The <see cref="IDictionary{TKey,TValue}"/> whose elements are copied to the new <see cref="ScopedDictionary{TKey, TValue}"/>.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{TKey}"/> implementation to use when comparing keys, or null to use the default <see cref="IEqualityComparer{TKey}"/> for the type of the key.</param>
        public ScopedDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
            : this(new Dictionary<TKey, TValue>(dictionary, comparer), comparer)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScopedDictionary{TKey, TValue}"/> class that is empty, has the specified initial capacity, and uses the specified <see cref="IEqualityComparer{TKey}"/>.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the <see cref="ScopedDictionary{TKey, TValue}"/> can contain.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{TKey}"/> implementation to use when comparing keys, or null to use the default <see cref="IEqualityComparer{TKey}"/> for the type of the key.</param>
        public ScopedDictionary(int capacity, IEqualityComparer<TKey> comparer)
            : this(new Dictionary<TKey, TValue>(comparer), comparer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScopedDictionary{TKey, TValue}"/> class that contains elements copied from the specified <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey,TValue}"/> and uses the specified <see cref="IEqualityComparer{TKey}"/>.
        /// </summary>
        /// <param name="collection">The <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey,TValue}"/> whose elements are copied to the new <see cref="ScopedDictionary{TKey, TValue}"/>.</param>
        public ScopedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
            : this(collection.ToDictionary(k => k.Key, k => k.Value), null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScopedDictionary{TKey, TValue}"/> class that contains elements copied from the specified <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey,TValue}"/> and uses the specified <see cref="IEqualityComparer{TKey}"/>.
        /// </summary>
        /// <param name="collection">The <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey,TValue}"/> whose elements are copied to the new <see cref="ScopedDictionary{TKey, TValue}"/>.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{TKey}"/> implementation to use when comparing keys, or null to use the default <see cref="IEqualityComparer{TKey}"/> for the type of the key.</param>
        public ScopedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
            : this(collection.ToDictionary(k => k.Key, k => k.Value), comparer)
        {

        }

        private ScopedDictionary(Dictionary<TKey, TValue> rootDictionary, IEqualityComparer<TKey> comparer)
        {
            if (rootDictionary == null)
                throw new ArgumentNullException("rootDictionary");
            this.comparer = comparer;

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
            stack.Push(new Dictionary<TKey, TValue>(this.comparer));
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

        /// <summary>
        /// Adds an element with the provided key and value to the current scope of the <see cref="ScopedDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add.</param>
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
        /// <summary>
        /// Determines whether the <see cref="ScopedDictionary{TKey, TValue}"/> contains a specific key in either the current or all scopes.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="ScopedDictionary{TKey, TValue}"/>.</param>
        /// <param name="currentScopeOnly">if set to <c>true</c> only the current scope is checked; otherwise all scopes are checked.</param>
        /// <returns>true, if the  <see cref="ScopedDictionary{TKey, TValue}"/> contains the specified key; otherwise, false.</returns>
        public bool ContainsKey(TKey key, bool currentScopeOnly)
        {
            if (currentScopeOnly)
                return stack.Peek().ContainsKey(key);

            foreach (var d in stack)
                if (d.ContainsKey(key))
                    return true;

            return false;
        }

        /// <summary>
        /// Gets a <see cref="ScopedDictionary{TKey, TValue}.KeyCollection"/> containing the keys of the <see cref="ScopedDictionary{TKey, TValue}"/>.
        /// </summary>
        public KeyCollection Keys
        {
            get { return keys; }
        }
        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get { return keys; }
        }

        /// <summary>
        /// Removes the element with the specified key from all scopes of the <see cref="ScopedDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns>
        /// true if the element is successfully removed; otherwise, false.
        /// </returns>
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
        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value" /> parameter. This parameter is passed uninitialized.</param>
        /// <param name="currentScopeOnly">if set to <c>true</c> only the current scope is checked; otherwise all scopes are checked.</param>
        /// <returns>
        /// true, if the <see cref="ScopedDictionary{TKey, TValue}"/> contains an element with the specified key; otherwise, false.</returns>
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
        /// <summary>
        /// Gets a <see cref="ScopedDictionary{TKey, TValue}.ValueCollection"/> containing the values of the <see cref="ScopedDictionary{TKey, TValue}"/>.
        /// </summary>
        public ValueCollection Values
        {
            get { return values; }
        }
        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get { return values; }
        }

        /// <summary>
        /// Gets or sets the element with the specified key in the current scope of the <see cref="ScopedDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The value associated with <paramref name="key"/>.</returns>
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

        /// <summary>
        /// Removes all items from all scopes of the <see cref="ScopedDictionary{TKey, TValue}"/>.
        /// </summary>
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

        /// <summary>
        /// Gets the number distinct of elements contained in all scopes of the <see cref="ScopedDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <returns>The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.</returns>
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

        /// <summary>
        /// Represents the collection of keys in a <see cref="ScopedDictionary{TKey, TValue}"/>.
        /// </summary>
        public sealed class KeyCollection : ICollection<TKey>
        {
            private ScopedDictionary<TKey, TValue> dictionary;

            /// <summary>
            /// Initializes a new instance of the <see cref="KeyCollection"/> class that reflects the keys in the specified <see cref="ScopedDictionary{TKey, TValue}"/>.
            /// </summary>
            /// <param name="dictionary">The <see cref="ScopedDictionary{TKey, TValue}"/> whose keys are reflected in the new <see cref="KeyCollection"/>.</param>
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
            /// <summary>
            /// Determines whether the <see cref="KeyCollection" /> contains a specific value.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <param name="currentScopeOnly">if set to <c>true</c> only the current scope is checked; otherwise all scopes are checked.</param>
            /// <returns>true, if the  <see cref="KeyCollection"/> contains the specified key; otherwise, false.</returns>
            public bool Contains(TKey key, bool currentScopeOnly)
            {
                return dictionary.ContainsKey(key, currentScopeOnly);
            }

            void ICollection<TKey>.CopyTo(TKey[] array, int arrayIndex)
            {
                CopyTo(array, arrayIndex, false);
            }
            /// <summary>
            /// Copies the elements of the <see cref="KeyCollection" /> to a <see cref="System.Array"/>, starting at a particular index.
            /// </summary>
            /// <param name="array">The one-dimensional System.Array that is the destination of the elements <see cref="KeyCollection" />. The System.Array must have zero-based indexing.</param>
            /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
            /// <param name="currentScopeOnly">if set to <c>true</c> only keys from the current scope are copied; otherwise all keys are copied.</param>
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

            /// <summary>
            /// Gets the number of keys contained in the <see cref="KeyCollection" />.
            /// </summary>
            public int Count
            {
                get { return dictionary.count; }
            }

            bool ICollection<TKey>.IsReadOnly
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
        /// <summary>
        /// Represents the collection of values in a <see cref="ScopedDictionary{TKey, TValue}"/>.
        /// </summary>
        public sealed class ValueCollection : ICollection<TValue>
        {
            private ScopedDictionary<TKey, TValue> dictionary;

            /// <summary>
            /// Initializes a new instance of the <see cref="ValueCollection"/> class that reflects the values in the specified <see cref="ScopedDictionary{TKey, TValue}"/>.
            /// </summary>
            /// <param name="dictionary">The <see cref="ScopedDictionary{TKey, TValue}"/> whose values are reflected in the new <see cref="ValueCollection"/>.</param>
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
            /// <summary>
            /// Copies the elements of the <see cref="ValueCollection" /> to a <see cref="System.Array"/>, starting at a particular index.
            /// </summary>
            /// <param name="array">The one-dimensional System.Array that is the destination of the elements <see cref="ValueCollection" />. The System.Array must have zero-based indexing.</param>
            /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
            /// <param name="currentScopeOnly">if set to <c>true</c> only values from the current scope are copied; otherwise all values are copied.</param>
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

            /// <summary>
            /// Gets the number of values contained in the <see cref="KeyCollection" />.
            /// </summary>
            public int Count
            {
                get { return dictionary.count; }
            }

            bool ICollection<TValue>.IsReadOnly
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
