using SablePP.Generate.RegularExpressions;
using System;

namespace SablePP.Generate
{
    public class Helper : GrammarPart
    {
        private RegExp expression;

        public Helper(RegExp expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            this.expression = expression;
        }

        public RegExp Expression
        {
            get { return expression; }
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
