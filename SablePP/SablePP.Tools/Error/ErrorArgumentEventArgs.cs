using System;
using System.Text;

namespace SablePP.Tools.Error
{
    /// <summary>
    /// Provides data for the <see cref="ErrorManager.TranslateArgument"/> event.
    /// </summary>
    public class ErrorArgumentEventArgs : EventArgs
    {
        private object argument;
        private string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorArgumentEventArgs"/> class.
        /// </summary>
        /// <param name="argument">The argument that is to be translated.</param>
        public ErrorArgumentEventArgs(object argument)
        {
            this.argument = argument;
            this.text = argument.ToString();
        }

        /// <summary>
        /// Gets the argument that is translated into a string.
        /// </summary>
        public object Argument
        {
            get { return argument; }
        }
        /// <summary>
        /// Gets or sets the string representation of <see cref="Argument"/>.
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }
}
