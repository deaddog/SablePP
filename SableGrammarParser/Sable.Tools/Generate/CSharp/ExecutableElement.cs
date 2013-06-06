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

        public void EmitNewLine()
        {
            contents.EmitNewLine();
        }
        public void EmitSemicolon(bool newline)
        {
            contents.Emit(";", UseSpace.NotPreferred, UseSpace.Preferred);
            if (newline)
                contents.EmitNewLine();
        }
    }
}
