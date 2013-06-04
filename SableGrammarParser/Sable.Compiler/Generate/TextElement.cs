﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sable.Compiler.Generate
{
    internal sealed class TextElement : CodeElement
    {
        private UseSpace prepend, append;
        private string text;

        public TextElement(string text, UseSpace prepend, UseSpace append)
        {
            this.text = text;
            this.prepend = prepend;
            this.append = append;
        }

        public override UseSpace Append
        {
            get { return append; }
        }
        public override UseSpace Prepend
        {
            get { return prepend; }
        }

        public void AppendText(string text, UseSpace prepend, UseSpace append)
        {
            this.text = this.text + (useSpace(this.Append, prepend) ? " " : "") + text;
            this.append = append;
        }

        public override void Generate(CodeStreamWriter streamwriter)
        {
            streamwriter.WriteString(text);
            streamwriter.LastElement = this;
        }

        public override string ToString()
        {
            return text;
        }
    }
}
