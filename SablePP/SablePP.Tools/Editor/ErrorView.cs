using SablePP.Tools.Error;
using System;
using System.Windows.Forms;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// A <see cref="ListView"/> capable of displaying error messages.
    /// </summary>
    public class ErrorView : ListView
    {
        public ErrorView()
            : base()
        {
        }

        /// <summary>
        /// Adds a <see cref="CompilerError"/> error to the <see cref="ErrorView"/>.
        /// </summary>
        /// <param name="error">The error that should be added to the <see cref="ErrorView"/>.</param>
        public void AddError(CompilerError error)
        {
        }
        /// <summary>
        /// Clears all errors from the <see cref="ErrorView"/>.
        /// </summary>
        public void ClearErrors()
        {
            this.Items.Clear();
        }
    }
}
