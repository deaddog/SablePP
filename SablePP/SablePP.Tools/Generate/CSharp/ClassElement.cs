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

        private string classType;
        /// <summary>
        /// Gets the 'class-type' of this element. That is; either 'class', 'struct' or 'interface'.
        /// </summary>
        public string ClassType
        {
            get { return classType; }
        }

        private AccessModifierElement modifiers;
        /// <summary>
        /// Gets or sets the access modifiers associated with the class.
        /// </summary>
        public AccessModifiers Modifiers
        {
            get { return modifiers.Modifiers; }
            set { modifiers.Modifiers = value; }
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
            if (signature == null)
                throw new ArgumentNullException("signature");
            signature = signature.Trim();
            int start, length;

            // Parse the modifiers
            this.modifiers = AccessModifierElement.Parse(signature, out start, out length);
            emit(signature.Substring(0, start));
            insertElement(modifiers);
            signature = signature.Substring(start + length).TrimStart();

            // Read class-type
            this.classType = signature.Substring(0, signature.IndexOf(' '));
            signature = signature.Substring(classType.Length).TrimStart();
            emit("{0} ", classType);

            // Find the colon
            int colonIndex = signature.IndexOf(':');
            this.name = colonIndex >= 0 ? signature.Substring(0, colonIndex).TrimEnd() : signature;
            signature = colonIndex >= 0 ? signature.Substring(colonIndex + 1).TrimStart() : string.Empty;

            // Find the type parameters
            if (name.EndsWith(">"))
            {
                int typesStart = name.LastIndexOf('<');
                string types = name.Substring(typesStart + 1, name.Length - typesStart - 2);
                typeParameters = TypeParametersElement.Parse(types);
                name = name.Substring(0, typesStart).TrimEnd();
            }
            else
                typeParameters = TypeParametersElement.Parse(string.Empty);

            // Emit the remainder
            emit(name);
            insertElement(typeParameters);
            if (colonIndex >= 0)
                emit(" : {0}", signature);
        }

        public void EmitNewLine()
        {
            contents.EmitNewLine();
        }

        public void EmitField(string declaration)
        {
            contents.EmitLine("{0};", declaration.Trim());
        }

        public void EmitField(string declaration, string value)
        {
            contents.EmitLine("{0} = {1};", declaration.Trim(), value.Trim());
        }

        public void EmitField(string declaration, out PatchElement valueElement)
        {
            valueElement = new PatchElement();
            contents.Emit("{0} ", declaration.Trim());
            contents.InsertElement(valueElement);
            contents.EmitLine(";");
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
