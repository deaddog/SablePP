using System;
using System.Threading;

using SablePP.Tools.Nodes;

namespace SablePP.Tools.Analysis
{
    /// <summary>
    /// Represents a class that allows the traversal of an AST regardless of the associated language.
    /// This functions as a generalized implementation of the visitor pattern.
    /// </summary>
    public abstract class TreeWalker
    {
        /// <summary>
        /// When overridden in a derived class, performs tasks related to a single <see cref="Token"/> by 'visiting' it.
        /// </summary>
        /// <param name="token">The <see cref="Token"/> to visit.</param>
        public abstract void Visit(Token token);
        /// <summary>
        /// When overridden in a derived class, performs tasks related to a single <see cref="Production"/> by 'visiting' it.
        /// </summary>
        /// <param name="production">The <see cref="Production"/> to visit.</param>
        public abstract void Visit(Production production);
        /// <summary>
        /// Visits a <see cref="Node"/> by calling the <see cref="Token"/> or <see cref="Production"/> specific Visit method.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> to visit.</param>
        public void Visit(Node node)
        {
            if (node is Token)
                Visit(node as Token);
            else if (node is Production)
                Visit(node as Production);
        }

        /// <summary>
        /// Visits a node (and possibly substructure) using multiple instances of <see cref="TreeWalker"/> in parallel.
        /// The method returns when all walkers have completed execution.
        /// </summary>
        /// <param name="node">The node to visit.</param>
        /// <param name="walkers">The collection of <see cref="TreeWalker"/> on which the Visit method should be invoked.</param>
        public static void VisitInParallel(Node node, params TreeWalker[] walkers)
        {
            Thread[] threads = new Thread[walkers.Length];
            for (int i = 0; i < walkers.Length; i++)
            {
                TreeWalker walker = walkers[i];
                Thread t = new Thread(() => walker.Visit(node));
                t.Start();
            }
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();
        }
    }
}
