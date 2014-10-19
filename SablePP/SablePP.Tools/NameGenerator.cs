using System.Collections.Generic;

namespace SablePP.Tools
{
    /// <summary>
    /// Specifies a method that generates variable names from an <paramref name="initial"/> string. Infinite collections of distinct elements are allowed.
    /// </summary>
    /// <param name="initial">The initial string from which names should be generated.</param>
    /// <returns>A collection of names that could be used as a name when <paramref name="initial"/> is desired.</returns>
    public delegate IEnumerable<string> NameGenerator(string initial);
}
