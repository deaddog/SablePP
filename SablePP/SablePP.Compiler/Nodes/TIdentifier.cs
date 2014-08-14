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
            get { return IsPHelper ? (this as DeclarationIdentifier<PHelper>).Declaration : null; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="PState"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="PState"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsState
        {
            get { return this is DeclarationIdentifier<PState>; }
        }
        /// <summary>
        /// Gets the declaration associated with this identifier, as a <see cref="PState"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="PState"/> if this identifier refers to a <see cref="PState"/>; otherwise, <c>null</c>.
        /// </value>
        public PState AsState
        {
            get { return IsState ? (this as DeclarationIdentifier<PState>).Declaration : null; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="PToken"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="PToken"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsPToken
        {
            get { return this is DeclarationIdentifier<PToken>; }
        }
        /// <summary>
        /// Gets the declaration associated with this identifier, as a <see cref="PToken"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="PToken"/> if this identifier refers to a <see cref="PToken"/>; otherwise, <c>null</c>.
        /// </value>
        public PToken AsPToken
        {
            get { return IsPToken ? (this as DeclarationIdentifier<PToken>).Declaration : null; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="PProduction"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="PProduction"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsPProduction
        {
            get { return this is DeclarationIdentifier<PProduction>; }
        }
        /// <summary>
        /// Gets the declaration associated with this identifier, as a <see cref="PProduction"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="PProduction"/> if this identifier refers to a <see cref="PProduction"/>; otherwise, <c>null</c>.
        /// </value>
        public PProduction AsPProduction
        {
            get { return IsPProduction ? (this as DeclarationIdentifier<PProduction>).Declaration : null; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="PAlternative"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="PAlternative"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsPAlternative
        {
            get { return this is DeclarationIdentifier<PAlternative>; }
        }
        /// <summary>
        /// Gets the alternative name associated with this identifier, as a <see cref="PAlternative"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="PAlternative"/> if this identifier refers to a <see cref="PAlternative"/>; otherwise, <c>null</c>.
        /// </value>
        public PAlternative AsPAlternative
        {
            get { return IsPAlternative ? (this as DeclarationIdentifier<PAlternative>).Declaration : null; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="PElement"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="PElement"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsPElement
        {
            get { return this is DeclarationIdentifier<PElement>; }
        }
        /// <summary>
        /// Gets the element name associated with this identifier, as a <see cref="PElement"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="ElementNameIdentifier"/> if this identifier refers to a <see cref="PElement"/>; otherwise, <c>null</c>.
        /// </value>
        public PElement AsPElement
        {
            get { return IsPElement ? (this as DeclarationIdentifier<PElement>).Declaration : null; }
        }

        /// <summary>
        /// Gets a value indicating whether this identifier refers to a <see cref="PHighlightrule"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this identifier refers to a <see cref="PHighlightrule"/>; otherwise, <c>false</c>.
        /// </value>
        public bool IsPHighlightrule
        {
            get { return this is DeclarationIdentifier<PHighlightrule>; }
        }
        /// <summary>
        /// Gets the highlighter rule associated with this identifier, as a <see cref="PHighlightrule"/>.
        /// </summary>
        /// <value>
        ///   A <see cref="PHighlightrule"/> if this identifier refers to a <see cref="PHighlightrule"/>; otherwise, <c>null</c>.
        /// </value>
        public PHighlightrule AsPHighlightrule
        {
            get { return IsPHighlightrule ? (this as DeclarationIdentifier<PHighlightrule>).Declaration : null; }
        }
    }
}
