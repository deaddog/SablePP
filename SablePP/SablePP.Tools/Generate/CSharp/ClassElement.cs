using System;
using System.Collections.Generic;

namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Represents a C# class and exposes methods for emitting fields, methods, properties etc. within the class.
    /// </summary>
    public class ClassElement : ComplexElement
    {
        private string name;
        /// <summary>
        /// Gets the name of the class.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        private AccessModifiers modifiers;
        /// <summary>
        /// Gets the access modifiers associated with the class.
        /// </summary>
        public AccessModifiers Modifiers
        {
            get { return modifiers; }
        }

        private TypeParametersElement typeParameters;
        /// <summary>
        /// Gets the collection of type parameters for the class.
        /// </summary>
        public TypeParametersElement TypeParameters
        {
            get { return typeParameters; }
        }

        private string implements;
        /// <summary>
        /// Gets a string describing the types this class inherits.
        /// </summary>
        public string Implements
        {
            get { return implements; }
        }

        private PatchElement contents;

        public ClassElement(string signature)
        {
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

        public void EmitField(string name, string type, AccessModifiers modifiers, out PatchElement valueElement)
        {
            valueElement = new PatchElement();

            modifiers.Emit(contents.Emit);
            contents.Emit(type, UseSpace.NotPreferred, UseSpace.Preferred);
            contents.Emit(name, UseSpace.NotPreferred, UseSpace.Preferred);
            contents.Emit("=", UseSpace.Always, UseSpace.Always);
            contents.InsertElement(valueElement);
            contents.Emit(";", UseSpace.Never, UseSpace.Never);
            contents.EmitNewLine();
        }

        public void Add(MethodElement method)
        {
            throw new NotImplementedException();
        }
        public void Add(PropertyElement property)
        {
            throw new NotImplementedException();
        }
        public void Add(IndexerElement indexer)
        {
            throw new NotImplementedException();
        }
    }
}
