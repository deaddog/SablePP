using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// Represents the content of a file loaded using the <see cref="EditorForm.FileOpened"/> event.
    /// </summary>
    public class FileOpenedEventArgs : EventArgs
    {
        private string content;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOpenedEventArgs"/> class.
        /// </summary>
        /// <param name="content">The content of the loaded file.</param>
        public FileOpenedEventArgs(string content)
        {
            this.content = content;
        }

        /// <summary>
        /// Gets the content of the loaded file.
        /// </summary>
        public string Content
        {
            get { return content; }
        }
    }
}
