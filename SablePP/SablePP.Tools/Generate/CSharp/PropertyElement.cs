using System;

namespace SablePP.Tools.Generate.CSharp
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

        protected class GetSetHandle : ComplexElement
        {
            private PatchElement break1, break2, break3;
            private bool hasNewline;

            private PatchElement content;
            private AccessModifierElement access;

            public PatchElement Content
            {
                get { return content; }
            }
            public AccessModifiers Access
            {
                get { return access.Modifiers; }
                set { access.Modifiers = value; }
            }

            public GetSetHandle(string getset)
            {
                break1 = new PatchElement();
                break2 = new PatchElement();
                break3 = new PatchElement();
                hasNewline = false;

                content = new PatchElement();
                content.NewLineEmitted += this.onNewLineEmitted;

                access = new AccessModifierElement(AccessModifiers.None);
                insertElement(access);
                emit(getset, UseSpace.Never, UseSpace.Preferred);
                insertElement(break1);
                emit("{", UseSpace.NotPreferred, UseSpace.Preferred);
                insertElement(break2);
                insertElement(content);
                insertElement(break3);
                emit("}", UseSpace.NotPreferred, UseSpace.NotPreferred);
                emitNewLine();
            }

            private void onNewLineEmitted()
            {
                if (!hasNewline)
                {
                    hasNewline = true;
                    break1.EmitNewLine();
                    break2.EmitNewLine();
                    break2.IncreaseIndentation();
                    break3.DecreaseIndentation();
                }
            }
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

    public interface IProperty
    {
        AccessModifiers Modifiers { get; set; }
        string Name { get; }
        string Type { get; }
    }

    public interface IGetProperty : IProperty
    {
        PatchElement Get { get; }
        AccessModifiers GetModifiers { get; set; }
    }
    public interface ISetProperty : IProperty
    {
        PatchElement Set { get; }
        AccessModifiers SetModifiers { get; set; }
    }
}
