using System;

namespace SablePP.Generate.RegularExpressions
{
    public class ModifiedRegExp : RegExp
    {
        private RegExp expression;
        private Modifiers modifier;

        public ModifiedRegExp(RegExp expression, Modifiers modifier)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            if (!modifier.Exists())
                throw new ArgumentOutOfRangeException("modifier", "Unknown modifier.");

            this.expression = expression;
            this.modifier = modifier;
        }

        public RegExp Expression
        {
            get { return expression; }
        }

        public Modifiers Modifier
        {
            get { return modifier; }
        }
    }
}
