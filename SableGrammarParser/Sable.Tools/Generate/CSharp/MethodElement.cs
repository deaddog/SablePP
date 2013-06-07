﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sable.Tools.Generate.CSharp
{
    public class MethodElement : ExecutableElement
    {
        private string name;
        private string returnType;

        public string Name
        {
            get { return name; }
        }
        public string ReturnType
        {
            get { return returnType; }
        }
        public bool IsConstructor
        {
            get { return returnType == null; }
        }

        private AccessModifiers modifiers;
        public AccessModifiers Modifiers
        {
            get { return modifiers; }
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

        public MethodElement(AccessModifiers modifiers, string name)
            : this(modifiers, name, null)
        {
        }
        public MethodElement(AccessModifiers modifiers, string name, string returnType)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (name == string.Empty)
                throw new ArgumentException("Method must have a name.", "name");

            this.modifiers = modifiers;
            this.name = name.Trim();
            this.returnType = returnType != null ? returnType.Trim() : null;
            if (this.returnType == string.Empty)
                this.returnType = null;

            this.parameters = new ParametersElement();
            this.typeParameters = new TypeParametersElement();

            modifiers.Emit(emit);
            if (this.returnType != null)
                emit(returnType, UseSpace.NotPreferred, UseSpace.Always);
            emit(name, UseSpace.NotPreferred, UseSpace.Never);
            insertElement(typeParameters);
            emit("(", UseSpace.Never, UseSpace.Never);
            insertElement(parameters);
            emit(")", UseSpace.Never, UseSpace.Never);
            emitNewLine();
            emit("{", UseSpace.Never, UseSpace.Never);
            emitNewLine();
            increaseIndentation();
            InsertContents();
            decreaseIndentation();
            emit("}", UseSpace.Never, UseSpace.Never);
            emitNewLine();
        }

        public class ParametersElement : ComplexElement
        {
            private List<Parameter> parameters;

            public ParametersElement()
            {
                this.parameters = new List<Parameter>();
            }

            public Parameter Add(string name, string type)
            {
                Parameter par = new Parameter(name, type);
                parameters.Add(par);
                if (parameters.Count > 1)
                    emit(",", UseSpace.Never, UseSpace.Always);
                emit(type, UseSpace.NotPreferred, UseSpace.Always);
                emit(name, UseSpace.NotPreferred, UseSpace.NotPreferred);
                return par;
            }
            public Parameter this[int index]
            {
                get { return parameters[index]; }
            }
        }

        public class Parameter
        {
            private string name;
            private string type;

            public Parameter(string name, string type)
            {
                this.name = name;
                this.type = type;
            }

            public string Name
            {
                get { return name; }
            }
            public string Type
            {
                get { return type; }
            }
        }
    }
}
