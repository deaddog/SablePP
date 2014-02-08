using System;

namespace SablePP.Tools.Nodes
{
    /// <summary>
    /// Represents a token (a leaf node) in an AST.
    /// </summary>
    /// <typeparam name="T">The type of the token.</typeparam>
    public abstract class Token<T> : Token where T : Token
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Token{T}"/> class.
        /// </summary>
        /// <param name="text">The text associated with the token.</param>
        public Token(string text)
            : base(text)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Token{T}"/> class.
        /// </summary>
        /// <param name="text">The text associated with the token.</param>
        /// <param name="line">The line (one-based) where the token is located in the source.</param>
        /// <param name="pos">The position (one-based) where the token is located in the source line.</param>
        public Token(string text, int line, int pos)
            : base(text, line, pos)
        {
        }

        /// <summary>
        /// Clones this instance and returns an element of type <typeparamref name="T"/>.
        /// </summary>
        /// <returns>A new <typeparamref name="T"/> token element that is a copy of this instance.</returns>
        public abstract T Clone();
        /// <summary>
        /// Creates a new <see cref="Node"/> object that is a copy of this instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="Node"/> object that is a copy of this instance.
        /// </returns>
        public override Node CloneNode()
        {
            return Clone();
        }

        /// <summary>
        /// Replaces this <see cref="Token{T}"/> element by another node in its parent <see cref="Production"/> if one exists.
        /// </summary>
        /// <param name="node">The node to replace this node with.</param>
        public void ReplaceBy(T node)
        {
            if (this.GetParent() != null)
                this.GetParent().ReplaceChild(this, node);
        }
    }

    /// <summary>
    /// Represents a token (a leaf node) in an AST.
    /// </summary>
    public abstract class Token : Node
    {
        private string text;
        private int line;
        private int pos;

        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class.
        /// </summary>
        /// <param name="text">The text associated with the token.</param>
        public Token(string text)
        {
            this.Text = text;
            this.Line = -1;
            this.Position = -1;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class.
        /// </summary>
        /// <param name="text">The text associated with the token.</param>
        /// <param name="line">The line (one-based) where the token is located in the source.</param>
        /// <param name="pos">The position (one-based) where the token is located in the source line.</param>
        public Token(string text, int line, int pos)
        {
            this.Text = text;
            this.Line = line;
            this.Position = pos;
        }

        /// <summary>
        /// Gets the text associated with the token.
        /// </summary>
        public string Text
        {
            get { return text; }
            private set { text = value; }
        }
        /// <summary>
        /// Gets the line (one-based) where the token is located in the source.
        /// </summary>
        public int Line
        {
            get { return line; }
            private set { line = value; }
        }
        /// <summary>
        /// Gets the position (one-based) where the token is located in the source line.
        /// </summary>
        public int Position
        {
            get { return pos; }
            private set { pos = value; }
        }

        /// <summary>
        /// Returns the <see cref="Token.Text"/> property of this <see cref="Token"/> instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return text;
        }
    }
}
