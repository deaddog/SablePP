using System;
using SablePP.Tools.Nodes;

namespace SablePP.Tools.Analysis
{
    /// <summary>
    /// Defines a base implementation of the visitor pattern in which each Visit method returns a value and takes an argument.
    /// </summary>
    /// <typeparam name="T">The type of the values that are returned by the <see cref="ReturnAdapter{T,TRoot}"/>.</typeparam>
    /// <typeparam name="TRoot">The type of the root production in the AST.</typeparam>
    public abstract class ReturnAdapter<T, TRoot> where TRoot : Node
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
    }
}
