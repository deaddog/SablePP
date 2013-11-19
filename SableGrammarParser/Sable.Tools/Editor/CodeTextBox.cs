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

        private List<Style> simpleStyles;

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

            this.simpleStyles = new List<Style>();

            this.ToolTipNeeded += CodeTextBox_ToolTipNeeded;
        }

        public ICompilerExecuter Executer
        {
            get { return executer; }
            set
            {
                executer = value;
                this.OnTextChanged(new TextChangedEventArgs(this.Range));
            }
        }

        private void addError(Range range, string message)
        {
            if (range.Start.iChar < 0 || range.Start.iLine < 0 || range.End.iChar < 0 || range.End.iLine < 0)
                return;
            if (range.GetIntersectionWith(this.Range).IsEmpty)
                directDrawErrors.Add(range);
            else
                range.SetStyle(errorStyle);
            tooltipMessages.Add(range, message);
        }
        private void clearErrors()
        {
            directDrawErrors.Clear();
            this.Range.ClearStyle(errorStyle);
            this.tooltipMessages.Clear();
        }

        protected override void OnTextChanged(TextChangedEventArgs args)
        {
            if (executer != null)
                lock (lexerLock)
                {
                    StringReader reader = new StringReader(this.Text);
                    lexer = new ResetableLexer(executer.GetLexer(reader));
                    clearErrors();

                    lexerError = false;
                    try
                    {
                        while (!(lexer.Next() is EOF)) { }
                    }
                    catch (LexerException ex)
                    {
                        lexerError = true;
                        Range range = this.GetRange(new Place(ex.Position - 1, ex.Line - 1), new Place(ex.Position, ex.Line - 1));
                        addError(range, ex.Message);
                    }
                    lexer.Reset();
                    reader.Dispose();

                    if (lexerError)
                        args.ChangedRange.ClearStyle(simpleStyles.ToArray());
                    else
                    {
                        this.Range.ClearStyle(simpleStyles.ToArray());
                        while (!(lexer.Peek() is EOF))
                        {
                            Token token = lexer.Next();
                            Style style = executer.GetSimpleStyle(token);
                            if (style != null)
                            {
                                if (!simpleStyles.Contains(style))
                                    simpleStyles.Add(style);
                                this.SetStyle(token, style);
                            }
                        }
                    }
                }

            base.OnTextChanged(args);
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
