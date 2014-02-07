using System;
using System.Drawing;
using System.Collections.Generic;

using FastColoredTextBoxNS;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// Defines a <see cref="Style"/> for marking errors in the <see cref="CodeTextBox"/> using a squiggly/zig-zag line.
    /// </summary>
    public class SquigglyStyle : Style
    {
        private const float step = 2;

        private Pen pen;

        /// <summary>
        /// Initializes a new instance of the <see cref="SquigglyStyle"/> class.
        /// </summary>
        /// <param name="underline">The <see cref="Pen"/> used to draw squiggly lines.</param>
        public SquigglyStyle(Pen underline)
        {
            this.pen = underline;
        }

#pragma warning disable 1591
        public override void Draw(System.Drawing.Graphics gr, System.Drawing.Point position, Range range)
        {
            RectangleF rect = new RectangleF(
                position.X,
                position.Y,
                (range.End.iChar - range.Start.iChar) * range.tb.CharWidth,
                range.tb.CharHeight);

            List<PointF> points = new List<PointF>()
            {
                new PointF(rect.X - 1.5f, rect.Y + rect.Height - step / 2f)
            };

            bool up = false;
            while (points[points.Count - 1].X < rect.X + rect.Width)
            {
                PointF last = points[points.Count - 1];
                points.Add(new PointF(last.X + step, last.Y + (up ? -step : step)));
                up = !up;
            }
            gr.DrawLines(pen, points.ToArray());
        }
#pragma warning restore
    }
}
