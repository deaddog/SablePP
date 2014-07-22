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
        /// Gets a value indicating whether this identifier refers to a <see cref="PHelper"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="PHelper"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsPHelper
        {
            get { return this is DeclarationIdentifier<PHelper>; }
        }
        /// <summary>
        /// Gets the declaration associated with this identifier, as a <see cref="PHelper"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="PHelper"/> if this identifier refers to a <see cref="PHelper"/>; otherwise, <c>null</c>.
        /// </value>
        public PHelper AsPHelper
        {
            get { return (this as DeclarationIdentifier<PHelper>).Declaration; }
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
        /// Gets a value indicating whether this identifier refers to a <see cref="PToken"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="PToken"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsPToken
        {
            get { return this is TokenIdentifier; }
        }
        /// <summary>
        /// Gets the declaration associated with this identifier, as a <see cref="PToken"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="PToken"/> if this identifier refers to a <see cref="PToken"/>; otherwise, <c>null</c>.
        /// </value>
        public PToken AsPToken
        {
            get { return (this as TokenIdentifier).Declaration; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="ProductionIdentifier"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="ProductionIdentifier"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsProduction
        {
            get { return this is ProductionIdentifier; }
        }
        /// <summary>
        /// Gets the declaration associated with this identifier, as a <see cref="ProductionIdentifier"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="ProductionIdentifier"/> if this identifier refers to a <see cref="ProductionIdentifier"/>; otherwise, <c>null</c>.
        /// </value>
        public ProductionIdentifier AsProduction
        {
            get { return this as ProductionIdentifier; }
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
