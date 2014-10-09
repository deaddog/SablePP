using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate
{
    public abstract class GrammarPart
    {
        private GrammarPart _parent;
        internal GrammarPart parent
        {
            get { return _parent; }
            set
            {
                if (!canBeParent(value))
                    throw new ArgumentException("The selected element cannot be the parent of this " + this.GetType().Name + ".", "value");
                else if (this._parent != null)
                    throw new ArgumentException("The parent of this " + this.GetType().Name + " is already set.", "value");
                else
                    this._parent = value;
            }
        }

        public GrammarPart()
        {
            this._parent = null;
        }

        internal abstract bool canBeParent(GrammarPart part);
    }
}
