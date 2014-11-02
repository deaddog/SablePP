using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SablePP.Tools.Nodes;

namespace SablePP.Tools.Error
{
    /// <summary>
    /// Manages semantic errors throughout semantic checks of an AST.
    /// </summary>
    public class ErrorManager : IEnumerable<CompilerError>
    {
        private ErrorComparison comparer;
        private List<CompilerError> errorList;

        private ErrorCollection errors, warnings, messages;

        /// <summary>
        /// Gets the number of registered errors (all types).
        /// </summary>
        public int Count
        {
            get { return errorList.Count; }
        }

        /// <summary>
        /// Gets a collection of the <see cref="CompilerError"/>s with error type <see cref="ErrorType.Error"/>.
        /// </summary>
        public ErrorCollection Errors
        {
            get { return errors; }
        }
        /// <summary>
        /// Gets a collection of the <see cref="CompilerError"/>s with error type <see cref="ErrorType.Warning"/>.
        /// </summary>
        public ErrorCollection Warnings
        {
            get { return warnings; }
        }
        /// <summary>
        /// Gets a collection of the <see cref="CompilerError"/>s with error type <see cref="ErrorType.Message"/>.
        /// </summary>
        public ErrorCollection Messages
        {
            get { return messages; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorManager"/> class.
        /// </summary>
        public ErrorManager()
        {
            this.comparer = new ErrorComparison();
            this.errorList = new List<CompilerError>();

            this.errors = new ErrorCollection(this, e => e.ErrorType == ErrorType.Error);
            this.warnings = new ErrorCollection(this, e => e.ErrorType == ErrorType.Warning);
            this.messages = new ErrorCollection(this, e => e.ErrorType == ErrorType.Message);
        }

        /// <summary>
        /// Registers the specified error.
        /// </summary>
        /// <param name="error">The error that should be added to the <see cref="ErrorManager"/>.</param>
        public void Register(CompilerError error)
        {
            int pos = errorList.BinarySearch(error, comparer);
            if (pos < 0)
                pos = ~pos;
            else
            {
                do { pos++; }
                while (pos < errorList.Count && comparer.Compare(errorList[pos], error) == 0);
            }
            errorList.Insert(pos, error);
        }

        /// <summary>
        /// Registers an error at the location of a specified <see cref="Node"/>.
        /// </summary>
        /// <param name="node">The node that should be marked as cause of the error. The full node will be marked.</param>
        /// <param name="errorMessage">The error message associated with the <see cref="CompilerError"/>.</param>
        /// <param name="args">Arguments for the error message.</param>
        public void Register(Node node, string errorMessage, params object[] args)
        {
            Register(node, ErrorType.Error, errorMessage, args);
        }
        /// <summary>
        /// Registers an error at the location of a specified <see cref="Node"/>, specifying the <see cref="ErrorType"/>.
        /// </summary>
        /// <param name="node">The node that should be marked as cause of the error. The full node will be marked.</param>
        /// <param name="errorType">Type of the error.</param>
        /// <param name="errorMessage">The error message associated with the <see cref="CompilerError"/>.</param>
        /// <param name="args">Arguments for the error message.</param>
        public void Register(Node node, ErrorType errorType, string errorMessage, params object[] args)
        {
            Token first;
            Token last;
            FirstLastVisitor.FindTokens(node, out first, out last);

            if (first == null || last == null)
            {
                Register(errorType, errorMessage, args);
                return;
            }

            if (args != null && args.Length > 0)
                errorMessage = string.Format(errorMessage, translateArguments(args));

            Register(new CompilerError(
                errorType,
                new Position(first.Line, first.Position),
                new Position(last.Line, last.Position + last.Text.Length - 1),
                errorMessage));
        }

        /// <summary>
        /// Registers an error with an unknown location.
        /// </summary>
        /// <param name="errorMessage">The error message associated with the <see cref="CompilerError"/>.</param>
        /// <param name="args">Arguments for the error message.</param>
        public void Register(string errorMessage, params object[] args)
        {
            Register(ErrorType.Error, errorMessage, args);
        }
        /// <summary>
        /// Registers an error with an unknown location, specifying the <see cref="ErrorType"/>.
        /// </summary>
        /// <param name="errorType">Type of the error.</param>
        /// <param name="errorMessage">The error message associated with the <see cref="CompilerError"/>.</param>
        /// <param name="args">Arguments for the error message.</param>
        public void Register(ErrorType errorType, string errorMessage, params object[] args)
        {
            if (args != null && args.Length > 0)
                errorMessage = string.Format(errorMessage, translateArguments(args));

            Register(new CompilerError(errorType, new Position(0, 0), new Position(0, 0), errorMessage));
        }

        /// <summary>
        /// Translates a <see cref="LexerException"/> into a <see cref="CompilerError"/> and registers that error.
        /// </summary>
        /// <param name="exception">The <see cref="LexerException"/> that should be translated.</param>
        public void Register(LexerException exception)
        {
            Register(new CompilerError(
                ErrorType.Error,
                new Position(exception.Line, exception.Position),
                new Position(exception.Line, exception.Position),
                exception.Message));
        }
        /// <summary>
        /// Translates a <see cref="ParserException"/> into a <see cref="CompilerError"/> and registers that error.
        /// </summary>
        /// <param name="exception">The <see cref="ParserException"/> that should be translated.</param>
        /// <returns>A <see cref="CompilerError"/> that represents <paramref name="exception"/>.</returns>
        public void Register(ParserException exception)
        {
            Register(new CompilerError(
                ErrorType.Error,
                new Position(exception.LastLine, exception.LastPosition),
                new Position(exception.LastLine, exception.LastPosition),
                exception.Message));
        }

        private object[] translateArguments(object[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                ErrorArgumentEventArgs ea = new ErrorArgumentEventArgs(args[i]);
                if (TranslateArgument != null)
                    TranslateArgument(this, ea);
                args[i] = ea.Text;
            }

            return args;
        }

        /// <summary>
        /// Occurs when an argument is passed to either of the error registration methods.
        /// Allows for translation of each argument into a more appropriate string.
        /// </summary>
        public event ErrorArgumentEventHandler TranslateArgument;

        IEnumerator<CompilerError> IEnumerable<CompilerError>.GetEnumerator()
        {
            foreach (var err in errorList)
                yield return err;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (var err in errorList)
                yield return err;
        }

        private class ErrorComparison : IComparer<CompilerError>
        {
            public int Compare(CompilerError x, CompilerError y)
            {
                return x.Start.CompareTo(y.Start);
            }
        }

        #region Token Locater class

        private class FirstLastVisitor
        {
            public static void FindTokens(Node node, out Token first, out Token last)
            {
                if (node is Token)
                    first = last = node as Token;
                else
                {
                    FirstFinder f = new FirstFinder();
                    f.Visit(node);
                    first = f.Token;

                    LastFinder l = new LastFinder();
                    l.Visit(node);
                    last = l.Token;
                }
            }

            private class FirstFinder : SablePP.Tools.Analysis.DepthFirstTreeWalker
            {
                private Token token = null;
                public Token Token
                {
                    get { return token; }
                }

                public override void Visit(Production production)
                {
                    if (this.token == null)
                        base.Visit(production);
                }
                public override void Visit(Token token)
                {
                    if (this.token == null)
                        this.token = token;
                }
            }
            private class LastFinder : SablePP.Tools.Analysis.DepthFirstReversedTreeWalker
            {
                private Token token = null;
                public Token Token
                {
                    get { return token; }
                }

                public override void Visit(Production production)
                {
                    if (this.token == null)
                        base.Visit(production);
                }
                public override void Visit(Token token)
                {
                    if (this.token == null)
                        this.token = token;
                }
            }
        }

        #endregion

        /// <summary>
        /// Exposes a filtered collection of <see cref="CompilerError"/>s contained by an <see cref="ErrorManager"/>.
        /// </summary>
        public class ErrorCollection : IEnumerable<CompilerError>
        {
            private ErrorManager errorManager;
            private Predicate<CompilerError> predicate;

            /// <summary>
            /// Gets the number of <see cref="CompilerError"/>s in this <see cref="ErrorCollection"/>.
            /// </summary>
            public int Count
            {
                get { return this.Count(); }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ErrorCollection"/> class.
            /// </summary>
            /// <param name="errorManager">The error manager from which errors should be extracted.</param>
            /// <param name="predicate">The predicate that errors must meet to be part of this <see cref="ErrorCollection"/>.</param>
            public ErrorCollection(ErrorManager errorManager, Predicate<CompilerError> predicate)
            {
                this.errorManager = errorManager;
                this.predicate = predicate;
            }

            IEnumerator<CompilerError> IEnumerable<CompilerError>.GetEnumerator()
            {
                foreach (var e in errorManager)
                    if (predicate(e))
                        yield return e;
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return (this as IEnumerable<CompilerError>).GetEnumerator();
            }
        }

    }
}
