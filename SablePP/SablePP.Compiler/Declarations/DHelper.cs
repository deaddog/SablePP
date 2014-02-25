using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler
{
    /// <summary>
    /// Represents the declaration of a helper identifier.
    /// </summary>
    public class DHelper : Declaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DHelper"/> class.
        /// </summary>
        /// <param name="node">The identifier token that declares this <see cref="DHelper"/>.</param>
        public DHelper(TIdentifier identifier)
            : base(identifier)
        {
        }

        public override string ToString()
        {
            return "H:" + base.ToString();
        }
    }
}
