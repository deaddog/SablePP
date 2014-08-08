namespace SablePP.Tools.Generate
{
    /// <summary>
    /// Represents a leaf element, containing nothing but text, in a composite structure of code generation.
    /// </summary>
    public sealed class TextElement : CodeElement
    {
        private UseSpace prepend, append;
        private string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextElement"/> class.
        /// </summary>
        /// <param name="text">The text stored in this <see cref="TextElement"/>.</param>
        /// <param name="prepend">A <see cref="UseSpace"/> determining if this <see cref="TextElement"/> should be prepended with a space.</param>
        /// <param name="append">A <see cref="UseSpace"/> determining if this <see cref="TextElement"/> should be appended with a space.</param>
        public TextElement(string text, UseSpace prepend, UseSpace append)
        {
            this.text = text;
            this.prepend = prepend;
            this.append = append;
        }

        internal override UseSpace Append
        {
            get { return append; }
        }
        internal override UseSpace Prepend
        {
            get { return prepend; }
        }

        /// <summary>
        /// Gets the text stored in this <see cref="TextElement"/>.
        /// </summary>
        public string Text
        {
            get { return text; }
        }

        /// <summary>
        /// Appends text to this <see cref="TextElement"/> using spacing rules.
        /// </summary>
        /// <param name="text">The text that is appended to the <see cref="TextElement"/>.</param>
        /// <param name="prepend">A <see cref="UseSpace"/> determining if a space should be inserted between the existing text and <paramref name="text"/>.</param>
        /// <param name="append">A <see cref="UseSpace"/> determining if this <see cref="TextElement"/> should be appended with a space after appending <paramref name="text"/>.</param>
        public void AppendText(string text, UseSpace prepend, UseSpace append)
        {
            this.text = this.text + (useSpace(this.Append, prepend) ? " " : "") + text;
            this.append = append;
        }

        internal override void Generate(CodeStreamWriter streamwriter)
        {
            streamwriter.WriteString(text);
        }

        /// <summary>
        /// Returns the text contained by this <see cref="TextElement"/>.
        /// </summary>
        public override string ToString()
        {
            return text;
        }
    }
}
