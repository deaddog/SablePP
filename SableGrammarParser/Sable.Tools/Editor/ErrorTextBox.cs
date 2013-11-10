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

        public void AddError(string text)
        {
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
