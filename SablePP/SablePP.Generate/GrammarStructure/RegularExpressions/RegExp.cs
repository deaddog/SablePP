using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SablePP.Generate.RegularExpressions
{
    public abstract class RegExp : GrammarPart
    {
        public static RegExp FromChar(char content)
        {
            return new LiteralRegExp(content);
        }
        public static RegExp FromString(string content)
        {
            return new LiteralRegExp(content);
        }

        internal override bool canBeParent(GrammarPart part)
        {
            return part is Helper || part is Token || part is RegExp;
        }
        public Helper ParentHelper
        {
            get { return base.parent as Helper; }
        }
        public Token ParentToken
        {
            get { return base.parent as Token; }
        }
        public RegExp ParentRegExp
        {
            get { return base.parent as RegExp; }
        }
    }
}
