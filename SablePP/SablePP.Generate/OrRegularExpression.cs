using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate
{
    public class OrRegularExpression : RegularExpression
    {
        private RegularExpression[] expressions;

        public OrRegularExpression(IEnumerable<RegularExpression> expressions)
        {
            if (expressions == null)
                throw new ArgumentNullException("expressions");

            this.expressions = expressions.ToArray();

            if (this.expressions.Length == 0)
                throw new ArgumentOutOfRangeException("An or-regular-expression cannot consist of one regular expression.");
        }

        public RegularExpression[] Expressions
        {
            get { return expressions; }
        }
    }
}
