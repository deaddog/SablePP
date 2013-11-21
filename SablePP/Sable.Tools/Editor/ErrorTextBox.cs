﻿using System;
using System.Text;

using FastColoredTextBoxNS;
using Sable.Tools.Error;

namespace Sable.Tools.Editor
{
    public class ErrorTextBox : FastColoredTextBox
    {
        public ErrorTextBox()
            : base()
        {
        }

        public void AddError(CompilerError error)
        {
            string text;

            if (error.Start.LinePosition < 0 || error.Start.LineNumber < 0)
                text = "[N/A] " + error.ErrorMessage;
            else
                text = string.Format("[{0}, {1}] {2}", error.Start.LineNumber + 1, error.Start.LinePosition + 1, error.ErrorMessage);

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
