using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Nodes
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
            if (this.declaration != null)
                throw new InvalidOperationException("Attempted to set declaration twice.");
            else
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

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="DAlternativeName"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="DAlternativeName"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsAlternativeName
        {
            get { return declaration is DAlternativeName; }
        }
        /// <summary>
        /// Gets the alternative name associated with this identifier, as a <see cref="DAlternativeName"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="DAlternativeName"/> if this identifier refers to a <see cref="DAlternativeName"/>; otherwise, <c>null</c>.
        /// </value>
        public DAlternativeName AsAlternativeName
        {
            get { return declaration as DAlternativeName; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="DElementName"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="DElementName"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsElementName
        {
            get { return declaration is DElementName; }
        }
        /// <summary>
        /// Gets the element name associated with this identifier, as a <see cref="DElementName"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="DElementName"/> if this identifier refers to a <see cref="DElementName"/>; otherwise, <c>null</c>.
        /// </value>
        public DElementName AsElementName
        {
            get { return declaration as DElementName; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="DHighlightRule"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="DHighlightRule"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsHighlightRule
        {
            get { return declaration is DHighlightRule; }
        }
        /// <summary>
        /// Gets the highlighter rule associated with this identifier, as a <see cref="DHighlightRule"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="DAlternativeName"/> if this identifier refers to a <see cref="DHighlightRule"/>; otherwise, <c>null</c>.
        /// </value>
        public DHighlightRule AsHighlightRule
        {
            get { return declaration as DHighlightRule; }
        }
    }
}
