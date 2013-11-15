using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using FastColoredTextBoxNS;

namespace Sable.Tools.Editor
{
    public class CodeTextBox : FastColoredTextBox
    {
        private SquigglyStyle errorStyle;
        private Dictionary<Range, string> tooltipMessages;
        private List<Range> directDrawErrors;

        public CodeTextBox()
            : base()
        {
            errorStyle = new SquigglyStyle(Pens.Red);
            tooltipMessages = new Dictionary<Range, string>();
            directDrawErrors = new List<Range>();

            this.ToolTipNeeded += CodeTextBox_ToolTipNeeded;
        }

        public void AddError(Range range, string message)
        {
            if (range.Start.iChar < 0 || range.Start.iLine < 0 || range.End.iChar < 0 || range.End.iLine < 0)
                return;

            if (!range.Chars.Any())
                directDrawErrors.Add(range);
            else
                range.SetStyle(errorStyle);
            tooltipMessages.Add(range, message);
        }
        public void ClearErrors()
        {
            directDrawErrors.Clear();
            this.Range.ClearStyle(errorStyle);
            this.tooltipMessages.Clear();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var r in directDrawErrors)
                errorStyle.Draw(e.Graphics, PlaceToPoint(r.Start), r);
        }

        void CodeTextBox_ToolTipNeeded(object sender, ToolTipNeededEventArgs e)
        {
            foreach (var r in tooltipMessages.Keys)
                if (r.Contains(e.Place))
                {
                    e.ToolTipText = tooltipMessages[r];
                    break;
                }
        }
    }
}
