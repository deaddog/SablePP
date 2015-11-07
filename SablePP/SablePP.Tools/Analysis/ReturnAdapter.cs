using System;
using System.Threading;
using SablePP.Tools.Nodes;

namespace SablePP.Tools.Analysis
{
    /// <summary>
    /// Provides static methods for starting multiple visitors in parallel.
    /// </summary>
    public static class ReturnAdapter
    {
        /// <summary>
        /// Visits a node (and possibly substructure) using multiple return adapters in parallel.
        /// The method returns when all adapters have completed execution.
        /// </summary>
        /// <param name="node">The node to visit.</param>
        /// <param name="adapters">The collection of <see cref="ReturnAdapter{TResult,TRoot}"/> on which the Visit method should be invoked.</param>
        /// <returns>An array consisting of the results of all the adapters. The results are ordered in the same order as <paramref name="adapters"/>.</returns>
        public static TResult[] VisitInParallel<TResult, TRoot>(Node node, params ReturnAdapter<TResult, TRoot>[] adapters)
            where TRoot : Production
        {
            Thread[] threads = new Thread[adapters.Length];
            TResult[] results = new TResult[adapters.Length];
            for (int i = 0; i < adapters.Length; i++)
            {
                ReturnAdapter<TResult, TRoot> adapter = adapters[i];
                int index = i;
                threads[index] = new Thread(() => results[index] = adapter.Visit(node));
                threads[index].Start();
            }
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();

            return results;
        }

        /// <summary>
        /// Visits a node (and possibly substructure) using multiple adapters in parallel.
        /// The method returns when all adapters have completed execution.
        /// </summary>
        /// <param name="node">The node to visit.</param>
        /// <param name="arg1">The <typeparamref name="T1"/> argument that is passed to all adapters.</param>
        /// <param name="adapters">The collection of <see cref="ReturnAdapter{T1,TResult,TRoot}"/> on which the Visit method should be invoked.</param>
        /// <returns>An array consisting of the results of all the adapters. The results are ordered in the same order as <paramref name="adapters"/>.</returns>
        public static TResult[] VisitInParallel<T1, TResult, TRoot>(Node node, T1 arg1, params ReturnAdapter<T1, TResult, TRoot>[] adapters)
            where TRoot : Production
        {
            Thread[] threads = new Thread[adapters.Length];
            TResult[] results = new TResult[adapters.Length];
            for (int i = 0; i < adapters.Length; i++)
            {
                ReturnAdapter<T1, TResult, TRoot> adapter = adapters[i];
                int index = i;
                threads[index] = new Thread(() => results[index] = adapter.Visit(node, arg1));
                threads[index].Start();
            }
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();

            return results;
        }

        /// <summary>
        /// Visits a node (and possibly substructure) using multiple adapters in parallel.
        /// The method returns when all adapters have completed execution.
        /// </summary>
        /// <param name="node">The node to visit.</param>
        /// <param name="arg1">The <typeparamref name="T1"/> argument that is passed to all adapters.</param>
        /// <param name="arg2">The <typeparamref name="T2"/> argument that is passed to all adapters.</param>
        /// <param name="adapters">The collection of <see cref="ReturnAdapter{T1,T2,TResult,TRoot}"/> on which the Visit method should be invoked.</param>
        /// <returns>An array consisting of the results of all the adapters. The results are ordered in the same order as <paramref name="adapters"/>.</returns>
        public static TResult[] VisitInParallel<T1, T2, TResult, TRoot>(Node node, T1 arg1, T2 arg2, params ReturnAdapter<T1, T2, TResult, TRoot>[] adapters)
            where TRoot : Production
        {
            Thread[] threads = new Thread[adapters.Length];
            TResult[] results = new TResult[adapters.Length];
            for (int i = 0; i < adapters.Length; i++)
            {
                ReturnAdapter<T1, T2, TResult, TRoot> adapter = adapters[i];
                int index = i;
                threads[index] = new Thread(() => results[index] = adapter.Visit(node, arg1, arg2));
                threads[index].Start();
            }
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();

            return results;
        }

        /// <summary>
        /// Visits a node (and possibly substructure) using multiple adapters in parallel.
        /// The method returns when all adapters have completed execution.
        /// </summary>
        /// <param name="node">The node to visit.</param>
        /// <param name="arg1">The <typeparamref name="T1"/> argument that is passed to all adapters.</param>
        /// <param name="arg2">The <typeparamref name="T2"/> argument that is passed to all adapters.</param>
        /// <param name="arg3">The <typeparamref name="T3"/> argument that is passed to all adapters.</param>
        /// <param name="adapters">The collection of <see cref="ReturnAdapter{T1,T2,TResult,TRoot}"/> on which the Visit method should be invoked.</param>
        /// <returns>An array consisting of the results of all the adapters. The results are ordered in the same order as <paramref name="adapters"/>.</returns>
        public static TResult[] VisitInParallel<T1, T2, T3, TResult, TRoot>(Node node, T1 arg1, T2 arg2, T3 arg3, params ReturnAdapter<T1, T2, T3, TResult, TRoot>[] adapters)
            where TRoot : Production
        {
            Thread[] threads = new Thread[adapters.Length];
            TResult[] results = new TResult[adapters.Length];
            for (int i = 0; i < adapters.Length; i++)
            {
                ReturnAdapter<T1, T2, T3, TResult, TRoot> adapter = adapters[i];
                int index = i;
                threads[index] = new Thread(() => results[index] = adapter.Visit(node, arg1, arg2, arg3));
                threads[index].Start();
            }
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();

            return results;
        }
    }

    /// <summary>
    /// Defines a base implementation of the visitor pattern in which each Visit method returns a value.
    /// </summary>
    /// <typeparam name="TResult">The type of the values that are returned by the <see cref="ReturnAdapter{TResult,TRoot}"/>.</typeparam>
    /// <typeparam name="TRoot">The type of the root production in the AST.</typeparam>
    public abstract class ReturnAdapter<TResult, TRoot> where TRoot : Production
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnAdapter{TResult, TRoot}"/> class.
        /// </summary>
        public ReturnAdapter()
        {
        }

        /// <summary>
        /// Visits the specified <see cref="Node"/>.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be visited.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public virtual TResult Visit(Node node)
        {
            return default(TResult);
        }
        /// <summary>
        /// When overridden in a derived class, specifies default handler for visiting nodes.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be visited.</param>
        /// <returns>A value determined by this visit handler.</returns>
        protected virtual TResult HandleDefault(Node node)
        {
            return default(TResult);
        }

        /// <summary>
        /// Visits the specified <see cref="Start{TRoot}"/> production by calling the <see cref="HandleStart"/> method.
        /// </summary>
        /// <param name="node">The <see cref="Start{TRoot}"/> production that should be visited.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public TResult Visit(Start<TRoot> node)
        {
            return HandleStart(node);
        }
        /// <summary>
        /// Visits the specified <see cref="EOF"/> token by calling the <see cref="HandleEOF"/> method.
        /// </summary>
        /// <param name="node">The <see cref="EOF"/> token that should be visited.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public TResult Visit(EOF node)
        {
            return HandleEOF(node);
        }

        /// <summary>
        /// When overridden in a derived class, specifies a handler for visiting <see cref="Start{TRoot}"/> production nodes.
        /// </summary>
        /// <param name="node">The <see cref="Start{TRoot}"/> node to handle.</param>
        /// <returns>A value determined by this visit handler.</returns>
        protected virtual TResult HandleStart(Start<TRoot> node)
        {
            return HandleDefault(node);
        }
        /// <summary>
        /// When overridden in a derived class, specifies a handler for visiting <see cref="EOF"/> token nodes.
        /// </summary>
        /// <param name="node">The <see cref="EOF"/> node to handle.</param>
        /// <returns>A value determined by this visit handler.</returns>
        protected virtual TResult HandleEOF(EOF node)
        {
            return HandleDefault(node);
        }
    }

    /// <summary>
    /// Defines a base implementation of the visitor pattern in which each Visit method returns a value and takes an argument.
    /// </summary>
    /// <typeparam name="T1">The type of the argument for the Visit methods.</typeparam>
    /// <typeparam name="TResult">The type of the values that are returned by the <see cref="ReturnAdapter{T1,TResult,TRoot}"/></typeparam>
    /// <typeparam name="TRoot">The type of the root production in the AST.</typeparam>
    public abstract class ReturnAdapter<T1, TResult, TRoot> where TRoot : Production
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnAdapter{T1, TResult, TRoot}"/> class.
        /// </summary>
        public ReturnAdapter()
        {
        }

        /// <summary>
        /// Visits the specified <see cref="Node"/>.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be visited.</param>
        /// <param name="arg1">The argument passed to the visit handler.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public virtual TResult Visit(Node node, T1 arg1)
        {
            return default(TResult);
        }
        /// <summary>
        /// When overridden in a derived class, specifies default handler for visiting nodes.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be visited.</param>
        /// <param name="arg1">The argument that is passed to this visit handler.</param>
        /// <returns>A value determined by this visit handler.</returns>
        protected virtual TResult HandleDefault(Node node, T1 arg1)
        {
            return default(TResult);
        }

        /// <summary>
        /// Visits the specified <see cref="Start{TRoot}"/> production by calling the <see cref="HandleStart"/> method.
        /// </summary>
        /// <param name="node">The <see cref="Start{TRoot}"/> production that should be visited.</param>
        /// <param name="arg1">The argument passed to the visit handler.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public TResult Visit(Start<TRoot> node, T1 arg1)
        {
            return HandleStart(node, arg1);
        }
        /// <summary>
        /// Visits the specified <see cref="EOF"/> token by calling the <see cref="HandleEOF"/> method.
        /// </summary>
        /// <param name="node">The <see cref="EOF"/> token that should be visited.</param>
        /// <param name="arg1">The argument passed to the visit handler.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public TResult Visit(EOF node, T1 arg1)
        {
            return HandleEOF(node, arg1);
        }

        /// <summary>
        /// When overridden in a derived class, specifies a handler for visiting <see cref="Start{TRoot}"/> production nodes.
        /// </summary>
        /// <param name="node">The <see cref="Start{TRoot}"/> node to handle.</param>
        /// <param name="arg1">The argument that is passed to this visit handler.</param>
        /// <returns>A value determined by this visit handler.</returns>
        protected virtual TResult HandleStart(Start<TRoot> node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        /// <summary>
        /// When overridden in a derived class, specifies a handler for visiting <see cref="EOF"/> token nodes.
        /// </summary>
        /// <param name="node">The <see cref="EOF"/> node to handle.</param>
        /// <param name="arg1">The argument that is passed to this visit handler.</param>
        /// <returns>A value determined by this visit handler.</returns>
        protected virtual TResult HandleEOF(EOF node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
    }

    /// <summary>
    /// Defines a base implementation of the visitor pattern in which each Visit method returns a value and takes two arguments.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument for the Visit methods.</typeparam>
    /// <typeparam name="T2">The type of the second argument for the Visit methods.</typeparam>
    /// <typeparam name="TResult">The type of the values that are returned by the <see cref="ReturnAdapter{T1,T2,TResult,TRoot}"/></typeparam>
    /// <typeparam name="TRoot">The type of the root production in the AST.</typeparam>
    public abstract class ReturnAdapter<T1, T2, TResult, TRoot> where TRoot : Production
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnAdapter{T1, T2, TResult, TRoot}"/> class.
        /// </summary>
        public ReturnAdapter()
        {
        }

        /// <summary>
        /// Visits the specified <see cref="Node"/>.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be visited.</param>
        /// <param name="arg1">The first argument passed to the visit handler.</param>
        /// <param name="arg2">The second argument passed to the visit handler.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public virtual TResult Visit(Node node, T1 arg1, T2 arg2)
        {
            return default(TResult);
        }
        /// <summary>
        /// When overridden in a derived class, specifies default handler for visiting nodes.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be visited.</param>
        /// <param name="arg1">The first argument that is passed to this visit handler.</param>
        /// <param name="arg2">The second argument that is passed to this visit handler.</param>
        /// <returns>A value determined by this visit handler.</returns>
        protected virtual TResult HandleDefault(Node node, T1 arg1, T2 arg2)
        {
            return default(TResult);
        }

        /// <summary>
        /// Visits the specified <see cref="Start{TRoot}"/> production by calling the <see cref="HandleStart"/> method.
        /// </summary>
        /// <param name="node">The <see cref="Start{TRoot}"/> production that should be visited.</param>
        /// <param name="arg1">The first argument passed to the visit handler.</param>
        /// <param name="arg2">The second argument passed to the visit handler.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public TResult Visit(Start<TRoot> node, T1 arg1, T2 arg2)
        {
            return HandleStart(node, arg1, arg2);
        }
        /// <summary>
        /// Visits the specified <see cref="EOF"/> token by calling the <see cref="HandleEOF"/> method.
        /// </summary>
        /// <param name="node">The <see cref="EOF"/> token that should be visited.</param>
        /// <param name="arg1">The first argument passed to the visit handler.</param>
        /// <param name="arg2">The second argument passed to the visit handler.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public TResult Visit(EOF node, T1 arg1, T2 arg2)
        {
            return HandleEOF(node, arg1, arg2);
        }

        /// <summary>
        /// When overridden in a derived class, specifies a handler for visiting <see cref="Start{TRoot}"/> production nodes.
        /// </summary>
        /// <param name="node">The <see cref="Start{TRoot}"/> node to handle.</param>
        /// <param name="arg1">The first argument that is passed to this visit handler.</param>
        /// <param name="arg2">The second argument that is passed to this visit handler.</param>
        /// <returns>A value determined by this visit handler.</returns>
        protected virtual TResult HandleStart(Start<TRoot> node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        /// <summary>
        /// When overridden in a derived class, specifies a handler for visiting <see cref="EOF"/> token nodes.
        /// </summary>
        /// <param name="node">The <see cref="EOF"/> node to handle.</param>
        /// <param name="arg1">The first argument that is passed to this visit handler.</param>
        /// <param name="arg2">The second argument that is passed to this visit handler.</param>
        /// <returns>A value determined by this visit handler.</returns>
        protected virtual TResult HandleEOF(EOF node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
    }

    /// <summary>
    /// Defines a base implementation of the visitor pattern in which each Visit method returns a value and takes three arguments.
    /// </summary>
    /// <typeparam name="T1">The type of the first argument for the Visit methods.</typeparam>
    /// <typeparam name="T2">The type of the second argument for the Visit methods.</typeparam>
    /// <typeparam name="T3">The type of the third argument for the Visit methods.</typeparam>
    /// <typeparam name="TResult">The type of the values that are returned by the <see cref="ReturnAdapter{T1,T2,T3,TResult,TRoot}"/></typeparam>
    /// <typeparam name="TRoot">The type of the root production in the AST.</typeparam>
    public abstract class ReturnAdapter<T1, T2, T3, TResult, TRoot> where TRoot : Production
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnAdapter{T1, T2, T3, TResult, TRoot}"/> class.
        /// </summary>
        public ReturnAdapter()
        {
        }

        /// <summary>
        /// Visits the specified <see cref="Node"/>.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be visited.</param>
        /// <param name="arg1">The first argument passed to the visit handler.</param>
        /// <param name="arg2">The second argument passed to the visit handler.</param>
        /// <param name="arg3">The third argument passed to the visit handler.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public virtual TResult Visit(Node node, T1 arg1, T2 arg2, T3 arg3)
        {
            return default(TResult);
        }
        /// <summary>
        /// When overridden in a derived class, specifies default handler for visiting nodes.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be visited.</param>
        /// <param name="arg1">The first argument that is passed to this visit handler.</param>
        /// <param name="arg2">The second argument that is passed to this visit handler.</param>
        /// <param name="arg3">The third argument that is passed to this visit handler.</param>
        /// <returns>A value determined by this visit handler.</returns>
        protected virtual TResult HandleDefault(Node node, T1 arg1, T2 arg2, T3 arg3)
        {
            return default(TResult);
        }

        /// <summary>
        /// Visits the specified <see cref="Start{TRoot}"/> production by calling the <see cref="HandleStart"/> method.
        /// </summary>
        /// <param name="node">The <see cref="Start{TRoot}"/> production that should be visited.</param>
        /// <param name="arg1">The first argument passed to the visit handler.</param>
        /// <param name="arg2">The second argument passed to the visit handler.</param>
        /// <param name="arg3">The third argument passed to the visit handler.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public TResult Visit(Start<TRoot> node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleStart(node, arg1, arg2, arg3);
        }
        /// <summary>
        /// Visits the specified <see cref="EOF"/> token by calling the <see cref="HandleEOF"/> method.
        /// </summary>
        /// <param name="node">The <see cref="EOF"/> token that should be visited.</param>
        /// <param name="arg1">The first argument passed to the visit handler.</param>
        /// <param name="arg2">The second argument passed to the visit handler.</param>
        /// <param name="arg3">The third argument passed to the visit handler.</param>
        /// <returns>A value determined by the visit handler.</returns>
        public TResult Visit(EOF node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleEOF(node, arg1, arg2, arg3);
        }

        /// <summary>
        /// When overridden in a derived class, specifies a handler for visiting <see cref="Start{TRoot}"/> production nodes.
        /// </summary>
        /// <param name="node">The <see cref="Start{TRoot}"/> node to handle.</param>
        /// <param name="arg1">The first argument that is passed to this visit handler.</param>
        /// <param name="arg2">The second argument that is passed to this visit handler.</param>
        /// <param name="arg3">The third argument that is passed to this visit handler.</param>
        /// <returns>A value determined by this visit handler.</returns>
        protected virtual TResult HandleStart(Start<TRoot> node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        /// <summary>
        /// When overridden in a derived class, specifies a handler for visiting <see cref="EOF"/> token nodes.
        /// </summary>
        /// <param name="node">The <see cref="EOF"/> node to handle.</param>
        /// <param name="arg1">The first argument that is passed to this visit handler.</param>
        /// <param name="arg2">The second argument that is passed to this visit handler.</param>
        /// <param name="arg3">The third argument that is passed to this visit handler.</param>
        /// <returns>A value determined by this visit handler.</returns>
        protected virtual TResult HandleEOF(EOF node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
    }
}
