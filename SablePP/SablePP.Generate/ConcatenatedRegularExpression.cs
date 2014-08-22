using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate
{
    public class ConcatenatedRegularExpression : RegularExpression
    {
        private RegularExpression[] expressions;

        public ConcatenatedRegularExpression(IEnumerable<RegularExpression> expressions)
        {
            if (expressions == null)
                throw new ArgumentNullException("expressions");

            this.expressions = expressions.ToArray();

            if (this.expressions.Length == 0)
                throw new ArgumentOutOfRangeException("A concatenated-regular-expression cannot consist of one regular expression.");
        }

        public RegularExpression[] Expressions
        {
            get { return expressions; }
        }
    }
}
