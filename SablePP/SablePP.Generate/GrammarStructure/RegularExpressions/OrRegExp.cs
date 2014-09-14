﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate.RegularExpressions
{
    public class OrRegExp : RegExp
    {
        private RegExp[] expressions;

        public OrRegExp(IEnumerable<RegExp> expressions)
        {
            if (expressions == null)
                throw new ArgumentNullException("expressions");

            this.expressions = expressions.ToArray();

            if (this.expressions.Length == 0)
                throw new ArgumentOutOfRangeException("An or-regular-expression cannot consist of one regular expression.");
        }

        public RegExp[] Expressions
        {
            get { return expressions; }
        }
    }
}