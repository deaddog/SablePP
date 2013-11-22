﻿using System;
using System.Collections.Generic;

namespace SablePP.Tools.Generate.CSharp
{
    public class InterfaceElement : ComplexElement
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

        private TypeParametersElement typeParameters;
        public TypeParametersElement TypeParameters
        {
            get { return typeParameters; }
        }

        private string implements;
        public string Implements
        {
            get { return implements; }
        }

        private PatchElement contents;

        public InterfaceElement(string name, AccessModifiers modifiers, string implements)
        {
            this.name = name;
            this.modifiers = modifiers;

            this.typeParameters = new TypeParametersElement();

            if (implements != null)
            {
                implements = implements.Trim();
                if (implements.Length == 0)
                    implements = null;
            }

            this.implements = implements;
            this.contents = new PatchElement();

            modifiers.Emit(emit);
            emit("interface", UseSpace.Always, UseSpace.Always);
            emit(name, UseSpace.Always, UseSpace.NotPreferred);
            insertElement(typeParameters);

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

        public void EmitNewLine()
        {
            contents.EmitNewLine();
        }

        public void EmitField(string name, string type, AccessModifiers modifiers)
        {
            modifiers.Emit(contents.Emit);
            contents.Emit(type, UseSpace.NotPreferred, UseSpace.Preferred);
            contents.Emit(name, UseSpace.NotPreferred, UseSpace.Preferred);
            contents.Emit(";", UseSpace.Never, UseSpace.Never);
            contents.EmitNewLine();
        }

        public NoBodyMethodElement CreateMethod(string name, string returnType)
        {
            NoBodyMethodElement method = new NoBodyMethodElement(AccessModifiers.None, name, returnType);
            contents.InsertElement(method);
            return method;
        }
        public void EmitProperty(string name, string type)
        {
            emitProperty(name, type, true, true);
        }
        public void EmitSetProperty(string name, string type)
        {
            emitProperty(name, type, false, true);
        }
        public void EmitGetProperty(string name, string type)
        {
            emitProperty(name, type, true, false);
        }

        private void emitProperty(string name, string type, bool hasGetter, bool hasSetter)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (name == string.Empty)
                throw new ArgumentException("Property must have a name.", "name");

            if (type == null)
                throw new ArgumentNullException("type");
            if (type == string.Empty)
                throw new ArgumentException("Property must have a type.", "type");

            AccessModifiers.None.Emit(contents.Emit);
            contents.Emit(type.Trim(), UseSpace.NotPreferred, UseSpace.Always);
            contents.Emit(name.Trim(), UseSpace.NotPreferred, UseSpace.Always);
            
            contents.Emit("{", UseSpace.Always, UseSpace.Preferred);

            if (hasGetter)
            {
                contents.Emit("get;", UseSpace.NotPreferred, UseSpace.Preferred);
            }
            if (hasSetter)
            {
                contents.Emit("set;", UseSpace.NotPreferred, UseSpace.Preferred);
            }

            contents.Emit("}", UseSpace.Preferred, UseSpace.Never);
            contents.EmitNewLine();
        }
    }
}