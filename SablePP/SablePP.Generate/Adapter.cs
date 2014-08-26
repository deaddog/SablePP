using SablePP.Generate.RegularExpressions;
using SablePP.Generate.Translations;

namespace SablePP.Generate
{
    public class Adapter
    {
        public virtual void Visit(Grammar node)
        { }

        public virtual void Visit(Helper node)
        { }

        public virtual void Visit(State node)
        { }

        public virtual void Visit(Token node)
        { }

        public virtual void Visit(Production node)
        { }

        public virtual void Visit(Alternative node)
        { }

        public virtual void Visit(AbstractProduction node)
        { }

        public virtual void Visit(AbstractAlternative node)
        { }

        public virtual void Visit(ConcatenatedRegExp node)
        { }
        public virtual void Visit(LiteralRegExp node)
        { }
        public virtual void Visit(ModifiedRegExp node)
        { }
        public virtual void Visit(OrRegExp node)
        { }
        public virtual void Visit(ReferenceRegExp node)
        { }
        public virtual void Visit(SetRegExp node)
        { }

        public virtual void Visit(ElementTranslation node)
        { }
        public virtual void Visit(ListTranslation node)
        { }
        public virtual void Visit(NewTranslation node)
        { }
        public virtual void Visit(NullTranslation node)
        { }
    }
}
