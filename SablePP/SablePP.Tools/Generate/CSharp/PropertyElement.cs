using System;

namespace SablePP.Tools.Generate.CSharp
{
    public abstract class PropertyElement : CSharpElement
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

        private AccessModifierElement modifiers;
        public AccessModifiers Modifiers
        {
            get { return modifiers.Modifiers; }
            set { modifiers.Modifiers = value; }
        }

        protected PropertyElement(AccessModifiers modifiers, string name, string type)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (name == string.Empty)
                throw new ArgumentException("Property must have a name.", "name");

            if (type == null)
                throw new ArgumentNullException("type");
            if (type == string.Empty)
                throw new ArgumentException("Property must have a type.", "type");

            this.modifiers = new AccessModifierElement(modifiers);
            this.name = name.Trim();
            this.type = type.Trim();

            insertElement(this.modifiers);
            emit(type, UseSpace.NotPreferred, UseSpace.Always);
            emit(name, UseSpace.NotPreferred, UseSpace.Never);
        }
    }

    public class GetPropertyElement : PropertyElement, IGetProperty
    {
        private GetSetHandle handle;

        public GetPropertyElement(AccessModifiers modifiers, string name, string type)
            : base(modifiers, name, type)
        {
            emitBlockStart();
            handle = new GetSetHandle("get");
            insertElement(handle);
            emitBlockEnd();
        }

        public PatchElement Get
        {
            get { return handle.Content; }
        }

        public AccessModifiers GetModifiers
        {
            get { return handle.Access; }
            set { handle.Access = value; }
        }
    }

    public class SetPropertyElement : PropertyElement, ISetProperty
    {
        private GetSetHandle handle;

        public SetPropertyElement(AccessModifiers modifiers, string name, string type)
            : base(modifiers, name, type)
        {
            emitBlockStart();
            handle = new GetSetHandle("set");
            insertElement(handle);
            emitBlockEnd();
        }

        public PatchElement Set
        {
            get { return handle.Content; }
        }

        public AccessModifiers SetModifiers
        {
            get { return handle.Access; }
            set { handle.Access = value; }
        }
    }

    public class GetSetPropertyElement : PropertyElement, IGetProperty, ISetProperty
    {
        private GetSetHandle getter, setter;

        public GetSetPropertyElement(AccessModifiers modifiers, string name, string type)
            : base(modifiers, name, type)
        {
            emitBlockStart();
            getter = new GetSetHandle("get");
            setter = new GetSetHandle("set");
            insertElement(getter);
            insertElement(setter);
            emitBlockEnd();
        }

        public PatchElement Get
        {
            get { return getter.Content; }
        }
        public PatchElement Set
        {
            get { return setter.Content; }
        }

        public AccessModifiers GetModifiers
        {
            get { return getter.Access; }
            set { getter.Access = value; }
        }
        public AccessModifiers SetModifiers
        {
            get { return setter.Access; }
            set { setter.Access = value; }
        }
    }
}
