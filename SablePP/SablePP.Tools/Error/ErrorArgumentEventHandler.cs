namespace SablePP.Tools.Error
{
    /// <summary>
    /// Represents a method that will handle the <see cref="ErrorManager.TranslateArgument"/> event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="ErrorArgumentEventArgs"/> instance containing the event data.</param>
    public delegate void ErrorArgumentEventHandler(object sender, ErrorArgumentEventArgs e);
}
