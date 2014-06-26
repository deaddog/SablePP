using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SablePP.Tools.Nodes;

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

        protected Token token;
        protected int currentState;

        private PushbackReader input;
        private int line;
        private int pos;
        private bool cr;
        private bool eof;
        private StringBuilder text;

        private int[][][][] gotoTable;
        private int[][] acceptTable;

        public Lexer(TextReader input, int initialState, int[][][][] gotoTable, int[][] acceptTable)
        {
            this.text = new StringBuilder();
            this.input = new PushbackReader(input);

            this.currentState = initialState;
            this.gotoTable = gotoTable;
            this.acceptTable = acceptTable;
        }
    }
}
