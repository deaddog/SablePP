using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using FastColoredTextBoxNS;

namespace Sable.Tools.Editor
{
    public class CodeTextBox : FastColoredTextBox
    {
        private SquigglyStyle errorStyle;
        private List<Range> directDrawErrors;

        public CodeTextBox()
            : base()
        {
            errorStyle = new SquigglyStyle(Pens.Red);
            directDrawErrors = new List<Range>();
        }

        public void AddError(Range range, string message)
        {
            if (range.Start == range.End)
                directDrawErrors.Add(range);
            else
                range.SetStyle(errorStyle);
        }
        public void ClearErrors()
        {
            directDrawErrors.Clear();
            this.Range.ClearStyle(errorStyle);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var r in directDrawErrors)
                errorStyle.Draw(e.Graphics, PlaceToPoint(r.Start), r);
        }
    }
}
