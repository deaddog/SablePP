using SablePP.Tools.Nodes;
using System;

namespace SablePP.Tools.Error
{
    /// <summary>
    /// The exception that is thrown when a <see cref="Parsing.IParser"/> is unable to generate an AST given a stream of tokens.
    /// </summary>
   public class ParserException : ApplicationException
    {
       private Token last_token;

        private int last_line;
        private int last_position;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserException"/> class.
        /// </summary>
        /// <param name="last_token">The last <see cref="Token"/> visited by the parser before the error occured.</param>
        /// <param name="last_line">The line where the error occured.</param>
        /// <param name="last_position">The position, in the line, where the error occured.</param>
        /// <param name="message">A message that describes which token the parser expected.</param>
        public ParserException(Token last_token, int last_line, int last_position, string message)
            : base(message)
        {
            this.last_token = last_token;
            this.last_line = last_line;
            this.last_position = last_position;
        }

        /// <summary>
        /// Gets the last <see cref="Token"/> visited by the parser before the error occured.
        /// </summary>
        public Token LastToken
        {
            get { return last_token; }
        }

        /// <summary>
        /// Gets the line where the error occured.
        /// </summary>
        public int LastLine
        {
            get { return last_line; }
        }
        /// <summary>
        /// Gets the position, in the line, where the error occured.
        /// </summary>
        public int LastPosition
        {
            get { return last_position; }
        }
    }
}
