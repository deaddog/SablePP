﻿using System;
using System.Collections.Generic;

namespace SablePP.Tools
{
    public class SafeNameDictionary
    {
        private Stack<DictionarySet> stack;
        private DictionarySet peek;
        private SafeName safename;

        public SafeNameDictionary()
            : this(null)
        {
        }
        public SafeNameDictionary(Func<string, IEnumerable<string>> getTestNames)
        {
            this.stack = new Stack<DictionarySet>();
            this.safename = new SafeName(containsName, getTestNames ?? SafeName.GetNumberedNames);

            this.stack.Push(peek = new DictionarySet());
        }

        private bool containsName(string name)
        {
            return peek.NameToItem.ContainsKey(name);
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
