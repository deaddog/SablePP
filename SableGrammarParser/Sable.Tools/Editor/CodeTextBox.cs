﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;

using FastColoredTextBoxNS;
using Sable.Tools.Error;
using Sable.Tools.Lexing;
using Sable.Tools.Nodes;
using Sable.Tools.Parsing;

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

        private CompileWorker compileWorker;

        private List<Style> simpleStyles;

        public CodeTextBox()
            : base()
        {
            errorStyle = new SquigglyStyle(Pens.Red);
            tooltipMessages = new Dictionary<Range, string>();
            directDrawErrors = new List<Range>();

            this.executer = null;
            this.lexer = null;
            this.lexerError = true;

            this.compileWorker = new CompileWorker(this);

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

            if (ErrorAdded != null)
                ErrorAdded(this, new ErrorEventArgs(range.Start, range.End, message));
        }
        private void clearErrors()
        {
            directDrawErrors.Clear();
            this.Range.ClearStyle(errorStyle);
            this.tooltipMessages.Clear();

            if (ErrorsCleared != null)
                ErrorsCleared(this, EventArgs.Empty);
        }

        public event EventHandler ErrorsCleared;
        public event ErrorEventHandler ErrorAdded;

        protected override void OnTextChanged(TextChangedEventArgs args)
        {
            if (executer != null)
                lock (lexerLock)
                {
                    StringReader reader = new StringReader(this.Text);
                    lexer = new ResetableLexer(executer.GetLexer(reader));

                    lexerError = false;
                    try { while (!(lexer.Next() is EOF)) { } }
                    catch (LexerException ex) { lexerError = true; }
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
                    lexer.Reset();
                    compileWorker.Start(executer, lexer);
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

        private class CompileWorker : BackgroundWorker
        {
            private CodeTextBox parent;
            private ICompilerExecuter executer;
            private ILexer lexer;
            private ICompilerExecuter nextExecuter;
            private ILexer nextLexer;

            private bool shouldStart;

            public CompileWorker(CodeTextBox parent)
            {
                this.parent = parent;
                this.executer = null;
                this.lexer = null;
                this.shouldStart = false;
            }

            public void Start(ICompilerExecuter executer, ILexer lexer)
            {
                this.nextExecuter = executer;
                this.nextLexer = lexer;

                this.shouldStart = true;

                if (!this.IsBusy)
                {
                    this.lexer = nextLexer;
                    this.executer = nextExecuter;

                    shouldStart = false;
                    RunWorkerAsync();
                }
            }
            private void restart()
            {
                if (!this.IsBusy)
                {
                    this.lexer = nextLexer;
                    this.executer = nextExecuter;

                    shouldStart = false;
                    RunWorkerAsync();
                }
            }

            protected override void OnDoWork(DoWorkEventArgs e)
            {
                IParser parser = executer.GetParser(lexer);
                ErrorManager errorManager = new ErrorManager();

                Node root;
                try { root = parser.Parse(); }
                catch (LexerException ex)
                {
                    errorManager.Register(new CompilerError(ex.Line, ex.Position, 1, ex.Message));
                    root = null;
                }
                catch (ParserException ex)
                {
                    errorManager.Register(new CompilerError(ex.LastLine, ex.LastPosition, 1, ex.Message));
                    root = null;
                }

                if (root != null)
                    executer.Validate(root, errorManager);

                e.Result = storeRootAndErrors(root, errorManager);
            }
            protected override void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
            {
                Node node;
                CompilerError[] errors;

                if (loadRootAndErrors(e.Result, out node, out errors))
                {
                    parent.clearErrors();
                    foreach (var err in errors)
                    {
                        Range r = new Range(parent, err.Start.LinePosition - 1, err.Start.LineNumber - 1, err.End.LinePosition, err.End.LineNumber - 1);
                        parent.addError(r, err.ErrorMessage);
                    }
                }

                if (shouldStart)
                    restart();
            }

            private object storeRootAndErrors(Node root, IEnumerable<CompilerError> errors)
            {
                return new { Root = root, Errors = errors.ToArray() };
            }
            private bool loadRootAndErrors(object arg, out Node root, out CompilerError[] errors)
            {
                if (arg == null)
                {
                    root = null;
                    errors = null;
                    return false;
                }

                dynamic loaded = arg;
                root = loaded.Root;
                errors = loaded.Errors;

                return true;
            }
        }
    }
}
