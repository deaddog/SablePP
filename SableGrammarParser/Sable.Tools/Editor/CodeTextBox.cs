using System;
using System.Drawing;
using System.Text;

using FastColoredTextBoxNS;

namespace Sable.Tools.Editor
{
    public class CodeTextBox : FastColoredTextBox
    {
        private SquigglyStyle errorStyle = new SquigglyStyle(Pens.Red);

        public CodeTextBox()
            : base()
        {
        }

        public void AddError(string text)
        {
        }
        public void ClearErrors()
        {
        }
    }
}
