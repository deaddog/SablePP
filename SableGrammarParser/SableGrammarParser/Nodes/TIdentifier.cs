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

        public bool HasDeclaration
        {
            get { return declaration != null; }
        }
        public Declaration Declaration
        {
            get { return declaration; }
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

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="DState"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="DState"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsState
        {
            get { return declaration is DState; }
        }
        /// <summary>
        /// Gets the declaration associated with this identifier, as a <see cref="DState"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="DState"/> if this identifier refers to a <see cref="DState"/>; otherwise, <c>null</c>.
        /// </value>
        public DState AsState
        {
            get { return declaration as DState; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="DToken"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="DToken"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsToken
        {
            get { return declaration is DToken; }
        }
        /// <summary>
        /// Gets the declaration associated with this identifier, as a <see cref="DToken"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="DToken"/> if this identifier refers to a <see cref="DToken"/>; otherwise, <c>null</c>.
        /// </value>
        public DToken AsToken
        {
            get { return declaration as DToken; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="DProduction"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="DProduction"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsProduction
        {
            get { return declaration is DProduction; }
        }
        /// <summary>
        /// Gets the declaration associated with this identifier, as a <see cref="DProduction"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="DProduction"/> if this identifier refers to a <see cref="DProduction"/>; otherwise, <c>null</c>.
        /// </value>
        public DProduction AsProduction
        {
            get { return declaration as DProduction; }
        }
    }
}
