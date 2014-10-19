using System;
using System.Collections.Generic;

namespace SablePP.Tools
{
    /// <summary>
    /// Defines methods for retrieving unused (variable) names.
    /// </summary>
    public class SafeName
    {
        private NameGenerator testnames;
        private Func<string, bool> allowname;

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

        /// <summary>
        /// Enumerates a collection of strings matching the pattern '<paramref name="name"/>', '<paramref name="name"/>2', '<paramref name="name"/>3', ...
        /// </summary>
        /// <param name="name">The name that should be prepended with integers.</param>
        /// <returns>An infinite collection of strings; '<paramref name="name"/>', '<paramref name="name"/>2', '<paramref name="name"/>3', ...</returns>
        public static IEnumerable<string> GetNumberedNamesAndInitial(string name)
        {
            yield return name;
            int i = 2;
            while (true) yield return name + i++;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeName"/> class.
        /// </summary>
        /// <param name="allowname">Specifies a method that determines if a name is available for usage. Should return <c>true</c> if the parameter is usable as a name and otherwise <c>false</c>.</param>
        /// <param name="getTestNames">Specifies a <see cref="NameGenerator"/> for this <see cref="SafeName"/>.
        /// If <c>null</c>, <see cref="GetNumberedNames"/> is used.</param>
        public SafeName(Func<string, bool> allowname, NameGenerator getTestNames)
        {
            if (allowname == null)
                throw new ArgumentNullException("allowname");

            if (getTestNames == null)
                getTestNames = GetNumberedNames;

            this.allowname = allowname;
            this.testnames = getTestNames;
        }

        /// <summary>
        /// Gets an previously unknown (safe) name from a string.
        /// </summary>
        /// <param name="name">The string from which a name is returned.</param>
        /// <param name="yieldInitial">Determines if <paramref name="name"/> should be tested as an available name.</param>
        /// <returns>A string not previously known by this <see cref="SafeName"/>.</returns>
        public string GetName(string name, bool yieldInitial)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (yieldInitial && !allowname(name))
                return name;

            foreach (var n in testnames(name))
                if (!allowname(n))
                    return n;

            throw new InvalidOperationException("Unable to determine a safe name.");
        }
    }
}
