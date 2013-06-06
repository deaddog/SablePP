using System;
using System.Collections.Generic;

namespace Sable.Tools.Generate.CSharp
{
    public class ClassElement : ComplexElement
    {
        private string name;
        public string Name
        {
            get { return name; }
        }

        private AccessModifiers modifiers;
        public AccessModifiers Modifiers
        {
            get { return modifiers; }
        }

        private string implements;
        public string Implements
        {
            get { return implements; }
        }

        private PatchElement contents;

        public ClassElement(string name, AccessModifiers modifiers, string implements)
        {
            this.name = name;
            this.modifiers = modifiers;
            this.contents = new PatchElement();

            if (implements != null)
                implements = implements.Trim();
            if (implements.Length == 0)
                implements = null;

            this.implements = implements;

            modifiers.Emit(emit);
            emit("class", UseSpace.Always, UseSpace.Always);
            emit(name, UseSpace.Always, UseSpace.NotPreferred);
            
            if (implements != null)
            {
                emit(":", UseSpace.Always, UseSpace.Always);
                emit(implements, UseSpace.Preferred, UseSpace.NotPreferred);
            }

            emitNewLine();
            emit("{", UseSpace.Never, UseSpace.Never);
            emitNewLine();
            increaseIndentation();
            insertElement(contents);
            decreaseIndentation();
            emit("}", UseSpace.Never, UseSpace.Never);
            emitNewLine();
        }

        public void EmitField(string name, string type, AccessModifiers modifiers)
        {
            modifiers.Emit(contents.Emit);
            contents.Emit(type, UseSpace.NotPreferred, UseSpace.Preferred);
            contents.Emit(name, UseSpace.NotPreferred, UseSpace.Preferred);
            contents.Emit(";", UseSpace.Never, UseSpace.Never);
            contents.EmitNewLine();
        }
    }
}
