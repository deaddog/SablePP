using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser
{
    /// <summary>
    /// Represents the declaration of a alternative name identifier.
    /// </summary>
    public class DAlternative : DBaseAlternative
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DAlternative"/> class.
        /// </summary>
        /// <param name="node">The alternative name node from which this <see cref="DAlternative"/> should be constructed.</param>
        public DAlternative(AAlternativename name)
            : base(name, true)
        {
        }
    }
}
