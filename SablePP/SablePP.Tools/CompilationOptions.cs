using SablePP.Tools.Error;
using SablePP.Tools.Nodes;
using System;

namespace SablePP.Tools
{
    /// <summary>
    /// Groups methods related to performing compilation tasks - after the lexer and parser have finished executing.
    /// </summary>
    public class CompilationOptions
    {
        private ErrorManager errorManager;
        private Action<IHighlighter> highlight;
        internal bool active;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilationOptions"/> class.
        /// </summary>
        /// <param name="errorManager">An <see cref="ErrorManager"/> where all validation errors can be registered.</param>
        /// <param name="highlight">A method for applying a token syntax highlight using a <see cref="IHighlighter"/>.</param>
        public CompilationOptions(ErrorManager errorManager, Action<IHighlighter> highlight)
        {
            this.errorManager = errorManager;
            this.highlight = highlight;
            this.active = false;
        }

        /// <summary>
        /// Gets the <see cref="ErrorManager"/> to which errors should be registered.
        /// </summary>
        public ErrorManager ErrorManager
        {
            get { return errorManager; }
        }

        /// <summary>
        /// Performs token syntax highlighting using the specified highlighter.
        /// </summary>
        /// <param name="highlighter">A <see cref="IHighlighter"/> used to perform syntax highlighting.</param>
        public void Highlight(IHighlighter highlighter)
        {
            if (active)
                highlight(highlighter);
        }
    }
}
