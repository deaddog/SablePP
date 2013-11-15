using System;
using System.Text;

using FastColoredTextBoxNS;

namespace Sable.Tools.Editor
{
    public class ErrorTextBox : FastColoredTextBox
    {
        public ErrorTextBox()
            : base()
        {
        }

        public void AddError(Range range, string message)
        {
            string text;

            if (range.Start.iChar < 0 || range.Start.iLine < 0 || range.End.iChar < 0 || range.End.iLine < 0)
                text = "[N/A] " + message;
            else
                text = string.Format("[{0}, {1}] ", range.Start.iLine + 1, range.Start.iChar + 1) + message;

            if (this.Text.Length == 0)
                this.Text = text;
            else
                this.Text += "\r\n" + text;
        }
        public void ClearErrors()
        {
            this.Text = "";
        }
    }
}
