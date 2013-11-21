using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler
{
    /// <summary>
    /// Represents the declaration associated with an identifier.
    /// </summary>
    public abstract class Declaration
    {
        private TIdentifier declaration;
        /// <summary>
        /// Gets the declaration token.
        /// </summary>
        /// <value>
        /// The declaration token.
        /// </value>
        public TIdentifier DeclarationToken
        {
            get { return declaration; }
        }

        /// <summary>
        /// Gets the name associated with this <see cref="Declaration"/>.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return declaration.Text; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Declaration"/> class.
        /// </summary>
        /// <param name="declarationToken">The declaration token.</param>
        public Declaration(TIdentifier declarationToken)
        {
            this.declaration = declarationToken;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
