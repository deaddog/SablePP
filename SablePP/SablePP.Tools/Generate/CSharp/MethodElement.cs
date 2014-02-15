using System;
using System.Collections.Generic;

namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Represents an object for handling code-generation of a C# method.
    /// </summary>
    public class MethodElement : CSharpElement
    {
        private string name;
        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        private AccessModifierElement modifiers;
        /// <summary>
        /// Gets or sets the access modifiers associated with the method.
        /// </summary>
        public AccessModifiers Modifiers
        {
            get { return modifiers.Modifiers; }
            set { modifiers.Modifiers = value; }
        }

        private ParametersElement parameters;
        /// <summary>
        /// Gets the methods collection of parameters.
        /// </summary>
        public ParametersElement Parameters
        {
            get { return parameters; }
        }

        private TypeParametersElement typeParameters;
        /// <summary>
        /// Gets the methods collection of type parameters.
        /// </summary>
        public TypeParametersElement TypeParameters
        {
            get { return typeParameters; }
        }

        private PatchElement body;
        /// <summary>
        /// Gets a <see cref="PatchElement"/> that represents the body of the method. Executed code should be emitted to this element.
        /// Note that this can have value <c>null</c> if the method has no body (such as an abstract method).
        /// </summary>
        public PatchElement Body
        {
            get { return body; }
        }

        /// <summary>
        /// Gets a value indicating whether the method has a body.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the method has a body; otherwise, <c>false</c>.
        /// </value>
        public bool HasBody
        {
            get { return body != null; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodElement"/> class from its signature.
        /// </summary>
        /// <param name="signature">The signature of the method.</param>
        /// <param name="hasBody">if set to <c>true</c> the method will have a body element to which code can be written.</param>
        public MethodElement(string signature, bool hasBody = true)
            : this(signature, null, hasBody)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodElement"/> class from its signature.
        /// </summary>
        /// <param name="signature">The signature of the method.</param>
        /// <param name="chaincall">A <see cref="String"/> that specifies a chain call to a baseclass (for constructors). Specify <c>null</c> for no chaining.</param>
        /// <param name="hasBody">if set to <c>true</c> the method will have a body element to which code can be written.</param>
        public MethodElement(string signature, string chaincall, bool hasBody)
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
            name = signature.Substring(0, parIndex).TrimEnd();

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

            // Parse the name
            emit(name);
            insertElement(typeParameters);
            if (name.Contains(" "))
                name = name.Substring(name.LastIndexOf(' ') + 1);
            signature = signature.Substring(parIndex + 1);

            // Parse the parameters
            int parEnd = signature.IndexOf(')');
            this.parameters = ParametersElement.Parse(signature.Substring(0, parEnd));
            emit("(");
            insertElement(parameters);
            emit(")");
            signature = signature.Substring(parEnd + 1);

            emitLine(signature);

            if (chaincall != null && (chaincall = chaincall.Trim(' ', '\t', ':')).Length > 0)
            {
                increaseIndentation();
                emitLine(": " + chaincall);
                decreaseIndentation();
            }

            if (hasBody)
            {
                this.body = new PatchElement();
                emitLine("{");
                increaseIndentation();
                insertElement(body);
                decreaseIndentation();
                emitLine("}");
            }
            else
                this.body = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodElement"/> class from its signature.
        /// </summary>
        /// <param name="signature">The signature of the method.</param>
        /// <param name="hasBody">if set to <c>true</c> the method will have a body element to which code can be written.</param>
        /// <param name="args">A collection of arguments that are inserted into <paramref name="signature"/> using <see cref="String.Format(String, Object[])"/>.</param>
        public MethodElement(string signature, bool hasBody, params object[] args)
            : this(signature, null, hasBody, args)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodElement"/> class from its signature.
        /// </summary>
        /// <param name="signature">The signature of the method.</param>
        /// <param name="chaincall">A <see cref="String"/> that specifies a chain call to a baseclass (for constructors). Specify <c>null</c> for no chaining.</param>
        /// <param name="hasBody">if set to <c>true</c> the method will have a body element to which code can be written.</param>
        /// <param name="args">A collection of arguments that are inserted into <paramref name="signature"/> using <see cref="String.Format(String, Object[])"/>.</param>
        public MethodElement(string signature, string chaincall, bool hasBody, params object[] args)
            : this(string.Format(signature, args), chaincall, hasBody)
        {
        }
    }
}
