using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Sable.Compiler.analysis;
using Sable.Compiler.node;

namespace Sable.Compiler.Error
{
    /// <summary>
    /// Describes a compiler error and the position at which it has occured.
    /// </summary>
    public class CompilerError
    {
        private Position start, end;
        private string errorMessage;

        public CompilerError(int startLine, int startCharacter, int length, string errorMessage)
        {
            this.start = new Position(startLine, startCharacter);
            this.end = new Position(startLine, startCharacter + length - 1);
            this.errorMessage = endWithPeriod(errorMessage);
        }

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
        /// <param name="errorMessage">The error message.</param>
        /// <param name="args">The argument to use with <paramref name="errorMessage"/>.</param>
        public CompilerError(Node node, string errorMessage, params object[] args)
        {
            Token first;
            Token last;
            FirstLastVisitor.FindTokens(node, out first, out last);

            this.start = new Position(first.Line, first.Pos);
            this.end = new Position(last.Line, last.Pos + last.Text.Length - 1);
            if (args == null || args.Length == 0)
                this.errorMessage = errorMessage;
            else
                this.errorMessage = string.Format(errorMessage, translateArguments(args));
            this.errorMessage = endWithPeriod(this.errorMessage);
        }

        private static object[] translateArguments(object[] args)
        {
            for (int i = 0; i < args.Length; i++)
                if (args[i] is TIdentifier)
                    args[i] = quoteIdentifier((TIdentifier)args[i]);
            return args;
        }
        private static string quoteIdentifier(TIdentifier identifier)
        {
            return "\"" + identifier.Text + "\"";
        }

        #region Token Locater class

        private class FirstLastVisitor : DepthFirstAdapter
        {
            private Token first;
            private Token last;

            private FirstLastVisitor()
            {
                this.first = null;
                this.last = null;
            }

            public static void FindTokens(Node node, out Token first, out Token last)
            {
                if (node is Token)
                {
                    first = last = node as Token;
                    return;
                }

                FirstLastVisitor visitor = new FirstLastVisitor();
                node.Apply(visitor);
                first = visitor.first;
                last = visitor.last;
            }

            public override void DefaultCase(Node node)
            {
                if (node is Token)
                {
                    if (this.first == null)
                        this.first = node as Token;
                    this.last = node as Token;
                }

                base.DefaultCase(node);
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
