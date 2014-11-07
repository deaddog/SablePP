﻿using System;
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
    /// <summary>
    /// A syntax highlighting textbox that uses a <see cref="ICompilerExecuter"/> to invoke compilation, validation and syntax highlighting.
    /// This class can be used without the use of the <see cref="EditorForm"/>.
    /// </summary>
    public class CodeTextBox : FastColoredTextBox
    {
        private SquigglyStyle errorStyle, warningStyle, messageStyle;
        private Dictionary<Range, string> tooltipMessages;
        private Dictionary<Range, SquigglyStyle> directDrawErrors;

        private ICompilerExecuter executer;
        private ResetableLexer lexer;
        private object lexerLock = new object();
        private bool lexerError;

        private CompileWorker compileWorker;
        private Result lastResult;
        private List<Style> simpleStyles;
        private List<Style> moreStyles;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeTextBox"/> class.
        /// </summary>
        public CodeTextBox()
            : base()
        {
            errorStyle = new SquigglyStyle(Pens.Red);
            warningStyle = new SquigglyStyle(new Pen(Color.FromArgb(48, 150, 49)));
            messageStyle = new SquigglyStyle(Pens.DodgerBlue);
            tooltipMessages = new Dictionary<Range, string>();
            directDrawErrors = new Dictionary<Range, SquigglyStyle>();

            this.executer = null;
            this.lexer = null;
            this.lexerError = true;

            this.compileWorker = new CompileWorker(this);
            this.lastResult = null;
            this.simpleStyles = new List<Style>();
            this.moreStyles = new List<Style>();

            this.ToolTipNeeded += CodeTextBox_ToolTipNeeded;
        }

        /// <summary>
        /// Gets or sets the <see cref="ICompilerExecuter"/> used by this <see cref="CodeTextBox"/>.
        /// </summary>
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

        /// <summary>
        /// Gets the last compilation <see cref="Result"/> generated by the <see cref="ICompilerExecuter"/>.
        /// Consider using the <see cref="WaitForResult"/> method if the most resent result is required.
        /// </summary>
        [Browsable(false)]
        public Result LastResult
        {
            get { return lastResult; }
        }

        /// <summary>
        /// Waits for the current compilation process to finish and returns its <see cref="Result"/>.
        /// </summary>
        /// <returns>A <see cref="Result"/> detailing the result of the currently executing compilation process.</returns>
        public Result WaitForResult()
        {
            Result result = null;

            compileWorker.WaitForCompletion();

            result = this.lastResult;

            return result;
        }

        /// <summary>
        /// Occurs when the <see cref="ICompilerExecuter"/> associated with this <see cref="CodeTextBox"/> is done compiling an AST.
        /// The event is raised regardless of the result of the compilation.
        /// The event is never raised when the <see cref="CodeTextBox"/> is not associated with an <see cref="ICompilerExecuter"/>.
        /// </summary>
        public event EventHandler CompilationCompleted;

        private void setStyle(Token token, Style style)
        {
            if ((from s in Styles where s != null select s).Count() >= 16 && !Styles.Contains(style))
                this.ClearStylesBuffer();
            RangeFromToken(token).SetStyle(style);
        }

        /// <summary>
        /// Gets the <see cref="Range"/> in this <see cref="CodeTextBox"/> of a <see cref="Token"/>.
        /// </summary>
        /// <param name="token">The <see cref="Token"/> from which <see cref="Range"/> should be retrieved..</param>
        /// <returns>A <see cref="Range"/> representing the location of <paramref name="token"/> in this <see cref="CodeTextBox"/>.</returns>
        public Range RangeFromToken(Token token)
        {
            string text = token.Text;

            Place p1 = new Place(token.Position - 1, token.Line - 1);
            Place p2 = new Place(token.Position - 1, token.Line - 1);

            int len = text.Length;
            while (text.Contains('\r'))
            {
                int index = text.IndexOf('\r');
                len -= index + 2;
                text = text.Substring(index + 2);

                p2.iLine++;
                p2.iChar = 0;
            }
            p2.iChar += len;
            return new Range(this, p1, p2);
        }
        /// <summary>
        /// Gets the <see cref="Token"/> located at <paramref name="place"/> in this <see cref="CodeTextBox"/>.
        /// Tokens are found in the <see cref="LastResult"/> property.
        /// </summary>
        /// <param name="place">The place to look for a <see cref="Token"/>.</param>
        /// <returns>The <see cref="Token"/> located at <paramref name="place"/>, if any; otherwise <c>null</c>.</returns>
        public Token TokenFromPlace(Place place)
        {
            Result res = lastResult;
            if (res == null || res.Tree == null)
                return null;

            foreach (var token in SablePP.Tools.Analysis.DepthFirstTreeWalker.GetTokens(res.Tree))
                if (RangeFromToken(token).Contains(place))
                    return token;
            return null;
        }

        private SquigglyStyle getSquigglyStyle(ErrorType errorType)
        {
            switch (errorType)
            {
                case ErrorType.Error: return errorStyle;
                case ErrorType.Warning: return warningStyle;
                case ErrorType.Message: return messageStyle;
                default: throw new ArgumentException("Unknown error type.");
            }
        }

        private void addError(CompilerError error)
        {
            Range range = new Range(this,
                error.Start.Character - 1, error.Start.Line - 1,
                error.End.Character, error.End.Line - 1);

            if (!(range.Start.iChar < 1 && range.Start.iLine < 1 && range.End.iChar < 1 && range.End.iLine < 1))
            {
                var style = getSquigglyStyle(error.ErrorType);
                if (range.GetIntersectionWith(this.Range).IsEmpty)
                    directDrawErrors.Add(range, style);
                else
                    range.SetStyle(style);
                tooltipMessages.Add(range, error.ErrorMessage);
            }

            if (ErrorAdded != null)
                ErrorAdded(this, new ErrorEventArgs(error));
        }
        private void clearErrors()
        {
            directDrawErrors.Clear();
            this.Range.ClearStyle(errorStyle, warningStyle, messageStyle);
            this.tooltipMessages.Clear();

            if (ErrorsCleared != null)
                ErrorsCleared(this, EventArgs.Empty);
        }

        /// <summary>
        /// Occurs when all the errors in the <see cref="CodeTextBox"/> are removed.
        /// </summary>
        public event EventHandler ErrorsCleared;
        /// <summary>
        /// Occurs when a new <see cref="CompilerError"/> is added to the <see cref="CodeTextBox"/>.
        /// </summary>
        public event EventHandler<ErrorEventArgs> ErrorAdded;

        private bool useSmartPar = true;
        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="CodeTextBox"/> should use smart parenthesis (inserting of '(' when text is selected will enclose the text with '(...)'.
        /// </summary>
        [DefaultValue(true)]
        public bool UseSmartParenthesis
        {
            get { return useSmartPar; }
            set { this.useSmartPar = value; }
        }

#pragma warning disable 1591
        protected sealed override void OnEnabledChanged(EventArgs e)
        {
            if (!this.Enabled)
                this.clearErrors();
            base.OnEnabledChanged(e);
        }

        public sealed override bool ProcessKey(char c, System.Windows.Forms.Keys modifiers)
        {
            if (useSmartPar)
            {
                char end = c == '(' ? ')' : c == '{' ? '}' : c == '[' ? ']' : c == '<' ? '>' : '\0';
                if (end != '\0')
                {
                    int s = this.SelectionStart;
                    int l = this.SelectionLength;
                    this.InsertText(c + this.Text.Substring(s, l) + end);
                    this.SelectionStart = s + 1;
                    this.SelectionLength = l;
                    return true;
                }
            }
            return base.ProcessKey(c, modifiers);
        }

        public sealed override void OnTextChangedDelayed(Range changedRange)
        {
            if (executer != null && this.Enabled)
                lock (lexerLock)
                {
                    StringReader reader = new StringReader(this.Text);
                    lexer = new ResetableLexer(executer.GetLexer(reader));

                    lexerError = false;
                    try { while (!(lexer.Next() is EOF)) { } }
                    catch (LexerException) { lexerError = true; }
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
                                this.setStyle(token, style);
                            }
                        }
                    }
                    lexer.Reset();
                    compileWorker.Start(executer, lexer);
                }

            base.OnTextChangedDelayed(changedRange);
        }

        protected sealed override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var r in directDrawErrors)
                r.Value.Draw(e.Graphics, PlaceToPoint(r.Key.Start), r.Key);
        }
#pragma warning restore

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
                    errorManager.Register(ex);
                    root = null;
                }
                catch (ParserException ex)
                {
                    errorManager.Register(ex);
                    root = null;
                }

                CompilationOptions compilationOptions = new CompilationOptions(parent.Text, errorManager, (highlight) =>
                    {
                        if (ReferenceEquals(highlight, null))
                            throw new ArgumentNullException("highlight");

                        if (parent != null)
                        {
                            HighlightWalker walker = new HighlightWalker(parent, highlight);
                            walker.Visit(root);
                        }
                    });

                if (root != null)
                {
                    parent.Range.ClearStyle(parent.moreStyles.ToArray());
                    parent.moreStyles.Clear();

                    compilationOptions.active = true;
                    executer.Validate(root, compilationOptions);
                    compilationOptions.active = false;
                }

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
                if (parent.CompilationCompleted != null)
                    parent.CompilationCompleted(parent, EventArgs.Empty);
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
                        parent.setStyle(token, s);
                    }
                }
            }
        }

        /// <summary>
        /// Represents a completed compilation attempt.
        /// </summary>
        public class Result
        {
            private DateTime time;
            private Node root;
            private CompilerError[] errors;

            internal Result(Node tree, IEnumerable<CompilerError> errors)
            {
                this.time = DateTime.Now;

                this.root = tree;
                this.errors = errors.ToArray();
            }

            /// <summary>
            /// Gets the <see cref="DateTime"/> the compilation was completed.
            /// </summary>
            public DateTime CompileTime
            {
                get { return time; }
            }
            /// <summary>
            /// Gets the root of the generated AST. If the lexer or parser failed this value is <c>null</c>.
            /// </summary>
            public Node Tree
            {
                get { return root; }
            }
            /// <summary>
            /// Gets the errors registered in validation of the code.
            /// </summary>
            public CompilerError[] Errors
            {
                get { return errors; }
            }
        }
    }
}
