namespace Sable.Tools.Generate
{
    internal sealed class TextElement : CodeElement
    {
        private UseSpace prepend, append;
        private string text;

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

        public void AppendText(string text, UseSpace prepend, UseSpace append)
        {
            this.text = this.text + (useSpace(this.Append, prepend) ? " " : "") + text;
            this.append = append;
        }

        internal override void Generate(CodeStreamWriter streamwriter)
        {
            streamwriter.WriteString(text);
            streamwriter.LastElement = this;
        }

        public override string ToString()
        {
            return text;
        }
    }
}
