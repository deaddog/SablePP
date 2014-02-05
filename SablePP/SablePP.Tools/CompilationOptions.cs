using SablePP.Tools.Error;
using SablePP.Tools.Nodes;
using System;

namespace SablePP.Tools
{
    public class CompilationOptions<T>
        where T : Node
    {
        private Start<T> root;
        private ErrorManager errorManager;
        private Action<IHighlighter> highlight;
        internal bool active;

        public CompilationOptions(Start<T> root, ErrorManager errorManager, Action<IHighlighter> highlight)
        {
            this.root = root;
            this.errorManager = errorManager;
            this.highlight = highlight;
            this.active = false;
        }

        public Start<T> Root
        {
            get { return root; }
        }
        public ErrorManager ErrorManager
        {
            get { return errorManager; }
        }

        public void Highlight(IHighlighter highlighter)
        {
            if (active)
                highlight(highlighter);
        }
    }
}
