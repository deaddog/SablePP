using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sable.Tools.Generate
{
    public sealed class PatchElement : ComplexElement
    {
        public PatchElement()
        {
        }

        public void InsertElement(CodeElement element)
        {
            base.insertElement(element);
        }
        public void Emit(string text, UseSpace prepend, UseSpace append, params object[] args)
        {
            base.emit(text, prepend, append, args);
        }
        public void EmitNewLine()
        {
            base.insertElement(new NewLineElement());
        }

        public void IncreaseIndentation()
        {
            base.increaseIndentation();
        }
        public void DecreaseIndentation()
        {
            base.decreaseIndentation();
        }

        public void ChangeIndentation(int difference)
        {
            base.changeIndentation(difference);
        }
    }
}
