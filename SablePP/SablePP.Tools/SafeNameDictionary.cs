using System;
using System.Collections.Generic;

namespace SablePP.Tools
{
    public class SafeNameDictionary
    {
        private Stack<DictionarySet> stack;
        private SafeName safename;

        public SafeNameDictionary()
            : this(null)
        { 
        }
        public SafeNameDictionary(Func<string, IEnumerable<string>> getTestNames)
        {
            this.stack = new Stack<DictionarySet>();
            this.safename = new SafeName(x => stack.Peek().NameToItem.ContainsKey(x), getTestNames ?? SafeName.GetNumberedNames);

            this.stack.Push(new DictionarySet());
        }

        public int ScopeLevel
        {
            get { return stack.Count - 1; }
        }

        public void OpenScope()
        {
            stack.Push(new DictionarySet());
        }
        public void CloseScope()
        {
            if (stack.Count == 1)
                throw new InvalidOperationException("Cannot close the outermost scope in a SafeNameDictionary.");
            else
                stack.Pop();
        }
        public void CloseAllScopes()
        {
            while (stack.Count > 1)
                stack.Pop();
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
