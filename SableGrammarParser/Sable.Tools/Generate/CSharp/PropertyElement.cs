using System;

namespace Sable.Tools.Generate.CSharp
{
    public class PropertyElement : CSharpElement
    {
        private string name;
        private string type;

        public string Name
        {
            get { return name; }
        }
        public string Type
        {
            get { return type; }
        }

        private AccessModifiers modifiers;
        public AccessModifiers Modifiers
        {
            get { return modifiers; }
        }

        private PropertyGetter getter;
        public PropertyGetter Get
        {
            get { return getter; }
        }
        private PropertySetter setter;
        public PropertySetter Set
        {
            get { return setter; }
        }

        public PropertyElement(AccessModifiers modifiers, string name, string type, bool hasGetter, bool hasSetter)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (name == string.Empty)
                throw new ArgumentException("Property must have a name.", "name");

            if (type == null)
                throw new ArgumentNullException("type");
            if (type == string.Empty)
                throw new ArgumentException("Property must have a type.", "type");

            this.modifiers = modifiers;
            this.name = name.Trim();
            this.type = type.Trim();

            if (hasGetter)
                this.getter = new PropertyGetter();
            if (hasSetter)
                this.setter = new PropertySetter();

            modifiers.Emit(emit);
            emit(type, UseSpace.NotPreferred, UseSpace.Always);
            emit(name, UseSpace.NotPreferred, UseSpace.Never);

            emitBlockStart();

            if (hasGetter) 
                insertElement(getter);
            if (hasSetter)
                insertElement(setter);

            emitBlockEnd();
        }

        public class PropertyGetter : ExecutableElement
        {
            public PropertyGetter()
            {
                emit("get", UseSpace.Never, UseSpace.NotPreferred);
                emitBlockStart();
                InsertContents();
                emitBlockEnd();
            }
        }

        public class PropertySetter : ExecutableElement
        {
            public PropertySetter()
            {
                emit("set", UseSpace.Never, UseSpace.NotPreferred);
                emitBlockStart();
                InsertContents();
                emitBlockEnd();
            }

            public void EmitValueIdentifier()
            {
                EmitIdentifier("value");
            }
        }
    }
}
