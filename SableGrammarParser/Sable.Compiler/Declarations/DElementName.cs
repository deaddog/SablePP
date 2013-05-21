using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sable.Compiler.node;

namespace Sable.Compiler
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
            : base(name.GetName())
        {
        }

        public override string ToString()
        {
            return "E:" + base.ToString();
        }
    }
}
