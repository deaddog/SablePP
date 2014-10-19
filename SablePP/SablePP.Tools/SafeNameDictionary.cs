using System;
using System.Collections.Generic;

namespace SablePP.Tools
{
    public class SafeNameDictionary
    {
        private Stack<DictionarySet> stack;
        private DictionarySet peek;
        private SafeName safename, allscopesSafeName;

        public SafeNameDictionary()
            : this(null)
        {
        }
        public SafeNameDictionary(Func<string, IEnumerable<string>> getTestNames)
        {
            var getNames = getTestNames ?? SafeName.GetNumberedNames;

            this.stack = new Stack<DictionarySet>();
            this.safename = new SafeName(x => ContainsName(x, false), getNames);
            this.allscopesSafeName = new SafeName(x => ContainsName(x, true), getNames);

            this.stack.Push(peek = new DictionarySet());
        }

        public string Add(string name, bool allscopes = true, bool tryliteral = true)
        {
            name = (allscopes ? allscopesSafeName : safename).GetName(name, tryliteral);
            peek.NameToItem.Add(name, null);
            return name;
        }
        public string Add(string name, object item, bool allscopes = true, bool tryliteral = true)
        {
            if (ContainsItem(item, allscopes))
                return this[item];

            name = (allscopes ? allscopesSafeName : safename).GetName(name, tryliteral);
            peek.NameToItem.Add(name, item);
            peek.ItemToName.Add(item, name);
            return name;
        }

        public object this[string name]
        {
            get
            {
                foreach (var s in stack)
                    if (s.NameToItem.ContainsKey(name))
                        return s.NameToItem[name];
                throw new ArgumentException("The name '" + name + "' was not found in the dictionary.", "name");
            }
        }
        public string this[object item]
        {
            get
            {
                foreach (var s in stack)
                    if (s.ItemToName.ContainsKey(item))
                        return s.ItemToName[item];
                throw new ArgumentException("The item '" + item.ToString() + "' was not found in the dictionary.", "item");
            }
        }

        public bool ContainsName(string name, bool allscopes)
        {
            if (allscopes)
            {
                foreach (var s in stack)
                    if (s.NameToItem.ContainsKey(name))
                        return true;
                return false;
            }
            else
                return peek.NameToItem.ContainsKey(name);
        }
        public bool ContainsItem(object item, bool allscopes)
        {
            if (allscopes)
            {
                foreach (var s in stack)
                    if (s.ItemToName.ContainsKey(item))
                        return true;
                return false;
            }
            else
                return peek.ItemToName.ContainsKey(item);
        }

        public T GetItem<T>(string name, bool allscopes)
        {
            if (allscopes)
            {
                foreach (var s in stack)
                    if (s.NameToItem.ContainsKey(name))
                    {
                        var obj = s.NameToItem[name];
                        if (!(obj is T) && obj != null)
                            throw new ArgumentException("The item referenced by '" + name + "' was not of type " + typeof(T) + ".", "name");
                        else
                            return (T)obj;
                    }
                throw new ArgumentException("The name '" + name + "' was not found in the dictionary.", "name");
            }
            else if (!peek.NameToItem.ContainsKey(name))
                throw new ArgumentException("The name '" + name + "' was not found in the dictionary.", "name");
            else
            {
                var obj = peek.NameToItem[name];
                if (!(obj is T) && obj != null)
                    throw new ArgumentException("The item referenced by '" + name + "' was not of type " + typeof(T) + ".", "name");
                else
                    return (T)obj;
            }
        }
        public string GetName(object item, bool allscopes)
        {
            if (allscopes)
            {
                foreach (var s in stack)
                    if (s.ItemToName.ContainsKey(item))
                        return s.ItemToName[item];
                throw new ArgumentException("The item '" + item.ToString() + "' was not found in the dictionary.", "item");
            }
            else if (!peek.ItemToName.ContainsKey(item))
                throw new ArgumentException("The item '" + item.ToString() + "' was not found in the dictionary.", "item");
            else
                return peek.ItemToName[item];
        }

        public int ScopeLevel
        {
            get { return stack.Count - 1; }
        }

        public void OpenScope()
        {
            stack.Push(peek = new DictionarySet());
        }
        public void CloseScope()
        {
            if (stack.Count == 1)
                throw new InvalidOperationException("Cannot close the outermost scope in a SafeNameDictionary.");
            else
            {
                stack.Pop();
                peek = stack.Peek();
            }
        }
        public void CloseAllScopes()
        {
            while (stack.Count > 1)
                stack.Pop();
            peek = stack.Peek();
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
