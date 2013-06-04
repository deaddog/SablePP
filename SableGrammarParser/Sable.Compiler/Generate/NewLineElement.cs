using System;
using System.Text;

namespace Sable.Compiler.Generate
{
    internal sealed class NewLineElement : CodeElement
    {
        public NewLineElement()
        {
        }

        public override UseSpace Append
        {
            get { return UseSpace.Never; }
        }
        public override UseSpace Prepend
        {
            get { return UseSpace.Never; }
        }

        public override void Generate(CodeStreamWriter streamwriter)
        {
            streamwriter.WriteString("\r\n".PadRight(2 + streamwriter.Indentation * streamwriter.IndentationSize));
            streamwriter.LastElement = this;
        }

        public override string ToString()
        {
            return "[New line]";
        }
    }
}
