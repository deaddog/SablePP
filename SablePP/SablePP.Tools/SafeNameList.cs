using System;
using System.Collections.Generic;

namespace SablePP.Tools
{
    /// <summary>
    /// Defines methods for retrieving unused (variable) names in a list.
    /// </summary>
    public class SafeNameList : SafeName
    {
        private IList<string> list;

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeNameList"/>.
        /// Names are generated using <see cref="SafeName.GetNumberedNames"/>.
        /// </summary>
        /// <param name="list">The list of variable names that this <see cref="SafeNameList"/> will test for existing names and add new names to.</param>
        public SafeNameList(IList<string> list)
            : this(list, SafeName.GetNumberedNames)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeNameList"/> class.
        /// </summary>
        /// <param name="list">The list of variable names that this <see cref="SafeNameList"/> will test for existing names and add new names to.</param>
        /// <param name="getTestNames">Specifies a method that generates variable names from an input string. Infinite collections of distinct elements are allowed.</param>
        public SafeNameList(IList<string> list, Func<string, IEnumerable<string>> getTestNames)
            : base(getTestNames)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            this.list = list;
        }

        /// <summary>
        /// Determines whether <paramref name="name"/> is contained by the list that this <see cref="SafeNameList"/> manages.
        /// This method determines if names are available or not (if they are already in use).
        /// </summary>
        /// <param name="name">The name to check for.</param>
        /// <returns>
        ///   <c>true</c>, if <paramref name="name" /> is already in use; otherwise <c>false</c>.
        /// </returns>
        public override bool Contains(string name)
        {
            return list.Contains(name);
        }

        /// <summary>
        /// Adds a safe version of <paramref name="name"/> to the list that this <see cref="SafeNameList"/> manages.
        /// </summary>
        /// <param name="name">The name to add to the list.</param>
        /// <returns>The safe name that was added to the list.</returns>
        public string Add(string name)
        {
            name = GetName(name);
            list.Add(name);
            return name;
        }
    }
}
