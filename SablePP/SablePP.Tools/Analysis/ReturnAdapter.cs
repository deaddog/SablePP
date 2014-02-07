using System;
using System.Threading;
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

        /// <summary>
        /// Visits a node (and possibly substructure) using multiple instances of <see cref="Adapter{TValue,TRoot}"/> in parallel.
        /// The method returns when all adapters have completed execution.
        /// </summary>
        /// <param name="node">The node to visit.</param>
        /// <param name="arg">The <typeparamref name="T"/> argument that is passed to all adapters.</param>
        /// <param name="adapters">The collection of <see cref="ReturnAdapter{T,TRoot}"/> on which the Visit method should be invoked.</param>
        /// <returns>An array consisting of the results of all the adapters. The results are ordered in the same order as <paramref name="adapters"/>.</returns>
        public static T[] VisitInParallel(Node node, T arg, params ReturnAdapter<T, TRoot>[] adapters)
        {
            Thread[] threads = new Thread[adapters.Length];
            T[] results = new T[adapters.Length];
            for (int i = 0; i < adapters.Length; i++)
            {
                ReturnAdapter<T, TRoot> adapter = adapters[i];
                int index = i;
                threads[index] = new Thread(() => results[index] = adapter.Visit(node, arg));
                threads[index].Start();
            }
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();

            return results;
        }
    }
}
