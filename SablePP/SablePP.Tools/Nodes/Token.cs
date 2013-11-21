using System;

namespace SablePP.Tools.Nodes
{
    public abstract class Token<T> : Token where T : Token
    {
        public Token(string text)
            : base(text)
        {
        }
        public Token(string text, int line, int pos)
            : base(text, line, pos)
        {
        }

        public abstract T Clone();
        public override Node CloneNode()
        {
            return Clone();
        }

        public void ReplaceBy(T node)
        {
            if (this.GetParent() != null)
                this.GetParent().ReplaceChild(this, node);
        }
    }

    public abstract class Token : Node
    {
        private string text;
        private int line;
        private int pos;

        public Token(string text)
        {
            this.Text = text;
            this.Line = -1;
            this.Position = -1;
        }
        public Token(string text, int line, int pos)
        {
            this.Text = text;
            this.Line = line;
            this.Position = pos;
        }

        public string Text
        {
            get { return text; }
            private set { text = value; }
        }
        public int Line
        {
            get { return line; }
            private set { line = value; }
        }
        public int Position
        {
            get { return pos; }
            private set { pos = value; }
        }

        public override string ToString()
        {
            return text;
        }
    }
}
