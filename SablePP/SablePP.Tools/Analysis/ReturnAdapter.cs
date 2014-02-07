using System;
using SablePP.Tools.Nodes;

namespace SablePP.Tools.Analysis
{
    public abstract class ReturnAdapter<T, TRoot> where TRoot : Production
    {
        public ReturnAdapter()
        {
        }

        public virtual T Visit(Node node, T arg)
        {
            return arg;
        }
        public virtual T DefaultCase(Node node, T arg)
        {
            return arg;
        }

        public T Visit(Start<TRoot> node, T arg)
        {
            return CaseStart(node, arg);
        }
        public T Visit(EOF node, T arg)
        {
            return CaseEOF(node, arg);
        }
        public virtual T CaseStart(Start<TRoot> node, T arg)
        {
            return DefaultCase(node, arg);
        }
        public virtual T CaseEOF(EOF node, T arg)
        {
            return DefaultCase(node, arg);
        }
    }
}
