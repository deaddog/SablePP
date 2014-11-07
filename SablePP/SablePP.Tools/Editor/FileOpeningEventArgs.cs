using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// Provides data for the <see cref="EditorForm.FileOpening"/> event.
    /// </summary>
    public class FileOpeningEventArgs : EventArgs
    {
        private string filepath;
        private bool allowfile;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOpeningEventArgs"/> class.
        /// </summary>
        /// <param name="filepath">The filepath of the file being opened.</param>
        /// <param name="initialAllow">An initial value for whether <paramref name="filepath"/> can be opened.</param>
        public FileOpeningEventArgs(string filepath, bool initialAllow)
        {
            this.filepath = filepath;
            this.allowfile = initialAllow;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOpeningEventArgs"/> class.
        /// </summary>
        /// <param name="filepath">The filepath of the file being opened.</param>
        /// <param name="allowedExtension">The extension allowed for files opened. This sets the <see cref="AllowFile"/> property.</param>
        public FileOpeningEventArgs(string filepath, string allowedExtension)
            : this(filepath, Path.GetExtension(filepath).TrimStart('.').ToLower() == allowedExtension.TrimStart('.').ToLower())
        {

        }

        /// <summary>
        /// Gets the filepath of the file being opened.
        /// </summary>
        public string Filepath
        {
            get { return filepath; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether <see cref="Filepath"/> can be opened.
        /// </summary>
        public bool AllowFile
        {
            get { return allowfile; }
            set { allowfile = value; }
        }
    }
}
