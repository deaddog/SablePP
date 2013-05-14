using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SableGrammarParser.node
{
    public partial class TIdentifier
    {
        private Declaration declaration;

        /// <summary>
        /// Sets the declaration for this identifier.
        /// </summary>
        /// <param name="declaration">The declaration.</param>
        public void SetDeclaration(Declaration declaration)
        {
            this.declaration = declaration;
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="Helper"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="Helper"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsHelper
        {
            get { return declaration is Helper; }
        }
        /// <summary>
        /// Gets the declaration associated with this identifier, as a <see cref="Helper"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="Helper"/> if this identifier refers to a <see cref="Helper"/>; otherwise, <c>null</c>.
        /// </value>
        public Helper AsHelper
        {
            get { return declaration as Helper; }
        }
    }
}
