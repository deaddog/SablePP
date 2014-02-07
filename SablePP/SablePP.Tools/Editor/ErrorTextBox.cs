using System;
using System.Text;

using FastColoredTextBoxNS;
using SablePP.Tools.Error;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// A very simple textbox capable of displaying a list of compiler errors.
    /// </summary>
    public class ErrorTextBox : FastColoredTextBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorTextBox"/> class.
        /// </summary>
        public ErrorTextBox()
            : base()
        {
        }

        /// <summary>
        /// Adds a <see cref="CompilerError"/> error to the <see cref="ErrorTextBox"/>.
        /// </summary>
        /// <param name="error">The error that should be added to the <see cref="ErrorTextBox"/>.</param>
        public void AddError(CompilerError error)
        {
            string text;

            if (error.Start.LinePosition <= 0 || error.Start.LineNumber <= 0)
                text = "[N/A] " + error.ErrorMessage;
            else
                text = string.Format("[{0}, {1}] {2}", error.Start.LineNumber, error.Start.LinePosition, error.ErrorMessage);

            if (this.Text.Length == 0)
                this.Text = text;
            else
                this.Text += "\r\n" + text;
        }
        /// <summary>
        /// Clears all errors from the <see cref="ErrorTextBox"/>.
        /// </summary>
        public void ClearErrors()
        {
            this.Text = "";
        }
    }
}
