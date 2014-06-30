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
        public void Push<N>(int state, N obj)
        {
            stack.Push(Tuple.Create(state, (object)obj));
        }
        public int State
        {
            get { return stack.Peek().Item1; }
        }

        #endregion

        public Parser()
        {
            this.stack = new Stack<Tuple<int, object>>();
        }
    }
}
