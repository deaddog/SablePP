using System;
using System.Collections.Generic;
using System.Threading;

using SablePP.Tools.Nodes;

namespace SablePP.Tools.Analysis
{
    /// <summary>
    /// Defines a base implementation of the visitor pattern including two tables for storing node input and output values.
    /// </summary>
    /// <typeparam name="TValue">The type of values to store in <see cref="Adapter{TValue, TRoot}.Input"/> and <see cref="Adapter{TValue, TRoot}.Output"/>.</typeparam>
    /// <typeparam name="TRoot">The type of the root production in the AST.</typeparam>
    public abstract class Adapter<TValue, TRoot> where TRoot : Node
    {
        /// <summary>
        /// Defines a simple dictionary using <see cref="Node"/> as key type and <typeparamref name="TValue"/> as value type.
        /// </summary>
        public class Table
        {
            private Dictionary<Node, TValue> dict;

            internal Table()
            {
                dict = new Dictionary<Node, TValue>();
            }

            /// <summary>
            /// Gets or sets the <typeparamref name="TValue"/> associated with the specified <see cref="Node"/>.
            /// </summary>
            /// <param name="key">The <see cref="Node"/> of the <typeparamref name="TValue"/> to get or set.</param>
            /// <returns>The value associated with the specified <see cref="Node"/>.</returns>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Adapter{TValue, TRoot}"/> class.
        /// </summary>
        public Adapter()
        {
            this.input = new Table();
            this.output = new Table();
        }

        /// <summary>
        /// Gets a table that associates nodes with input values.
        /// </summary>
        public Table Input
        {
            get { return input; }
        }
        /// <summary>
        /// Gets a table that associates nodes with output values.
        /// </summary>
        public Table Output
        {
            get { return output; }
        }

        /// <summary>
        /// Visits the specified <see cref="Node"/>.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be visited.</param>
        public virtual void Visit(Node node)
        {
        }
        /// <summary>
        /// When overridden in a derived class, specifies default handler for visiting nodes.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be visited.</param>
        public virtual void DefaultCase(Node node)
        {
        }

        /// <summary>
        /// Visits the specified <see cref="Start{TRoot}"/> production by calling the <see cref="CaseStart"/> method.
        /// </summary>
        /// <param name="node">The <see cref="Start{TRoot}"/> node that should be visited.</param>
        public void Visit(Start<TRoot> node)
        {
            CaseStart(node);
        }
        /// <summary>
        /// Visits the specified <see cref="EOF"/> token by calling the <see cref="CaseEOF"/> method.
        /// </summary>
        /// <param name="node">The <see cref="EOF"/> node that should be visited.</param>
        public void Visit(EOF node)
        {
            CaseEOF(node);
        }
        /// <summary>
        /// When overridden in a derived class, specifies a handler for visiting <see cref="Start{TRoot}"/> production nodes.
        /// </summary>
        /// <param name="node">The <see cref="Start{TRoot}"/> node to handle.</param>
        public virtual void CaseStart(Start<TRoot> node)
        {
            DefaultCase(node);
        }
        /// <summary>
        /// When overridden in a derived class, specifies a handler for visiting <see cref="EOF"/> token nodes.
        /// </summary>
        /// <param name="node">The <see cref="EOF"/> node to handle.</param>
        public virtual void CaseEOF(EOF node)
        {
            DefaultCase(node);
        }

        /// <summary>
        /// Visits a node (and possibly substructure) using multiple instances of <see cref="Adapter{TValue,TRoot}"/> in parallel.
        /// The method returns when all adapters have completed execution.
        /// </summary>
        /// <param name="node">The node to visit.</param>
        /// <param name="adapters">The collection of <see cref="Adapter{TValue,TRoot}"/> on which the Visit method should be invoked.</param>
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
