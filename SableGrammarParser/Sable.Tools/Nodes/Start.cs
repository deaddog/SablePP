using System;

namespace Sable.Tools.Nodes
{
    public class Start<TRoot> : Production<Start<TRoot>> where TRoot : Node
    {
        private TRoot _base_;
        private EOF _eof_;

        public Start(TRoot _base_, EOF _eof_)
        {
            this.Root = _base_;
            this.EOF = _eof_;
        }

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

        public override Start<TRoot> Clone()
        {
            throw new NotImplementedException();
        }

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
    }
}
