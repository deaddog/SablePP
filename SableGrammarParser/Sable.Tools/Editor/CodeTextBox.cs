using System;
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
            compileWorker.Start();
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
                    lexer.Reset();
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

            private bool shouldStart;

            public CompileWorker(CodeTextBox parent)
            {
                this.parent = parent;
                this.executer = null;
                this.lexer = null;
                this.shouldStart = false;
            }

            public void Start()
            {
                if (!this.IsBusy)
                {
                    shouldStart = false;
                    RunWorkerAsync();
                }
            }

            protected override void OnDoWork(DoWorkEventArgs e)
            {
                if (!SetExecuterAndLexer())
                    return;

                IParser parser = executer.GetParser(lexer);
                Node root = parser.Parse();

                ErrorManager errorManager = new ErrorManager();
                executer.Validate(root, errorManager);

                e.Result = storeRootAndErrors(root, errorManager);
            }
            protected override void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
            {
                Node node;
                CompilerError[] errors;
                loadRootAndErrors(e.Result, out node, out errors);

                if (shouldStart)
                    Start();
            }

            private bool SetExecuterAndLexer()
            {
                lock (parent.lexerLock)
                {
                    this.executer = parent.executer;
                    this.lexer = parent.lexer;
                }

                return this.executer != null && this.lexer != null;
            }

            private object storeRootAndErrors(Node root, IEnumerable<CompilerError> errors)
            {
                return new { Root = root, Errors = errors.ToArray() };
            }
            private void loadRootAndErrors(object arg, out Node root, out CompilerError[] errors)
            {
                dynamic loaded = arg;
                root = loaded.Root;
                errors = loaded.Errors;
            }
        }
    }
}
