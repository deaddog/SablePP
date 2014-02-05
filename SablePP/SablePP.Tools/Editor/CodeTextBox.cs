using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;

using FastColoredTextBoxNS;
using SablePP.Tools.Error;
using SablePP.Tools.Lexing;
using SablePP.Tools.Nodes;
using SablePP.Tools.Parsing;

namespace SablePP.Tools.Editor
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
        private Result lastResult;
        private List<Style> simpleStyles;
        private List<Style> moreStyles;

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
            this.lastResult = null;
            this.simpleStyles = new List<Style>();
            this.moreStyles = new List<Style>();

            this.ToolTipNeeded += CodeTextBox_ToolTipNeeded;
        }

        [Browsable(false), DefaultValue(null)]
        public ICompilerExecuter Executer
        {
            get { return executer; }
            set
            {
                executer = value;
                this.OnTextChangedDelayed(this.Range);
            }
        }

        [Browsable(false)]
        public Result LastResult
        {
            get { return lastResult; }
        }

        public Result WaitForResult()
        {
            Result result = null;

            compileWorker.WaitForCompletion();

            result = this.lastResult;

            return result;
        }

        public void SetStyle(Token token, Style style)
        {
            GetRangeFromToken(token).SetStyle(style);
        }
        public Range GetRangeFromToken(Token token)
        {
            string text = token.Text;

            Place p1 = new Place(token.Position - 1, token.Line - 1);
            Place p2 = new Place(token.Position - 1, token.Line - 1);

            int len = text.Length;
            while (text.Contains('\r'))
            {
                len -= (text.IndexOf('\r') + 2);
                text = text.Substring(text.IndexOf('\r')).Trim('\r', '\n');
                p2.iLine++;
                p2.iChar = 0;
            }
            p2.iChar += len;
            return new Range(this, p1, p2);
        }

        private void addError(CompilerError error)
        {
            Range range = new Range(this,
                error.Start.LinePosition - 1, error.Start.LineNumber - 1,
                error.End.LinePosition, error.End.LineNumber - 1);

            if (!(range.Start.iChar < 1 && range.Start.iLine < 1 && range.End.iChar < 1 && range.End.iLine < 1))
            {
                if (range.GetIntersectionWith(this.Range).IsEmpty)
                    directDrawErrors.Add(range);
                else
                    range.SetStyle(errorStyle);
                tooltipMessages.Add(range, error.ErrorMessage);
            }

            if (ErrorAdded != null)
                ErrorAdded(this, new ErrorEventArgs(error));
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

        public override void OnTextChangedDelayed(Range changedRange)
        {
            if (executer != null && this.Enabled)
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
                        changedRange.ClearStyle(simpleStyles.ToArray());
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

            base.OnTextChangedDelayed(changedRange);
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
            private bool waitFlag = false;

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
                waitFlag = true;
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

                CompilationOptions compilationOptions = new CompilationOptions(errorManager);

                if (root != null)
                    executer.Validate(root, compilationOptions);

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
                        parent.addError(err);
                }

                parent.lastResult = new Result(node, errors);
                waitFlag = false;

                if (shouldStart)
                    restart();
            }

            public void WaitForCompletion()
            {
                bool waitAgain = false;
                while (waitFlag) { }
                while (shouldStart) { waitAgain = true; }

                if (waitAgain)
                    while (waitFlag) { }

                if (parent.lastResult == null)
                {
                    while (!IsBusy) { }
                    WaitForCompletion();
                }
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

            private class HighlightWalker : SablePP.Tools.Analysis.DepthFirstTreeWalker
            {
                private CodeTextBox parent;
                private IHighlighter highlighter;
                public HighlightWalker(CodeTextBox parent, IHighlighter highlighter)
                {
                    this.parent = parent;
                    this.highlighter = highlighter;
                }

                public override void Visit(Token token)
                {
                    var s = highlighter.GetStyle(token);
                    if (s != null)
                    {
                        if (!parent.moreStyles.Contains(s))
                            parent.moreStyles.Add(s);
                        parent.SetStyle(token, s);
                    }
                }
            }
        }

        public class Result
        {
            public DateTime CompileTime { get; private set; }
            public Node Tree { get; private set; }
            public CompilerError[] Errors { get; private set; }

            public Result(Node tree, IEnumerable<CompilerError> errors)
            {
                this.CompileTime = DateTime.Now;

                this.Tree = tree;
                this.Errors = errors.ToArray();
            }
        }
    }
}
