namespace SablePP.Compiler.Nodes
{
    public partial class PToken
    {
        private bool? ignored = null;
        public bool IsIgnored
        {
            get { return ignored.HasValue ? ignored.Value : false; }
            set { ignored = value; }
        }

        private PHighlightrule highlight = null;
        public bool HasHighlighting
        {
            get { return highlight != null; }
        }
        public PHighlightrule Highlighting
        {
            get { return highlight; }
            set { highlight = value; }
        }

        public string ClassName
        {
            get { return "T" + this.Identifier.Text.ToCamelCase(); }
        }
    }
}
