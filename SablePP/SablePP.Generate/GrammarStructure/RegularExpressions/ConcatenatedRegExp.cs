using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate.RegularExpressions
{
    public class ConcatenatedRegExp : RegExp
    {
        private RegExp[] expressions;

        public ConcatenatedRegExp(IEnumerable<RegExp> expressions)
        {
            if (expressions == null)
                throw new ArgumentNullException("expressions");

            this.expressions = expressions.ToArray();
            foreach (var e in this.expressions)
                e.parent = this;

            if (this.expressions.Length == 0)
                throw new ArgumentOutOfRangeException("A concatenated-regular-expression cannot consist of one regular expression.");
        }

        public RegExp[] Expressions
        {
            get { return expressions; }
        }
    }
}
