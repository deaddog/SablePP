using System;
using System.Collections.Generic;

namespace Sable.Tools.Generate.CSharp
{
    public class ClassElement : ComplexElement
    {
        private string name;
        private AccessModifiers modifiers;
        private PatchElement contents;

        public ClassElement(string name, AccessModifiers modifiers)
        {
            this.name = name;
            this.modifiers = modifiers;
            this.contents = new PatchElement();

            modifiers.Emit(emit);
            emit("class", UseSpace.Always, UseSpace.Always);
            emit(name, UseSpace.Always, UseSpace.NotPreferred);

            emitNewLine();
            emit("{", UseSpace.Never, UseSpace.Never);
            emitNewLine();
            increaseIndentation();
            insertElement(contents);
            decreaseIndentation();
            emit("}", UseSpace.Never, UseSpace.Never);
            emitNewLine();
        }
    }
}
