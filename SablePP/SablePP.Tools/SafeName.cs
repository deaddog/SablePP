using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools
{
    /// <summary>
    /// Defines methods for retrieving unused (variable) names.
    /// </summary>
    public class SafeName
    {
        private List<string> names;
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
        /// Names are generated using the <see cref="SafeName.GetNumberedNames"/> method.
        /// </summary>
        public SafeName()
            : this(GetNumberedNames)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeName"/> class that contains all the names copied from the specified collection.
        /// Names are generated using the <see cref="SafeName.GetNumberedNames"/> method.
        /// </summary>
        /// <param name="existingNames">The collection of existing names that are copied to the new <see cref="SafeName"/> instance.</param>
        public SafeName(IEnumerable<string> existingNames)
            : this(GetNumberedNames, existingNames)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeName"/> class with no pre-known names.
        /// </summary>
        /// <param name="getTestNames">Specifies a method that generates variable names from an input string. Infinite collections of distinct elements are allowed.</param>
        public SafeName(Func<string, IEnumerable<string>> getTestNames)
        {
            this.names = new List<string>();
            this.testnames = getTestNames;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeName"/> class that contains all the names copied from the specified collection.
        /// </summary>
        /// <param name="getTestNames">Specifies a method that generates variable names from an input string. Infinite collections of distinct elements are allowed.</param>
        /// <param name="existingNames">The collection of existing names that are copied to the new <see cref="SafeName"/> instance.</param>
        public SafeName(Func<string, IEnumerable<string>> getTestNames, IEnumerable<string> existingNames)
        {
            this.names = new List<string>(existingNames);
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

            if (yieldInitial && !names.Contains(name))
            {
                names.Add(name);
                return name;
            }

            foreach (var n in testnames(name))
                if (!names.Contains(n))
                {
                    names.Add(n);
                    return n;
                }

            throw new InvalidOperationException("Unable to determine a safe name.");
        }
    }
}
