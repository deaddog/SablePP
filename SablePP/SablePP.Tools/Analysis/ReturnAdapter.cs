using System;
using System.Threading;
using SablePP.Tools.Nodes;

namespace SablePP.Tools.Analysis
{
    /// <summary>
    /// Defines a base implementation of the visitor pattern in which each Visit method returns a value and takes an argument.
    /// </summary>
    /// <typeparam name="T">The type of the values that are returned by the <see cref="ReturnAdapter{T,TRoot}"/>.</typeparam>
    /// <typeparam name="TRoot">The type of the root production in the AST.</typeparam>
    public abstract class ReturnAdapter<T, TRoot> where TRoot : Production
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnAdapter{T, TRoot}"/> class.
        /// </summary>
        public ReturnAdapter()
        {
        }

        /// <summary>
        /// Visits the specified <see cref="Node"/>.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be visited.</param>
        /// <param name="arg">The argument passed to the visit handler.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public virtual T Visit(Node node, T arg)
        {
            return arg;
        }
        /// <summary>
        /// When overridden in a derived class, specifies default handler for visiting nodes.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be visited.</param>
        /// <param name="arg">The argument that is passed to this visit handler.</param>
        /// <returns>A value determined by this visit handler.</returns>
        public virtual T DefaultCase(Node node, T arg)
        {
            return arg;
        }

        /// <summary>
        /// Visits the specified <see cref="Start{TRoot}"/> production by calling the <see cref="CaseStart"/> method.
        /// </summary>
        /// <param name="node">The <see cref="Start{TRoot}"/> production that should be visited.</param>
        /// <param name="arg">The argument passed to the visit handler.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public T Visit(Start<TRoot> node, T arg)
        {
            return CaseStart(node, arg);
        }
        /// <summary>
        /// Visits the specified <see cref="EOF"/> token by calling the <see cref="CaseEOF"/> method.
        /// </summary>
        /// <param name="node">The <see cref="EOF"/> token that should be visited.</param>
        /// <param name="arg">The argument passed to the visit handler.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public T Visit(EOF node, T arg)
        {
            return CaseEOF(node, arg);
        }

        /// <summary>
        /// When overridden in a derived class, specifies a handler for visiting <see cref="Start{TRoot}"/> production nodes.
        /// </summary>
        /// <param name="node">The <see cref="Start{TRoot}"/> node to handle.</param>
        /// <param name="arg">The argument that is passed to this visit handler.</param>
        /// <returns>A value determined by this visit handler.</returns>
        public virtual T CaseStart(Start<TRoot> node, T arg)
        {
            return DefaultCase(node, arg);
        }
        /// <summary>
        /// When overridden in a derived class, specifies a handler for visiting <see cref="EOF"/> token nodes.
        /// </summary>
        /// <param name="node">The <see cref="EOF"/> node to handle.</param>
        /// <param name="arg">The argument that is passed to this visit handler.</param>
        /// <returns>A value determined by this visit handler.</returns>
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
