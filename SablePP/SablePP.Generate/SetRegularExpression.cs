using System;

namespace SablePP.Generate
{
    public class SetRegularExpression : RegularExpression
    {
        private RegularExpression from, to;
        private SetTypes type;

        public SetRegularExpression(char from, char to, SetTypes setType)
        {
            this.from = new LiteralRegularExpression(from);
            this.to = new LiteralRegularExpression(to);

            this.type = setType;
        }

        public SetRegularExpression(SetRegularExpression from, char to, SetTypes setType)
        {
            if (from == null)
                throw new ArgumentNullException("from");

            this.from = from;
            this.to = new LiteralRegularExpression(to);
            this.type = setType;
        }

        public SetRegularExpression(char from, SetRegularExpression to, SetTypes setType)
        {
            if (to == null)
                throw new ArgumentNullException("to");

            this.from = new LiteralRegularExpression(from);
            this.to = to;
            this.type = setType;
        }

        public SetRegularExpression(SetRegularExpression from, SetRegularExpression to, SetTypes setType)
        {
            if (from == null)
                throw new ArgumentNullException("from");

            if (to == null)
                throw new ArgumentNullException("to");

            this.from = from;
            this.to = to;
            this.type = setType;
        }

        public RegularExpression From
        {
            get { return from; }
        }
        public RegularExpression To
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
