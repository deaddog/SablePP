using SablePP.Tools.Nodes;
using System;
using System.Collections.Generic;

namespace SablePP.Tools.Parsing
{
    public abstract class Parser<TRoot> : IParser where TRoot : Production
    {
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
