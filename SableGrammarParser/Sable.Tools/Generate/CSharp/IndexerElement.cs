using System;
using System.Collections.Generic;

namespace Sable.Tools.Generate.CSharp
{
    public class IndexerElement : CSharpElement
    {
        private string type;

        public string Type
        {
            get { return type; }
        }

        private AccessModifiers modifiers;
        public AccessModifiers Modifiers
        {
            get { return modifiers; }
        }

        private MethodElement.ParametersElement parameters;
        public MethodElement.ParametersElement Parameters
        {
            get { return parameters; }
        }

        private PropertyElement.PropertyGetter getter;
        public PropertyElement.PropertyGetter Get
        {
            get { return getter; }
        }
        private PropertyElement.PropertySetter setter;
        public PropertyElement.PropertySetter Set
        {
            get { return setter; }
        }

        public IndexerElement(AccessModifiers modifiers, string type, bool hasGetter, bool hasSetter)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (type == string.Empty)
                throw new ArgumentException("Property must have a type.", "type");

            this.modifiers = modifiers;
            this.type = type.Trim();

            this.parameters = new MethodElement.ParametersElement();

            if (hasGetter)
                this.getter = new PropertyElement.PropertyGetter();
            if (hasSetter)
                this.setter = new PropertyElement.PropertySetter();

            modifiers.Emit(emit);
            emit(type, UseSpace.NotPreferred, UseSpace.Always);
            emit("this[", UseSpace.Always, UseSpace.Never);
            insertElement(parameters);
            emit("]", UseSpace.Never, UseSpace.NotPreferred);

            emitBlockStart();

            if (hasGetter) 
                insertElement(getter);
            if (hasSetter)
                insertElement(setter);

            emitBlockEnd();
        }
    }
}
