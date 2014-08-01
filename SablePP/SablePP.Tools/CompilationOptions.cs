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
        private string input;
        private ErrorManager errorManager;
        private Action<IHighlighter> highlight;
        internal bool active;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilationOptions" /> class.
        /// </summary>
        /// <param name="input">The code input for the compiler.</param>
        /// <param name="errorManager">An <see cref="ErrorManager" /> where all validation errors can be registered.</param>
        /// <param name="highlight">A method for applying a token syntax highlight using a <see cref="IHighlighter" />.</param>
        public CompilationOptions(string input, ErrorManager errorManager, Action<IHighlighter> highlight)
        {
            this.input = input;
            this.errorManager = errorManager;
            this.highlight = highlight;
            this.active = false;
        }

        /// <summary>
        /// Gets the code input for the compiler.
        /// </summary>
        public string Input
        {
            get { return input; }
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
