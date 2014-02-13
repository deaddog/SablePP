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

        public ClassElement(string name, AccessModifiers modifiers, string implements)
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
            emit("class", UseSpace.Always, UseSpace.Always);
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

        public void EmitField(string name, string type, AccessModifiers modifiers, out InlineElement valueElement)
        {
            valueElement = new InlineElement();

            modifiers.Emit(contents.Emit);
            contents.Emit(type, UseSpace.NotPreferred, UseSpace.Preferred);
            contents.Emit(name, UseSpace.NotPreferred, UseSpace.Preferred);
            contents.Emit("=", UseSpace.Always, UseSpace.Always);
            contents.InsertElement(valueElement);
            contents.Emit(";", UseSpace.Never, UseSpace.Never);
            contents.EmitNewLine();
        }

        public MethodElement CreateMethod(AccessModifiers modifiers, string name, string returnType)
        {
            MethodElement method = new MethodElement(modifiers, name, returnType);
            contents.InsertElement(method);
            return method;
        }
        public PartialMethodElement CreatePartialMethod(string name, string returnType)
        {
            PartialMethodElement method = new PartialMethodElement(name, returnType);
            contents.InsertElement(method);
            return method;
        }
        public MethodElement CreateConstructor(AccessModifiers modifiers, bool? baseChain = null)
        {
            MethodElement method = new MethodElement(modifiers, this.name, baseChain);
            contents.InsertElement(method);
            return method;
        }

        public GetSetPropertyElement CreateProperty(AccessModifiers modifiers, string name, string type)
        {
            GetSetPropertyElement element = new GetSetPropertyElement(modifiers, name, type);
            contents.InsertElement(element);
            return element;
        }
        public SetPropertyElement CreateSetProperty(AccessModifiers modifiers, string name, string type)
        {
            SetPropertyElement element = new SetPropertyElement(modifiers, name, type);
            contents.InsertElement(element);
            return element;
        }
        public GetPropertyElement CreateGetProperty(AccessModifiers modifiers, string name, string type)
        {
            GetPropertyElement element = new GetPropertyElement(modifiers, name, type);
            contents.InsertElement(element);
            return element;
        }

        public GetSetIndexerElement CreateIndexer(AccessModifiers modifiers, string type, string arg1name, string arg1type)
        {
            GetSetIndexerElement element = new GetSetIndexerElement(modifiers, type);
            element.Parameters.Add(arg1name, arg1type);
            contents.InsertElement(element);
            return element;
        }
        public SetIndexerElement CreateSetIndexer(AccessModifiers modifiers, string type, string arg1name, string arg1type)
        {
            SetIndexerElement element = new SetIndexerElement(modifiers, type);
            element.Parameters.Add(arg1name, arg1type);
            contents.InsertElement(element);
            return element;
        }
        public GetIndexerElement CreateGetIndexer(AccessModifiers modifiers, string type, string arg1name, string arg1type)
        {
            GetIndexerElement element = new GetIndexerElement(modifiers, type);
            element.Parameters.Add(arg1name, arg1type);
            contents.InsertElement(element);
            return element;
        }
    }
}
