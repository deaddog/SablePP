using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sable.Compiler.Nodes;

namespace Sable.Compiler
{
    /// <summary>
    /// Represents the declaration of a state identifier.
    /// </summary>
    public class DState : Declaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DState"/> class.
        /// </summary>
        /// <param name="node">The identifier node from which this <see cref="DState"/> should be constructed.</param>
        public DState(TIdentifier node)
            : base(node)
        {
        }

        public override string ToString()
        {
            return "S:" + base.ToString();
        }
    }
}
