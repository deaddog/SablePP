using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// Represents the method that will handle the <see cref="EditorForm.FileOpened"/> event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="FileOpenedEventArgs"/> instance containing the event data.</param>
    public delegate void FileOpenedEventHandler(object sender, FileOpenedEventArgs e);
}
