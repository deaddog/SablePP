using System;

namespace SablePP.Tools.Generate.CSharp
{
    public sealed class BlockElement : CodeElement
    {
        private CodeElement content;
        private bool multiline;

        public BlockElement(CodeElement content, bool multiline)
        {
            this.content = content;
            this.multiline = multiline;
        }

        public bool Multiline
        {
            get { return multiline; }
            set { multiline = value; }
        }

        internal override UseSpace Append
        {
            get { return UseSpace.Preferred; }
        }

        internal override UseSpace Prepend
        {
            get { return UseSpace.Preferred; }
        }

        internal override void Generate(CodeStreamWriter streamwriter)
        {
            streamwriter.WriteString("{");

            if (multiline)
            {
                streamwriter.WriteNewline();
                streamwriter.Indentation++;
            }
            else
                streamwriter.WriteString(" ");

            content.Generate(streamwriter);

            if (multiline)
            {
                streamwriter.WriteNewline();
                streamwriter.Indentation--;
            }
            else
                streamwriter.WriteString(" ");

            streamwriter.WriteString("}");
        }
    }
}
