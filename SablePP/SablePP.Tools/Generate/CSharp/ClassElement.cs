using System;
using System.Collections.Generic;

namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Represents a C# class and exposes methods for emitting fields, methods, properties etc. within the class.
    /// </summary>
    public class ClassElement : CSharpElement<PatchElement>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassElement"/> class from its signature.
        /// </summary>
        /// <param name="signature">The signature for the class.</param>
        public ClassElement(string signature)
            : base(new PatchElement())
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

            emitNewLine();
            emitLine("{");
            increaseIndentation();
            insertElement(content);
            decreaseIndentation();
            emitLine("}");
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassElement"/> class from its signature.
        /// </summary>
        /// <param name="signature">The signature for the class.</param>
        /// <param name="args">A collection of arguments that are inserted into <paramref name="signature"/>.</param>
        public ClassElement(string signature, params object[] args)
            : this(string.Format(signature, args))
        {
        }

        /// <summary>
        /// Emits a newline to the <see cref="ClassElement"/>. This can be used to separate class members.
        /// </summary>
        public void EmitNewline()
        {
            content.EmitNewLine();
        }

        /// <summary>
        /// Emits a field (uninitialized) to the <see cref="ClassElement"/>.
        /// </summary>
        /// <param name="declaration">The field declaration that should be emitted.</param>
        public void EmitField(string declaration)
        {
            content.EmitLine("{0};", declaration.Trim());
        }

        /// <summary>
        /// Emits a field, initialized to a value, to the <see cref="ClassElement"/>.
        /// </summary>
        /// <param name="declaration">The field declaration that should be emitted.</param>
        /// <param name="value">The value that should be assigned to the field.</param>
        public void EmitField(string declaration, string value)
        {
            content.EmitLine("{0} = {1};", declaration.Trim(), value.Trim());
        }

        /// <summary>
        /// Emits a field to the <see cref="ClassElement"/>. The initial value is determined by emitting code to a <see cref="PatchElement"/>.
        /// </summary>
        /// <param name="declaration">The field declaration that should be emitted.</param>
        /// <param name="valueElement">When the method returns, a <see cref="PatchElement"/> to which the initial value of the field should be emitted.</param>
        public void EmitField(string declaration, out PatchElement valueElement)
        {
            valueElement = new PatchElement();
            content.Emit("{0} = ", declaration.Trim());
            content.InsertElement(valueElement);
            content.EmitLine(";");
        }

        /// <summary>
        /// Emits a field to the <see cref="ClassElement"/>. The initial value is determined by the code emitted to a <see cref="PatchElement"/>.
        /// </summary>
        /// <param name="declaration">The field declaration that should be emitted.</param>
        /// <param name="valueElement">The <see cref="PatchElement"/> to which the initial value of the field should be emitted.</param>
        public void EmitField(string declaration, PatchElement valueElement)
        {
            content.Emit("{0} = ", declaration.Trim());
            content.InsertElement(valueElement);
            content.EmitLine(";");
        }

        /// <summary>
        /// Adds a <see cref="MethodElement"/> to the <see cref="ClassElement"/>.
        /// </summary>
        /// <param name="method">The <see cref="MethodElement"/> that is added to the <see cref="ClassElement"/>.</param>
        public void Add(MethodElement method)
        {
            content.InsertElement(method);
        }
        /// <summary>
        /// Adds a <see cref="PropertyElement"/> to the <see cref="ClassElement"/>.
        /// </summary>
        /// <param name="property">The <see cref="PropertyElement"/> that is added to the <see cref="ClassElement"/>.</param>
        public void Add(PropertyElement property)
        {
            content.InsertElement(property);
        }
        /// <summary>
        /// Adds a <see cref="IndexerElement"/> to the <see cref="ClassElement"/>.
        /// </summary>
        /// <param name="indexer">The <see cref="IndexerElement"/> that is added to the <see cref="ClassElement"/>.</param>
        public void Add(IndexerElement indexer)
        {
            content.InsertElement(indexer);
        }
    }
}
