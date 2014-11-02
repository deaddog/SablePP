using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// Represents the method that will handle the <see cref="EditorForm.FileSaving"/> event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="FileSavingEventArgs"/> instance containing the event data.</param>
    public delegate void FileSavingEventHandler(object sender, FileSavingEventArgs e);
}
