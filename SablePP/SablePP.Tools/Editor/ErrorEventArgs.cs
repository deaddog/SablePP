using System;
using SablePP.Tools.Error;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// Provides data for the <see cref="CodeTextBox.ErrorAdded"/> event
    /// </summary>
    public class ErrorEventArgs : EventArgs
    {
        private CompilerError error;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorEventArgs"/> class.
        /// </summary>
        /// <param name="error">The <see cref="CompilerError"/> that was added to a <see cref="CodeTextBox"/>.</param>
        public ErrorEventArgs(CompilerError error)
        {
            this.error = error;
        }

        /// <summary>
        /// Gets the error that has been added to a <see cref="CodeTextBox"/>.
        /// </summary>
        public CompilerError Error
        {
            get { return error; }
        }
    }
}
