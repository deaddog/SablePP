using SablePP.Compiler.Nodes.Identifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Nodes
{
    public partial class TIdentifier
    {
        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="HelperIdentifier"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="HelperIdentifier"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsHelper
        {
            get { return this is HelperIdentifier; }
        }
        /// <summary>
        /// Gets the declaration associated with this identifier, as a <see cref="HelperIdentifier"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="HelperIdentifier"/> if this identifier refers to a <see cref="HelperIdentifier"/>; otherwise, <c>null</c>.
        /// </value>
        public HelperIdentifier AsHelper
        {
            get { return this as HelperIdentifier; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="StateIdentifier"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="StateIdentifier"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsState
        {
            get { return this is StateIdentifier; }
        }
        /// <summary>
        /// Gets the declaration associated with this identifier, as a <see cref="StateIdentifier"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="StateIdentifier"/> if this identifier refers to a <see cref="StateIdentifier"/>; otherwise, <c>null</c>.
        /// </value>
        public StateIdentifier AsState
        {
            get { return this as StateIdentifier; }
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
        /// Gets a value indicating whether this identifier refers to a <see cref="AlternativeNameIdentifier"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="AlternativeNameIdentifier"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsAlternativeName
        {
            get { return this is AlternativeIdentifier; }
        }
        /// <summary>
        /// Gets the alternative name associated with this identifier, as a <see cref="AlternativeNameIdentifier"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="AlternativeNameIdentifier"/> if this identifier refers to a <see cref="AlternativeNameIdentifier"/>; otherwise, <c>null</c>.
        /// </value>
        public AlternativeIdentifier AsAlternativeName
        {
            get { return this as AlternativeIdentifier; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="ElementNameIdentifier"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="ElementNameIdentifier"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsElementName
        {
            get { return this is ElementIdentifier; }
        }
        /// <summary>
        /// Gets the element name associated with this identifier, as a <see cref="ElementNameIdentifier"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="ElementNameIdentifier"/> if this identifier refers to a <see cref="ElementNameIdentifier"/>; otherwise, <c>null</c>.
        /// </value>
        public ElementIdentifier AsElementName
        {
            get { return this as ElementIdentifier; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="HighlightRuleIdentifier"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="HighlightRuleIdentifier"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsHighlightRule
        {
            get { return this is HighlightruleIdentifier; }
        }
        /// <summary>
        /// Gets the highlighter rule associated with this identifier, as a <see cref="HighlightRuleIdentifier"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="AlternativeNameIdentifier"/> if this identifier refers to a <see cref="HighlightRuleIdentifier"/>; otherwise, <c>null</c>.
        /// </value>
        public HighlightruleIdentifier AsHighlightRule
        {
            get { return this as HighlightruleIdentifier; }
        }
    }
}
