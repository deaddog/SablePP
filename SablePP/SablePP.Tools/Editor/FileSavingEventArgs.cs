using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// Represents the content saved to a file using the <see cref="EditorForm.FileSaving"/> event.
    /// </summary>
    public class FileSavingEventArgs: EventArgs
    {
        private string content;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSavingEventArgs"/> class.
        /// </summary>
        public FileSavingEventArgs()
        {
            this.content = "";
        }

        /// <summary>
        /// Gets or sets the content that is written to the save file.
        /// </summary>
        public string Content
        {
            get { return content; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                else
                    this.content = value;
            }
        }
    }
}
