namespace SablePP.Tools.Editor
{
    /// <summary>
    /// Represents the method that will handle the <see cref="CodeTextBox.ErrorAdded"/> event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ErrorEventArgs"/> instance containing the event data.</param>
    public delegate void ErrorEventHandler(object sender, ErrorEventArgs e);
}
