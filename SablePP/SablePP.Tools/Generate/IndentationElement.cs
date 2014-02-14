using System;

namespace SablePP.Tools.Generate
{
    public sealed class IndentationElement : CodeElement
    {
        private int difference;

        public IndentationElement(int difference)
        {
            this.difference = difference;
        }

        public int Difference
        {
            get { return difference; }
            set { difference = value; }
        }

        internal override UseSpace Append
        {
            get { return UseSpace.Never; }
        }
        internal override UseSpace Prepend
        {
            get { return UseSpace.Never; }
        }

        internal override void Generate(CodeStreamWriter streamwriter)
        {
            if (difference == 0)
                return;

            streamwriter.Indentation += difference;
        }

        public override string ToString()
        {
            return string.Format("Indent by {0}", difference);
        }
    }
}
