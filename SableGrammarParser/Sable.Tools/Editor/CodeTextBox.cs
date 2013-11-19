﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using FastColoredTextBoxNS;
using Sable.Tools.Error;
using Sable.Tools.Lexing;
using Sable.Tools.Nodes;

namespace Sable.Tools.Editor
{
    public class CodeTextBox : FastColoredTextBox
    {
        private SquigglyStyle errorStyle;
        private Dictionary<Range, string> tooltipMessages;
        private List<Range> directDrawErrors;

        private ICompilerExecuter executer;
        private ResetableLexer lexer;

        private object lexerLock = new object();
        private bool lexerError;

        public CodeTextBox()
            : base()
        {
            errorStyle = new SquigglyStyle(Pens.Red);
            tooltipMessages = new Dictionary<Range, string>();
            directDrawErrors = new List<Range>();

            this.executer = null;
            this.lexer = null;
            this.lexerError = true;

            this.ToolTipNeeded += CodeTextBox_ToolTipNeeded;
        }

        public ICompilerExecuter Executer
        {
            get { return executer; }
            set
            {
                executer = value;
                this.OnTextChanged(this.Range);
            }
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

        public override void OnTextChanged(Range r)
        {
            StringReader reader = new StringReader(this.Text);

            lock (lexerLock)
            {
                lexer = new ResetableLexer(executer.GetLexer(reader));

                lexerError = false;
                try
                {
                    while (!(lexer.Next() is EOF)) { }
                }
                catch (LexerException ex)
                {
                    lexerError = true;
                    Range range = this.GetRange(new Place(ex.Position, ex.Line), new Place(ex.Position + 1, ex.Line));
                    AddError(range, ex.Message);
                }
                lexer.Reset();
            }

            base.OnTextChanged(r);
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
