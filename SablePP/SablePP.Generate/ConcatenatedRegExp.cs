using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate
{
    public class ConcatenatedRegExp : RegExp
    {
        private RegExp[] expressions;

        public ConcatenatedRegExp(IEnumerable<RegExp> expressions)
        {
            if (expressions == null)
                throw new ArgumentNullException("expressions");

            this.expressions = expressions.ToArray();

            if (this.expressions.Length == 0)
                throw new ArgumentOutOfRangeException("A concatenated-regular-expression cannot consist of one regular expression.");
        }

        public RegExp[] Expressions
        {
            get { return expressions; }
        }
    }
}
