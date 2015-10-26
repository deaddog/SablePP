﻿using System;
using System.Collections.Generic;

namespace SablePP.Tools
{
    /// <summary>
    /// Provides methods for managing variable names and scoping.
    /// </summary>
    /// <typeparam name="T">The type of the objects that names refer to.</typeparam>
    public class SafeNameDictionary<T> where T : class
    {
        private Stack<DictionarySet> stack;
        private DictionarySet peek;
        private SafeName safename, allscopesSafeName;

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeNameDictionary{T}"/> class that is empty,
        /// has the default initial capacity,
        /// and uses <see cref="SafeName.GetNumberedNames"/> to generate variable names.
        /// </summary>
        public SafeNameDictionary()
            : this(null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SafeNameDictionary{T}"/> class that is empty,
        /// has the default initial capacity,
        /// and uses a function to generate variable names.
        /// </summary>
        /// <param name="getTestNames">A <see cref="NameGenerator"/> that generates names for the <see cref="SafeNameDictionary{T}"/>.</param>
        public SafeNameDictionary(NameGenerator getTestNames)
        {
            this.stack = new Stack<DictionarySet>();
            this.safename = new SafeName(x => !ContainsName(x, false), getTestNames);
            this.allscopesSafeName = new SafeName(x => !ContainsName(x, true), getTestNames);

            this.stack.Push(peek = new DictionarySet());
        }

        /// <summary>
        /// Adds the first unused name, matching a seed name, to this <see cref="SafeNameDictionary{T}"/>.
        /// </summary>
        /// <param name="name">The name seed from which names are generated.</param>
        /// <param name="allscopes">if set to <c>true</c> the generated name is unused in all scopes; otherwise, it is only unsued in the topmost scope.</param>
        /// <returns>The name that was inserted in the <see cref="SafeNameDictionary{T}"/></returns>
        public string Add(string name, bool allscopes = true)
        {
            name = (allscopes ? allscopesSafeName : safename).GetName(name);
            peek.NameToItem.Add(name, null);
            return name;
        }
        /// <summary>
        /// Adds the first unused name, matching a seed name, to this <see cref="SafeNameDictionary{T}"/>.
        /// Stores a two-way link between that name and <paramref name="item"/> such that one can be retrieved from the other.
        /// </summary>
        /// <param name="name">The name seed from which names are generated.</param>
        /// <param name="item">The item that should be associated with the generated name.</param>
        /// <param name="allscopes">if set to <c>true</c> the generated name is unused in all scopes; otherwise, it is only unsued in the topmost scope.</param>
        /// <returns>The name that was inserted in the <see cref="SafeNameDictionary{T}"/>
        /// or the existing name stored for <paramref name="item"/> (if it exists).
        /// The latter disregards the <paramref name="name"/> parameter.</returns>
        public string Add(string name, T item, bool allscopes = true)
        {
            if (item == null)
                throw new ArgumentNullException("item", "Cannot link null to a name. Use Add(string, bool) instead.");

            if (ContainsItem(item, allscopes))
                return this[item];

            name = (allscopes ? allscopesSafeName : safename).GetName(name);
            peek.NameToItem.Add(name, item);
            peek.ItemToName.Add(item, name);
            return name;
        }

        /// <summary>
        /// Ensures that the <paramref name="item"/> refers to <paramref name="name"/>.
        /// This will NOT use safe names and <paramref name="name"/> will NOT refer to <paramref name="item"/>.
        /// </summary>
        /// <param name="item">The item that should be associated with <paramref name="name"/>.</param>
        /// <param name="name">The name that <paramref name="item"/> should be associated with.</param>
        public void AddItem(T item, string name)
        {
            peek.ItemToName.Add(item, name);
        }

        /// <summary>
        /// Gets the item associated with the specified name.
        /// </summary>
        /// <param name="name">The name for which an item should be extracted.</param>
        /// <returns>The item associated with <paramref name="name"/>
        /// or <c>null</c> if <paramref name="name"/> was known by the <see cref="SafeNameDictionary{T}"/> but not associated with an item.
        /// The item returned will be from the topmost scope containing <paramref name="name"/>.</returns>
        public T this[string name]
        {
            get
            {
                foreach (var s in stack)
                    if (s.NameToItem.ContainsKey(name))
                        return s.NameToItem[name];
                throw new ArgumentException("The name '" + name + "' was not found in the dictionary.", "name");
            }
        }
        /// <summary>
        /// Gets the name associated with the specified item.
        /// </summary>
        /// <param name="item">The item for which a name should be extracted.</param>
        /// <returns>The name associated with <paramref name="item"/>.
        /// The name returned will be from the topmost scope containing <paramref name="item"/>.</returns>
        public string this[T item]
        {
            get
            {
                foreach (var s in stack)
                    if (s.ItemToName.ContainsKey(item))
                        return s.ItemToName[item];
                throw new ArgumentException("The item '" + item.ToString() + "' was not found in the dictionary.", "item");
            }
        }

        /// <summary>
        /// Determines whether the <see cref="SafeNameDictionary{T}"/> contains the specified name.
        /// </summary>
        /// <param name="name">The name to find an item for.</param>
        /// <param name="allscopes">if set to <c>true</c> all scopes are checked for <paramref name="name"/>; otherwise only the topmost scope is checked.</param>
        /// <returns><c>true</c> if the specified name was found in the <see cref="SafeNameDictionary{T}"/>; otherwise <c>false</c>.</returns>
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
        /// <summary>
        /// Determines whether the <see cref="SafeNameDictionary{T}"/> contains a name for the specified item.
        /// </summary>
        /// <param name="item">The item to find a name for.</param>
        /// <param name="allscopes">if set to <c>true</c> all scopes are checked for <paramref name="item"/>; otherwise only the topmost scope is checked.</param>
        /// <returns><c>true</c> if the specified item was found in the <see cref="SafeNameDictionary{T}"/>; otherwise <c>false</c>.</returns>
        public bool ContainsItem(T item, bool allscopes)
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

        /// <summary>
        /// Gets the item associated with the specified name.
        /// </summary>
        /// <param name="name">The name for which an item should be extracted.</param>
        /// <param name="allscopes">if set to <c>true</c> all scopes are checked for <paramref name="name"/>; otherwise only the topmost scope is checked.</param>
        /// <returns>The <typeparamref name="T"/> item associated with <paramref name="name"/>
        /// or <c>null</c> if <paramref name="name"/> was known by the <see cref="SafeNameDictionary{T}"/> but not associated with an item.
        /// The item returned will be from the topmost scope containing <paramref name="name"/>.</returns>
        public T GetItem(string name, bool allscopes)
        {
            if (allscopes)
            {
                foreach (var s in stack)
                    if (s.NameToItem.ContainsKey(name))
                        return s.NameToItem[name];

                throw new ArgumentException("The name '" + name + "' was not found in the dictionary.", "name");
            }
            else if (!peek.NameToItem.ContainsKey(name))
                throw new ArgumentException("The name '" + name + "' was not found in the dictionary.", "name");
            else
                return peek.NameToItem[name];
        }
        /// <summary>
        /// Gets the name associated with the specified item.
        /// </summary>
        /// <param name="item">The item for which a name should be extracted.</param>
        /// <param name="allscopes">if set to <c>true</c> all scopes are checked for <paramref name="item"/>; otherwise only the topmost scope is checked.</param>
        /// <returns>The name associated with <paramref name="item"/>.
        /// The name returned will be from the topmost scope containing <paramref name="item"/>.</returns>
        public string GetName(T item, bool allscopes)
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

        /// <summary>
        /// Gets or sets the number of opened scopes (except for the outermost scope).
        /// </summary>
        public int ScopeLevel
        {
            get { return stack.Count - 1; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "Scope must be >= 0.");

                while (value > ScopeLevel)
                    OpenScope();

                while (value < ScopeLevel)
                    CloseScope();
            }
        }

        /// <summary>
        /// Opens a new scope, allowing all names to be reused.
        /// </summary>
        public void OpenScope()
        {
            stack.Push(peek = new DictionarySet());
        }
        /// <summary>
        /// Closes the top-most scope, removing all names/items defined in that scope.
        /// Lower scopes are not altered.
        /// The outermost scope cannot be closed.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Cannot close the outermost scope in a SafeNameDictionary.</exception>
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
        /// <summary>
        /// Closes all scopes (except for the outermost scope), removing all names/items defined in all scopes (except for the outermost scope).
        /// </summary>
        public void CloseAllScopes()
        {
            while (stack.Count > 1)
                stack.Pop();
            peek = stack.Peek();
        }

        private class DictionarySet
        {
            public readonly Dictionary<string, T> NameToItem;
            public readonly Dictionary<T, string> ItemToName;

            public DictionarySet()
            {
                this.NameToItem = new Dictionary<string, T>();
                this.ItemToName = new Dictionary<T, string>();
            }
        }
    }

    /// <summary>
    /// Provides methods for managing variable names and scoping.
    /// </summary>
    public class SafeNameDictionary : SafeNameDictionary<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SafeNameDictionary"/> class that is empty,
        /// has the default initial capacity,
        /// and uses <see cref="SafeName.GetNumberedNames"/> to generate variable names.
        /// </summary>
        public SafeNameDictionary()
            : this(null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SafeNameDictionary"/> class that is empty,
        /// has the default initial capacity,
        /// and uses a function to generate variable names.
        /// </summary>
        /// <param name="getTestNames">A <see cref="NameGenerator"/> that generates names for the <see cref="SafeNameDictionary"/>.</param>
        public SafeNameDictionary(NameGenerator getTestNames)
            : base(getTestNames)
        {
        }

        /// <summary>
        /// Gets the item associated with the specified name.
        /// </summary>
        /// <typeparam name="T">The type of the item that is retrieved.</typeparam>
        /// <param name="name">The name for which an item should be extracted.</param>
        /// <param name="allscopes">if set to <c>true</c> all scopes are checked for <paramref name="name"/>; otherwise only the topmost scope is checked.</param>
        /// <returns>The <typeparamref name="T"/> item associated with <paramref name="name"/>
        /// or <c>null</c> if <paramref name="name"/> was known by the <see cref="SafeNameDictionary"/> but not associated with an item.
        /// The item returned will be from the topmost scope containing <paramref name="name"/>.</returns>
        public T GetItem<T>(string name, bool allscopes)
        {
            var obj = base.GetItem(name, allscopes);

            if (!(obj is T) && obj != null)
                throw new ArgumentException("The item referenced by '" + name + "' was not of type " + typeof(T) + ".", "name");
            else
                return (T)obj;
        }
    }
}
