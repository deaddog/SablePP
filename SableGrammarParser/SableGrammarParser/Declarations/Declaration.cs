using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser
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
        /// Initializes a new instance of the <see cref="Declaration"/> class.
        /// </summary>
        /// <param name="declarationToken">The declaration token.</param>
        public Declaration(TIdentifier declarationToken)
        {
            this.declaration = declarationToken;
        }
    }
}
