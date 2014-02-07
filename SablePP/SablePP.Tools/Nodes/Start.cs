using System;
using System.Collections.Generic;

namespace SablePP.Tools.Nodes
{
    /// <summary>
    /// Represents a <see cref="Production"/> node that serves as the structural root of an AST, containing the actual root production.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root production.</typeparam>
    public class Start<TRoot> : Production<Start<TRoot>> where TRoot : Node
    {
        private TRoot _base_;
        private EOF _eof_;

        /// <summary>
        /// Initializes a new instance of the <see cref="Start{TRoot}"/> class.
        /// </summary>
        /// <param name="_base_">A <typeparamref name="TRoot"/> production representing an AST. This value cannot be <c>null</c>.</param>
        /// <param name="_eof_">An <see cref="EOF"/> token that should be associated with the AST. This value cannot be <c>null</c>.</param>
        public Start(TRoot _base_, EOF _eof_)
        {
            this.Root = _base_;
            this.EOF = _eof_;
        }

        /// <summary>
        /// Gets or sets the root production representing the AST. This value cannot be <c>null</c>.
        /// </summary>
        public TRoot Root
        {
            get
            {
                return _base_;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("PProgram in Start cannot be null.", "value");
                SetParent(value, this);

                _base_ = value;
            }
        }
        /// <summary>
        /// Gets or sets the <see cref="EOF"/> node associated with the AST. This value cannot be <c>null</c>.
        /// </summary>
        public EOF EOF
        {
            get
            {
                return _eof_;
            }
            set
            {
                if (_eof_ != null)
                    SetParent(_eof_, null);
                if (value != null)
                    SetParent(value, this);

                _eof_ = value;
            }
        }

        /// <summary>
        /// Clones this AST (and recursively all children) and returns an element of type <see cref="Start{TRoot}"/>.
        /// </summary>
        /// <returns>A new <see cref="Start{TRoot}"/> production element that is a copy of this instance.</returns>
        public override Start<TRoot> Clone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Replaces a child node in this <see cref="Start{TRoot}"/> by another child node.
        /// </summary>
        /// <param name="oldChild">The old child node.</param>
        /// <param name="newChild">The new child node.</param>
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Root == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Root in Start cannot be null.", "newChild");
                if (!(newChild is TRoot) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Root = newChild as TRoot;
            }
            if (EOF == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("EOF in Start cannot be null.", "newChild");
                if (!(newChild is EOF) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                EOF = newChild as EOF;
            }
        }
        /// <summary>
        /// Gets all children associated with this node in order.
        /// </summary>
        /// <returns>The <see cref="Start{T}.Root"/> node followed by the <see cref="Start{T}.EOF"/> node.</returns>
        protected internal override IEnumerable<Node> GetChildren()
        {
            yield return _base_;
            yield return _eof_;
        }
    }
}
