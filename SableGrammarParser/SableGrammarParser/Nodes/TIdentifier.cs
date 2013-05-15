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
        /// Gets a value indicating whether this identifier refers to a <see cref="DHelper"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="DHelper"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsHelper
        {
            get { return declaration is DHelper; }
        }
        /// <summary>
        /// Gets the declaration associated with this identifier, as a <see cref="DHelper"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="DHelper"/> if this identifier refers to a <see cref="DHelper"/>; otherwise, <c>null</c>.
        /// </value>
        public DHelper AsHelper
        {
            get { return declaration as DHelper; }
        }
    }
}
