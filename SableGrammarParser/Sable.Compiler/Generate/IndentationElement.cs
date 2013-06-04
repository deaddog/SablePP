using System;

namespace Sable.Compiler.Generate
{
    internal sealed class IndentationElement : CodeElement
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

        public override UseSpace Append
        {
            get { return UseSpace.NotPreferred; }
        }
        public override UseSpace Prepend
        {
            get { return UseSpace.Never; }
        }

        public override void Generate(CodeStreamWriter streamwriter)
        {
            if (!(streamwriter.LastElement is NewLineElement))
                throw new Exception("Can only change indentation after newline.");

            streamwriter.Indentation += difference;
            string indent = "".PadRight(Math.Abs(difference) * streamwriter.IndentationSize);

            if (difference > 0)
                streamwriter.WriteString(indent);
            else if (difference < 0)
                streamwriter.RemoveFromEnd(indent);
        }

        public override string ToString()
        {
            return string.Format("Indent by {0}", difference);
        }
    }
}
