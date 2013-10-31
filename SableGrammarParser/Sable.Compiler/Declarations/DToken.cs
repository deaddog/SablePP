using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sable.Compiler.Nodes;

namespace Sable.Compiler
{
    /// <summary>
    /// Represents the declaration of a token identifier.
    /// </summary>
    public class DToken : Declaration
    {
        private bool ignored = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="DToken"/> class.
        /// </summary>
        /// <param name="node">The token node from which this <see cref="DToken"/> should be constructed.</param>
        public DToken(AToken node)
            : base(node.GetIdentifier())
        {
        }

        /// <summary>
        /// Gets or sets whether this token is ignored by the parser.
        /// </summary>
        public bool Ignored
        {
            get { return ignored; }
            set { ignored = value; }
        }

        public override string ToString()
        {
            return "T:" + base.ToString() + (ignored ? " [Ignore]" : "");
        }
    }
}
