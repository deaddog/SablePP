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
            foreach (var e in this.expressions)
                e.parent = this;

            if (this.expressions.Length == 0)
                throw new ArgumentOutOfRangeException("An or-regular-expression cannot consist of one regular expression.");
        }

        public RegExp[] Expressions
        {
            get { return expressions; }
        }

        public override string GetStringLiteral()
        {
            if (expressions.Length == 0)
                return "";
            else if (expressions.Length == 1)
                return expressions[0].GetStringLiteral();
            else
            {
                string lit = expressions[0].GetStringLiteral();
                for (int i = 1; i < expressions.Length; i++)
                    if (expressions[i].GetStringLiteral() != lit)
                        return null;
                return lit;
            }
        }
    }
}
