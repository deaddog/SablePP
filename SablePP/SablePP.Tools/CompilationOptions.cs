using SablePP.Tools.Error;
using SablePP.Tools.Nodes;
using System;

namespace SablePP.Tools
{
    public class CompilationOptions
    {
        private ErrorManager errorManager;
        private Action<IHighlighter> highlight;
        internal bool active;

        public CompilationOptions(ErrorManager errorManager, Action<IHighlighter> highlight)
        {
            this.errorManager = errorManager;
            this.highlight = highlight;
            this.active = false;
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
