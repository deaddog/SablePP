using System;
using System.Collections.Generic;

namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Represents an object for handling code-generation of a C# indexer.
    /// </summary>
    public abstract class IndexerElement : ComplexElement, IIndexer
    {
        private string type;
        /// <summary>
        /// Gets the return type of the indexer.
        /// </summary>
        public string Type
        {
            get { return type; }
        }

        private AccessModifierElement modifiers;
        /// <summary>
        /// Gets or sets the access modifiers of the indexer.
        /// </summary>
        public AccessModifiers Modifiers
        {
            get { return modifiers.Modifiers; }
            set { modifiers.Modifiers = value; }
        }
        
        private ParametersElement parameters;
        /// <summary>
        /// Gets the indexers collection of parameters.
        /// </summary>
        public ParametersElement Parameters
        {
            get { return parameters; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexerElement"/> class.
        /// </summary>
        /// <param name="modifiers">The access modifiers of the indexer.</param>
        /// <param name="type">The return type of the indexer.</param>
        internal IndexerElement(AccessModifiers modifiers, string type)
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

    /// <summary>
    /// Represents an object for handling code-generation of a C# indexer with a getter.
    /// </summary>
    public class GetIndexerElement : IndexerElement, IGetIndexer
    {
        private GetSetHandle handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetIndexerElement"/> class.
        /// </summary>
        /// <param name="modifiers">The access modifiers of the indexer.</param>
        /// <param name="type">The return type of the indexer.</param>
        public GetIndexerElement(AccessModifiers modifiers, string type)
            : base(modifiers, type)
        {
            handle = new GetSetHandle("get");

            emitNewLine();
            emitLine("{");
            increaseIndentation();
            insertElement(handle);
            decreaseIndentation();
            emitLine("}");
        }

        /// <summary>
        /// Gets a <see cref="PatchElement" /> to which the code for indexers getter method should be emitted.
        /// </summary>
        public PatchElement Get
        {
            get { return handle.Content; }
        }

        /// <summary>
        /// Gets or sets the access modifiers specific to the indexers getter method.
        /// </summary>
        public AccessModifiers GetModifiers
        {
            get { return handle.Access; }
            set { handle.Access = value; }
        }
    }

    /// <summary>
    /// Represents an object for handling code-generation of a C# indexer with a setter.
    /// </summary>
    public class SetIndexerElement : IndexerElement, ISetIndexer
    {
        private GetSetHandle handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetIndexerElement"/> class.
        /// </summary>
        /// <param name="modifiers">The access modifiers of the indexer.</param>
        /// <param name="type">The return type of the indexer.</param>
        public SetIndexerElement(AccessModifiers modifiers, string type)
            : base(modifiers, type)
        {
            handle = new GetSetHandle("set");

            emitNewLine();
            emitLine("{");
            increaseIndentation();
            insertElement(handle);
            decreaseIndentation();
            emitLine("}");
        }

        /// <summary>
        /// Gets a <see cref="PatchElement" /> to which the code for indexers setter method should be emitted.
        /// </summary>
        public PatchElement Set
        {
            get { return handle.Content; }
        }

        /// <summary>
        /// Gets or sets the access modifiers specific to the indexers setter method.
        /// </summary>
        public AccessModifiers SetModifiers
        {
            get { return handle.Access; }
            set { handle.Access = value; }
        }
    }

    /// <summary>
    /// Represents an object for handling code-generation of a C# indexer with both a getter and a setter.
    /// </summary>
    public class GetSetIndexerElement : IndexerElement, IGetIndexer, ISetIndexer
    {
        private GetSetHandle getter, setter;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSetIndexerElement"/> class.
        /// </summary>
        /// <param name="modifiers">The access modifiers of the indexer.</param>
        /// <param name="type">The return type of the indexer.</param>
        public GetSetIndexerElement(AccessModifiers modifiers, string type)
            : base(modifiers, type)
        {
            getter = new GetSetHandle("get");
            setter = new GetSetHandle("set");

            emitNewLine();
            emitLine("{");
            increaseIndentation();
            insertElement(getter);
            insertElement(setter);
            decreaseIndentation();
            emitLine("}");
        }

        /// <summary>
        /// Gets a <see cref="PatchElement" /> to which the code for indexers getter method should be emitted.
        /// </summary>
        public PatchElement Get
        {
            get { return getter.Content; }
        }
        /// <summary>
        /// Gets a <see cref="PatchElement" /> to which the code for indexers setter method should be emitted.
        /// </summary>
        public PatchElement Set
        {
            get { return setter.Content; }
        }

        /// <summary>
        /// Gets or sets the access modifiers specific to the indexers getter method.
        /// </summary>
        public AccessModifiers GetModifiers
        {
            get { return getter.Access; }
            set { getter.Access = value; }
        }
        /// <summary>
        /// Gets or sets the access modifiers specific to the indexers setter method.
        /// </summary>
        public AccessModifiers SetModifiers
        {
            get { return setter.Access; }
            set { setter.Access = value; }
        }
    }
}
