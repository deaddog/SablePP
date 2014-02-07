﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using SablePP.Tools.Nodes;

namespace SablePP.Tools.Error
{
    /// <summary>
    /// Describes a compiler error and the position at which it has occured.
    /// </summary>
    public class CompilerError
    {
        private Position start, end;
        private string errorMessage;

        private static string endWithPeriod(string input)
        {
            Match m = Regex.Match(input, @"[\.\!\?]$");
            if (!m.Success)
                return input + ".";
            else
                return input;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilerError"/> class.
        /// </summary>
        /// <param name="node">The node that should be marked as cause of the error. The full node will be marked.</param>
        /// <param name="errorMessage">The error message associated with the <see cref="CompilerError"/>.</param>
        public CompilerError(Node node, string errorMessage)
        {
            Token first;
            Token last;
            FirstLastVisitor.FindTokens(node, out first, out last);

            this.start = new Position(first.Line, first.Position);
            this.end = new Position(last.Line, last.Position + last.Text.Length - 1);

            this.errorMessage = endWithPeriod(errorMessage);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilerError"/> class that has no known location.
        /// </summary>
        /// <param name="errorMessage">The error message associated with the <see cref="CompilerError"/>.</param>
        public CompilerError(string errorMessage)
        {
            this.start = new Position(0, 0);
            this.end = new Position(0, 0);
            this.errorMessage = errorMessage;
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
        /// Gets the start <see cref="Position"/> of the error.
        /// </summary>
        /// <value>
        /// The start <see cref="Position"/> of the error.
        /// </value>
        public Position Start
        {
            get { return start; }
        }
        /// <summary>
        /// Gets the end <see cref="Position"/> of the error.
        /// </summary>
        /// <value>
        /// The end <see cref="Position"/> of the error.
        /// </value>
        public Position End
        {
            get { return end; }
        }

        /// <summary>
        /// Gets the error message associated with the error.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage
        {
            get { return errorMessage; }
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}] {2}", start.LineNumber, start.LinePosition, errorMessage);
        }
    }
}
