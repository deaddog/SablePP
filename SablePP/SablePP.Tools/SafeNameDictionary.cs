using System;
using System.Collections.Generic;

namespace SablePP.Tools
{
    public class SafeNameDictionary<TValue> : SafeName
    {
        private Stack<DictionarySet> stack;

        private IDictionary<string, TValue> dictionary;

        public SafeNameDictionary(IDictionary<string, TValue> dictionary)
            : this(dictionary, SafeName.GetNumberedNames)
        {
        }

        public SafeNameDictionary(IDictionary<string, TValue> dictionary, Func<string, IEnumerable<string>> getTestNames)
            : base(getTestNames)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            this.dictionary = dictionary;
        }

        public override bool Contains(string name)
        {
            return dictionary.ContainsKey(name);
        }

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
