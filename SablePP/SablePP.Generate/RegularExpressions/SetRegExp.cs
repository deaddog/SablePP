using System;

namespace SablePP.Generate.RegularExpressions
{
    public class SetRegExp : RegExp
    {
        private RegExp from, to;
        private SetTypes type;

        public SetRegExp(RegExp from, RegExp to, SetTypes setType)
        {
            if (from == null)
                throw new ArgumentNullException("from");

            if (to == null)
                throw new ArgumentNullException("to");

            this.from = from;
            this.to = to;
            this.type = setType;
        }

        public RegExp From
        {
            get { return from; }
        }
        public RegExp To
        {
            get { return to; }
        }

        public SetTypes SetType
        {
            get { return type; }
        }

        public enum SetTypes
        {
            Union,
            Complement,
            Range
        }
    }
}
