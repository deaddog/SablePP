using System;

namespace SablePP.Generate
{
    class ModifiedRegularExpression : RegularExpression
    {
        private RegularExpression expression;
        private Modifiers modifier;

        public ModifiedRegularExpression(RegularExpression expression, Modifiers modifier)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            if (modifier != Modifiers.Optional && modifier != Modifiers.OneOrMany && modifier != Modifiers.ZeroOrMany)
                throw new ArgumentOutOfRangeException("modifier", "Unknown modifier.");

            this.expression = expression;
            this.modifier = modifier;
        }

        public RegularExpression Expression
        {
            get { return expression; }
        }

        public Modifiers Modifier
        {
            get { return modifier; }
        }
    }
}
