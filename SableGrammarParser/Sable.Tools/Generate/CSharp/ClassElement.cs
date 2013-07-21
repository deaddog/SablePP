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

        public MethodElement CreateMethod(AccessModifiers modifiers, string name, string returnType)
        {
            MethodElement method = new MethodElement(modifiers, name, returnType);
            contents.InsertElement(method);
            return method;
        }
        public MethodElement CreateConstructor(AccessModifiers modifiers, bool? baseChain = null)
        {
            MethodElement method = new MethodElement(modifiers, this.name, baseChain);
            contents.InsertElement(method);
            return method;
        }

        public PropertyElement CreateProperty(AccessModifiers modifiers, string name, string type)
        {
            return _createProperty(modifiers, name, type, true, true);
        }
        public PropertyElement CreateSetProperty(AccessModifiers modifiers, string name, string type)
        {
            return _createProperty(modifiers, name, type, false, true);
        }
        public PropertyElement CreateGetProperty(AccessModifiers modifiers, string name, string type)
        {
            return _createProperty(modifiers, name, type, true, false);
        }
        private PropertyElement _createProperty(AccessModifiers modifiers, string name, string type, bool hasGetter, bool hasSetter)
        {
            PropertyElement element = new PropertyElement(modifiers, name, type, hasGetter, hasSetter);
            contents.InsertElement(element);
            return element;
        }

        public IndexerElement CreateIndexer(AccessModifiers modifiers, string type, string arg1name, string arg1type)
        {
            return _createIndexer(modifiers, type, arg1name, arg1type, true, true);
        }
        public IndexerElement CreateSetIndexer(AccessModifiers modifiers, string type, string arg1name, string arg1type)
        {
            return _createIndexer(modifiers, type, arg1name, arg1type, false, true);
        }
        public IndexerElement CreateGetIndexer(AccessModifiers modifiers, string type, string arg1name, string arg1type)
        {
            return _createIndexer(modifiers, type, arg1name, arg1type, true, false);
        }
        private IndexerElement _createIndexer(AccessModifiers modifiers, string type, string arg1name, string arg1type, bool hasGetter, bool hasSetter)
        {
            IndexerElement element = new IndexerElement(modifiers, type, hasGetter, hasSetter);
            element.Parameters.Add(arg1name, arg1type);
            contents.InsertElement(element);
            return element;
        }
    }
}
