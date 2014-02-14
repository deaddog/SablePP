﻿using System;
using System.Text;

namespace SablePP.Tools.Generate
{
    public sealed class NewLineElement : CodeElement
    {
        public NewLineElement()
        {
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
            streamwriter.WriteNewline();
        }

        public override string ToString()
        {
            return "[New line]";
        }
    }
}
