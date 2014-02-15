﻿using System;
using System.Collections.Generic;

namespace SablePP.Tools.Generate.CSharp
{
    public class MethodElement : ExecutableElement
    {
        private string name;
        public string Name
        {
            get { return name; }
        }

        private AccessModifierElement modifiers;
        public AccessModifiers Modifiers
        {
            get { return modifiers.Modifiers; }
            set { modifiers.Modifiers = value; }
        }

        private ParametersElement parameters;
        public ParametersElement Parameters
        {
            get { return parameters; }
        }

        private TypeParametersElement typeParameters;
        public TypeParametersElement TypeParameters
        {
            get { return typeParameters; }
        }

        public MethodElement(string signature, string chaincall = null)
        {
            if (signature == null)
                throw new ArgumentNullException("signature");
            signature = signature.Trim();
            int start, length;

            // Parse the modifiers
            this.modifiers = AccessModifierElement.Parse(signature, out start, out length);
            emit(signature.Substring(0, start));
            insertElement(modifiers);
            signature = signature.Substring(start + length).TrimStart();

            // Find the parameters
            int parIndex = signature.IndexOf('(');

            // Parse the name
            name = signature.Substring(0, parIndex).TrimEnd();
            emit(name);
            while (name.EndsWith(">") || name.EndsWith("<"))
                name = name.Substring(0, name.LastIndexOf('<')).TrimEnd();
            if (name.Contains(" "))
                name = name.Substring(name.LastIndexOf(' ') + 1);
            signature = signature.Substring(parIndex);

            emit(signature);
        }

        public class ChainElement : ExecutableElement
        {
            private bool isbase;

            public bool IsBase
            {
                get { return isbase; }
            }
            public bool IsThis
            {
                get { return !isbase; }
            }

            public ChainElement(bool isbase)
            {
                this.isbase = isbase;

                increaseIndentation();
                emit(":", UseSpace.Never, UseSpace.Always);
                emit(isbase ? "base" : "this", UseSpace.Always, UseSpace.Never);
                emit("(", UseSpace.Never, UseSpace.Never);
                InsertContents();
                emit(")", UseSpace.Never, UseSpace.Never);
                emitNewLine();
                decreaseIndentation();
            }
        }
    }
}
