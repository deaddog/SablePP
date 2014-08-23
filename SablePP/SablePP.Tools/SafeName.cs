using System;
using System.Collections.Generic;

namespace SablePP.Tools
{
    /// <summary>
    /// Defines methods for retrieving unused (variable) names.
    /// </summary>
    public abstract class SafeName
    {
        private Func<string, IEnumerable<string>> testnames;

        /// <summary>
        /// Enumerates a collection of strings matching the pattern '<paramref name="name"/>1', '<paramref name="name"/>2', '<paramref name="name"/>3', ...
        /// </summary>
        /// <param name="name">The name that should be prepended with integers.</param>
        /// <returns>An infinite collection of strings; '<paramref name="name"/>1', '<paramref name="name"/>2', '<paramref name="name"/>3', ...</returns>
        public static IEnumerable<string> GetNumberedNames(string name)
        {
            int i = 1;
            while (true) yield return name + i++;
        }

        private bool yieldInitial = false;
        /// <summary>
        /// Gets or sets a value indicating whether the input name should always be tested as an available name.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the input string should be tested; otherwise, <c>false</c>.
        /// </value>
        public bool YieldInitial
        {
            get { return yieldInitial; }
            set { yieldInitial = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeName"/> class with no pre-known names.
        /// </summary>
        /// <param name="getTestNames">Specifies a method that generates variable names from an input string. Infinite collections of distinct elements are allowed.</param>
        public SafeName(Func<string, IEnumerable<string>> getTestNames)
        {
            if (getTestNames == null)
                throw new ArgumentNullException("getTestNames");

            this.testnames = getTestNames;
        }

        /// <summary>
        /// Gets an previously unknown (safe) name from a string.
        /// </summary>
        /// <param name="name">The string from which a name is returned.</param>
        /// <returns>A string not previously known by this <see cref="SafeName"/>.</returns>
        public string GetName(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (yieldInitial && !Contains(name))
                return name;

            foreach (var n in testnames(name))
                if (!Contains(n))
                    return n;

            throw new InvalidOperationException("Unable to determine a safe name.");
        }
        /// <summary>
        /// Determines whether <paramref name="name"/> is contained by the collection that this <see cref="SafeName"/> manages.
        /// This method determines if names are available or not (if they are already in use).
        /// </summary>
        /// <param name="name">The name to check for.</param>
        /// <returns><c>true</c>, if <paramref name="name"/> is already in use; otherwise <c>false</c>.</returns>
        public abstract bool Contains(string name);
    }
}
