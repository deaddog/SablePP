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
            if (this.Text.Length == 0)
                this.Text = message;
            else
                this.Text += "\r\n" + message;
        }
        public void ClearErrors()
        {
            this.Text = "";
        }
    }
}
