using System;

namespace SablePP.Generate
{
    public class State : GrammarPart
    {
        public State()
        {
        }

        internal override bool canBeParent(GrammarPart part)
        {
            return part is Grammar;
        }
        public Grammar Parent
        {
            get { return base.parent as Grammar; }
        }
    }
}
