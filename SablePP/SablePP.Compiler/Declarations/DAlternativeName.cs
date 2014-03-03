using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler
{
    /// <summary>
    /// Represents the declaration of a alternative name identifier.
    /// </summary>
    public class DAlternativeName : Declaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DAlternativeName"/> class.
        /// </summary>
        /// <param name="node">The identifier node from which this <see cref="DAlternativeName"/> should be constructed.</param>
        public DAlternativeName(TIdentifier node)
            : base(node)
        {
        }
    }
}
