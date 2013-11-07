using System;
using System.Text;

namespace Sable.Tools.Error
{
    public class LexerException : ApplicationException
    {
        private int line;
        private int position;

        public LexerException(int line, int position, string message)
            : base(message)
        {
            this.line = line;
            this.position = position;
        }

        public LexerException(int line, int position, StringBuilder message)
            : this(line, position, message.ToString())
        {
        }

        public int Line
        {
            get { return line; }
        }
        public int Position
        {
            get { return position; }
        }
    }
}
