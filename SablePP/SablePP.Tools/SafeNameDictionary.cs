using System;
using System.Collections.Generic;

namespace SablePP.Tools
{
    public class SafeNameDictionary
    {
        private Stack<DictionarySet> stack;
        private SafeName safename;

        public SafeNameDictionary(SafeName safename)
        {
            this.stack = new Stack<DictionarySet>();
            this.safename = safename;

            this.stack.Push(new DictionarySet());
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
