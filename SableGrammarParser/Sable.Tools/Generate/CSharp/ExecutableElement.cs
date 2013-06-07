using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sable.Tools.Generate.CSharp
{
    public abstract class ExecutableElement : ComplexElement
    {
        private PatchElement contents;

        protected ExecutableElement()
        {
            this.contents = new PatchElement();
        }

        protected void InsertContents()
        {
            insertElement(contents);
        }

        public void EmitThis()
        {
            contents.Emit("this", UseSpace.NotPreferred, UseSpace.NotPreferred);
        }
        public void EmitIdentifier(string name)
        {
            contents.Emit(name, UseSpace.NotPreferred, UseSpace.NotPreferred);
        }
        public void EmitPeriod()
        {
            contents.Emit(".", UseSpace.NotPreferred, UseSpace.NotPreferred);
        }
        public void EmitAssignment()
        {
            contents.Emit("=", UseSpace.Preferred, UseSpace.Preferred);
        }
        public void EmitReturn()
        {
            contents.Emit("return", UseSpace.NotPreferred, UseSpace.Preferred);
        }

        public void EmitEqual()
        {
            contents.Emit("==", UseSpace.Always, UseSpace.Always);
        }
        public void EmitNotEqual()
        {
            contents.Emit("!=", UseSpace.Always, UseSpace.Always);
        }
        public void EmitGreaterThan()
        {
            contents.Emit(">", UseSpace.Always, UseSpace.Always);
        }
        public void EmitGreaterThanOrEqual()
        {
            contents.Emit(">=", UseSpace.Always, UseSpace.Always);
        }
        public void EmitLessThan()
        {
            contents.Emit("<", UseSpace.Always, UseSpace.Always);
        }
        public void EmitLessThanOrEqual()
        {
            contents.Emit("<=", UseSpace.Always, UseSpace.Always);
        }

        public void EmitTrue()
        {
            EmitIdentifier("true");
        }
        public void EmitFalse()
        {
            EmitIdentifier("false");
        }
        public void EmitNull()
        {
            EmitIdentifier("null");
        }

        public void EmitNewLine()
        {
            contents.EmitNewLine();
        }
        public void EmitSemicolon(bool newline)
        {
            contents.Emit(";", UseSpace.Never, UseSpace.Preferred);
            if (newline)
                contents.EmitNewLine();
        }
    }
}
