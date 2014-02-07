using System;
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
        /// <param name="start">The start <see cref="Position"/> of the error.</param>
        /// <param name="end">The end <see cref="Position"/> of the error.</param>
        /// <param name="errorMessage">The error message associated with the <see cref="CompilerError"/>.</param>
        public CompilerError(Position start, Position end, string errorMessage)
        {
            this.start = start;
            this.end = end;
            this.errorMessage = endWithPeriod(errorMessage);
        }

        /// <summary>
        /// Translates a <see cref="LexerException"/> into a <see cref="CompilerError"/>.
        /// </summary>
        /// <param name="exception">The <see cref="LexerException"/> that should be translated.</param>
        /// <returns>A <see cref="CompilerError"/> that represents <paramref name="exception"/>.</returns>
        public static CompilerError ParseException(LexerException exception)
        {
            return new CompilerError(endWithPeriod(exception.Message))
                {
                    start = new Position(exception.Line, exception.Position),
                    end = new Position(exception.Line, exception.Position)
                };
        }
        /// <summary>
        /// Translates a <see cref="ParserException"/> into a <see cref="CompilerError"/>.
        /// </summary>
        /// <param name="exception">The <see cref="ParserException"/> that should be translated.</param>
        /// <returns>A <see cref="CompilerError"/> that represents <paramref name="exception"/>.</returns>
        public static CompilerError ParseException(ParserException exception)
        {
            return new CompilerError(endWithPeriod(exception.Message))
            {
                start = new Position(exception.LastLine, exception.LastPosition),
                end = new Position(exception.LastLine, exception.LastPosition)
            };
        }

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
