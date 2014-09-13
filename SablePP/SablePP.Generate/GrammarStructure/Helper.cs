using SablePP.Generate.RegularExpressions;
using System;

namespace SablePP.Generate
{
    public class Helper
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
    }
}
