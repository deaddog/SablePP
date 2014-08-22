using System;

namespace SablePP.Generate.RegularExpressions
{
    public class SetRegExp : RegExp
    {
        private RegExp from, to;
        private SetTypes type;

        public SetRegExp(char from, char to, SetTypes setType)
        {
            this.from = new LiteralRegExp(from);
            this.to = new LiteralRegExp(to);

            this.type = setType;
        }

        public SetRegExp(SetRegExp from, char to, SetTypes setType)
        {
            if (from == null)
                throw new ArgumentNullException("from");

            this.from = from;
            this.to = new LiteralRegExp(to);
            this.type = setType;
        }

        public SetRegExp(char from, SetRegExp to, SetTypes setType)
        {
            if (to == null)
                throw new ArgumentNullException("to");

            this.from = new LiteralRegExp(from);
            this.to = to;
            this.type = setType;
        }

        public SetRegExp(SetRegExp from, SetRegExp to, SetTypes setType)
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
