using System;
using System.Text;

namespace SablePP.Tools.Error
{
    /// <summary>
    /// The exception that is thrown when a <see cref="Lexing.ILexer"/> is unable to parse an input string.
    /// </summary>
    public class LexerException : ApplicationException
    {
        private int line;
        private int position;

        /// <summary>
        /// Initializes a new instance of the <see cref="LexerException"/> class.
        /// </summary>
        /// <param name="line">The line where the error occured.</param>
        /// <param name="position">The position, in the line, where the error occured.</param>
        /// <param name="message">A message that describes what the lexer has read and could not parse as a <see cref="Token"/>.</param>
        public LexerException(int line, int position, string message)
            : base(message)
        {
            this.line = line;
            this.position = position;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LexerException"/> class.
        /// </summary>
        /// <param name="line">The line where the error occured.</param>
        /// <param name="position">The position, in the line, where the error occured.</param>
        /// <param name="message">A message that describes what the lexer has read and could not parse as a <see cref="Token"/>.</param>
        public LexerException(int line, int position, StringBuilder message)
            : this(line, position, message.ToString())
        {
        }

        /// <summary>
        /// Gets the line where the error occured.
        /// </summary>
        public int Line
        {
            get { return line; }
        }
        /// <summary>
        /// Gets the position, in the line, where the error occured.
        /// </summary>
        public int Position
        {
            get { return position; }
        }
    }
}
