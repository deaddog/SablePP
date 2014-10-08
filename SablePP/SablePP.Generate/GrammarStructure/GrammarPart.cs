using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate
{
    public abstract class GrammarPart
    {
        private GrammarPart parent;

        public GrammarPart()
        {
            this.parent = null;
        }

        internal abstract bool canBeParent(GrammarPart part);
        internal void SetParent<T>(GrammarPart part)
        {
            if (!canBeParent(part))
                throw new ArgumentException("The selected element cannot be the parent of this " + this.GetType().Name + ".", "part");
            else if (parent != null)
                throw new ArgumentException("The parent of this " + this.GetType().Name + " is already set.", "part");
            else
                this.parent = part;
        }
    }
}
