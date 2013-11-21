using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler
{
    /// <summary>
    /// Represents the declaration of a element name identifier.
    /// </summary>
    public class DElementName : Declaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DElementName"/> class.
        /// </summary>
        /// <param name="node">The element name node from which this <see cref="DElementName"/> should be constructed.</param>
        public DElementName(AElementname name)
            : base(name.Name)
        {
        }

        public override string ToString()
        {
            return "E:" + base.ToString();
        }
    }
}
