using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler
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
        /// <param name="node">The identifier from which this <see cref="DToken"/> should be constructed.</param>
        public DToken(TIdentifier identifier)
            : base(identifier)
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

        public string GeneratedName
        {
            get { return "T" + base.DeclarationToken.Text.ToCamelCase(); }
        }

        public override string ToString()
        {
            return "T:" + base.ToString() + (ignored ? " [Ignore]" : "");
        }
    }
}
