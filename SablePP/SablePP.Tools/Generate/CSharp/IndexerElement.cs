using System;
using System.Collections.Generic;

namespace SablePP.Tools.Generate.CSharp
{
    public abstract class IndexerElement : CSharpElement
    {
        private string type;
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
        
        private ParametersElement parameters;
        public ParametersElement Parameters
        {
            get { return parameters; }
        }

        protected IndexerElement(AccessModifiers modifiers, string type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (type == string.Empty)
                throw new ArgumentException("Property must have a type.", "type");

            this.modifiers = new AccessModifierElement(modifiers);
            this.type = type.Trim();

            this.parameters = new ParametersElement();

            insertElement(this.modifiers);
            emit(type, UseSpace.NotPreferred, UseSpace.Always);
            emit("this[", UseSpace.Always, UseSpace.Never);
            insertElement(parameters);
            emit("]", UseSpace.Never, UseSpace.NotPreferred);
        }
    }

    public class GetIndexerElement : IndexerElement, IGetIndexer
    {
        private GetSetHandle handle;

        public GetIndexerElement(AccessModifiers modifiers, string type)
            : base(modifiers, type)
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

    public class SetIndexerElement : IndexerElement, ISetIndexer
    {
        private GetSetHandle handle;

        public SetIndexerElement(AccessModifiers modifiers, string type)
            : base(modifiers, type)
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

    public class GetSetIndexerElement : IndexerElement, IGetIndexer, ISetIndexer
    {
        private GetSetHandle getter, setter;

        public GetSetIndexerElement(AccessModifiers modifiers, string type)
            : base(modifiers, type)
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
