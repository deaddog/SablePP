using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Lexing
{
    public abstract class Lexer : ILexer
    {
        private class PushbackReader
        {
            private TextReader reader;
            private Stack<int> stack;

            public PushbackReader(TextReader reader)
            {
                this.reader = reader;
                this.stack = new Stack<int>();
            }

            public int Peek()
            {
                if (stack.Count > 0)
                    return stack.Peek();
                return reader.Peek();
            }

            public int Read()
            {
                if (stack.Count > 0)
                    return stack.Pop();
                return reader.Read();
            }

            public void Unread(int v)
            {
                stack.Push(v);
            }
        }
    }
}
