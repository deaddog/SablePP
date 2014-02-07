using System;
using System.Collections.Generic;
using System.Threading;

using SablePP.Tools.Nodes;

namespace SablePP.Tools.Analysis
{
    public abstract class Adapter<TValue, TRoot> where TRoot : Production
    {
        public class Table
        {
            private Dictionary<Node, TValue> dict;

            public Table()
            {
                dict = new Dictionary<Node, TValue>();
            }

            public TValue this[Node key]
            {
                get
                {
                    if (key == null || !dict.ContainsKey(key))
                        return default(TValue);
                    else
                        return dict[key];
                }
                set
                {
                    if (value == null)
                        dict.Remove(key);
                    else
                        dict[key] = value;
                }
            }
        }

        private Table input;
        private Table output;

        public Adapter()
        {
            this.input = new Table();
            this.output = new Table();
        }

        public Table Input
        {
            get { return input; }
        }
        public Table Output
        {
            get { return output; }
        }

        public virtual void Visit(Node node)
        {
        }
        public virtual void DefaultCase(Node node)
        {
        }

        public void Visit(Start<TRoot> node)
        {
            CaseStart(node);
        }
        public void Visit(EOF node)
        {
            CaseEOF(node);
        }
        public virtual void CaseStart(Start<TRoot> node)
        {
            DefaultCase(node);
        }
        public virtual void CaseEOF(EOF node)
        {
            DefaultCase(node);
        }

        public static void VisitInParallel(Node node, params Adapter<TValue, TRoot>[] adapters)
        {
            Thread[] threads = new Thread[adapters.Length];
            for (int i = 0; i < adapters.Length; i++)
            {
                Adapter<TValue, TRoot> walker = adapters[i];
                threads[i] = new Thread(() => walker.Visit(node));
                threads[i].Start();
            }
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();
        }
    }
}
