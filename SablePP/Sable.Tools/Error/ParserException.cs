using Sable.Tools.Nodes;
using System;

namespace Sable.Tools.Error
{
   public class ParserException : ApplicationException
    {
       private Token last_token;

        private int last_line;
        private int last_position;

        public ParserException(Token last_token, int last_line, int last_position, string message)
            : base(message)
        {
            this.last_token = last_token;
            this.last_line = last_line;
            this.last_position = last_position;
        }

        public Token LastToken
        {
            get { return last_token; }
        }

        public int LastLine
        {
            get { return last_line; }
        }
        public int LastPosition
        {
            get { return last_position; }
        }
    }
}
