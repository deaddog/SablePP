using System;
using System.Collections.Generic;

namespace SablePP.Tools
{
    /// <summary>
    /// Defines methods for retrieving unused (variable) names in a dictionary.
    /// </summary>
    /// <typeparam name="TValue">The value-type of the elements in the dictionary.</typeparam>
    public class SafeNameDictionary<TValue> : SafeName
    {
        private Stack<DictionarySet> stack;

        private IDictionary<string, TValue> dictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeNameDictionary{TValue}"/> class.
        /// Names are generated using <see cref="SafeName.GetNumberedNames"/>.
        /// </summary>
        /// <param name="dictionary">The dictionary that this <see cref="SafeNameDictionary{TValue}"/> will test for existing names (keys) and add new names to.</param>
        public SafeNameDictionary(IDictionary<string, TValue> dictionary)
            : this(dictionary, SafeName.GetNumberedNames)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeNameDictionary{TValue}"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary that this <see cref="SafeNameDictionary{TValue}"/> will test for existing names (keys) and add new names to.</param>
        /// <param name="getTestNames">Specifies a method that generates variable names from an input string. Infinite collections of distinct elements are allowed.</param>
        public SafeNameDictionary(IDictionary<string, TValue> dictionary, Func<string, IEnumerable<string>> getTestNames)
            : base(getTestNames)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            this.dictionary = dictionary;
        }

        /// <summary>
        /// Determines whether <paramref name="name"/> is contained by the dictionary that this <see cref="SafeNameDictionary{TValue}"/> manages.
        /// This method determines if names are available or not (if they are already in use).
        /// </summary>
        /// <param name="name">The name to check for.</param>
        /// <returns>
        ///   <c>true</c>, if <paramref name="name" /> is already in use; otherwise <c>false</c>.
        /// </returns>
        public override bool Contains(string name)
        {
            return dictionary.ContainsKey(name);
        }

        /// <summary>
        /// Adds a safe version of <paramref name="name"/> along with <paramref name="value"/> to the dictionary that this <see cref="SafeNameDictionary{TValue}"/> manages.
        /// </summary>
        /// <param name="name">The name to add to the dictionary.</param>
        /// <param name="value">The value that should be associated with <paramref name="name"/> in the dictionary.</param>
        /// <returns>The safe name that was added to the dictionary.</returns>
        public string Add(string name, TValue value)
        {
            name = GetName(name);
            dictionary.Add(name, value);
            return name;
        }

        private class DictionarySet
        {
            public readonly Dictionary<string, object> NameToItem;
            public readonly Dictionary<object, string> ItemToName;

            public DictionarySet()
            {
                this.NameToItem = new Dictionary<string, object>();
                this.ItemToName = new Dictionary<object, string>();
            }
        }
    }
}
