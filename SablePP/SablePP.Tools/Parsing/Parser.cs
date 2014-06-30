using SablePP.Tools.Lexing;
using SablePP.Tools.Nodes;
using System;
using System.Collections.Generic;

namespace SablePP.Tools.Parsing
{
    public abstract class Parser<TRoot> : IParser where TRoot : Production
    {
        private const int SHIFT = 0;
        private const int REDUCE = 1;
        private const int ACCEPT = 2;
        private const int ERROR = 3;

        #region Stack

        private Stack<Tuple<int, object>> stack;

        public N Pop<N>() where N : class
        {
            var obj = stack.Pop();
            return obj.Item2 as N;
        }
        public void Push<N>(int index, N obj)
        {
            int state = State;
            int low = 1;
            int high = gotoTable[index].Length - 1;
            int value = gotoTable[index][0][1];

            while (low <= high)
            {
                int middle = (low + high) / 2;

                if (state < gotoTable[index][middle][0])
                {
                    high = middle - 1;
                }
                else if (state > gotoTable[index][middle][0])
                {
                    low = middle + 1;
                }
                else
                {
                    value = gotoTable[index][middle][1];
                    break;
                }
            }

            PushNoGoto(value, obj);
        }
        private void PushNoGoto<N>(int state, N obj)
        {
            stack.Push(Tuple.Create(state, (object)obj));
        }
        public int State
        {
            get { return stack.Peek().Item1; }
        }

        #endregion

        private Dictionary<Token, Token[]> ignoredTokens;
        public Dictionary<Token, Token[]> IgnoredTokens
        {
            get { return ignoredTokens; }
        }
        private ILexer lexer;

        private int last_shift;
        private int last_pos;
        private int last_line;
        private Token last_token;

        private int[] action = new int[2];
        private int[][][] actionTable;
        private int[][][] gotoTable;
        private string[] errorMessages;
        private int[] errors;

        public Parser(ILexer lexer, int[][][] actionTable, int[][][] gotoTable, string[] errorMessages, int[] errors)
        {
            this.stack = new Stack<Tuple<int, object>>();
            this.ignoredTokens = new Dictionary<Token, Token[]>();
            this.lexer = lexer;

            this.actionTable = actionTable;
            this.gotoTable = gotoTable;
            this.errorMessages = errorMessages;
            this.errors = errors;
        }

        /// <summary>
        /// When overridden in a derived class; gets the index of a <see cref="Token" />.
        /// </summary>
        /// <param name="token">The <see cref="Token" /> of which to retrieve the index..</param>
        /// <returns>
        /// The index of <paramref name="token" />; or <c>-1</c> if <paramref name="token"/> has no index.
        /// </returns>
        protected abstract int getTokenIndex(Token token);
    }
}
