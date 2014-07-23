using System;

namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Represents an object for handling code-generation of a C# property.
    /// </summary>
    public abstract class PropertyElement : ComplexElement, IProperty
    {
        private string name;
        private string type;

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string Name
        {
            get { return name; }
        }
        /// <summary>
        /// Gets the return type of the property.
        /// </summary>
        public string Type
        {
            get { return type; }
        }

        private AccessModifierElement modifiers;
        /// <summary>
        /// Gets or sets the access modifiers of the property.
        /// </summary>
        public AccessModifiers Modifiers
        {
            get { return modifiers.Modifiers; }
            set { modifiers.Modifiers = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyElement"/> class.
        /// </summary>
        /// <param name="modifiers">The access modifiers of the property.</param>
        /// <param name="name">The name of the property.</param>
        /// <param name="type">The return type of the property.</param>
        internal PropertyElement(AccessModifiers modifiers, string name, string type)
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
    
    /// <summary>
    /// Represents an object for handling code-generation of a C# property with a getter.
    /// </summary>
    public class GetPropertyElement : PropertyElement, IGetProperty
    {
        private GetSetHandle handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPropertyElement"/> class.
        /// </summary>
        /// <param name="modifiers">The access modifiers of the property.</param>
        /// <param name="name">The name of the property.</param>
        /// <param name="type">The return type of the property.</param>
        public GetPropertyElement(AccessModifiers modifiers, string name, string type)
            : base(modifiers, name, type)
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
        /// Gets a <see cref="PatchElement" /> to which the code for properties getter method should be emitted.
        /// </summary>
        public PatchElement Get
        {
            get { return handle.Content; }
        }

        /// <summary>
        /// Gets or sets the access modifiers specific to the properties getter method.
        /// </summary>
        public AccessModifiers GetModifiers
        {
            get { return handle.Access; }
            set { handle.Access = value; }
        }
    }

    /// <summary>
    /// Represents an object for handling code-generation of a C# property with a setter.
    /// </summary>
    public class SetPropertyElement : PropertyElement, ISetProperty
    {
        private GetSetHandle handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetPropertyElement"/> class.
        /// </summary>
        /// <param name="modifiers">The access modifiers of the property.</param>
        /// <param name="name">The name of the property.</param>
        /// <param name="type">The return type of the property.</param>
        public SetPropertyElement(AccessModifiers modifiers, string name, string type)
            : base(modifiers, name, type)
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
        /// Gets a <see cref="PatchElement" /> to which the code for properties setter method should be emitted.
        /// </summary>
        public PatchElement Set
        {
            get { return handle.Content; }
        }

        /// <summary>
        /// Gets or sets the access modifiers specific to the properties setter method.
        /// </summary>
        public AccessModifiers SetModifiers
        {
            get { return handle.Access; }
            set { handle.Access = value; }
        }
    }

    /// <summary>
    /// Represents an object for handling code-generation of a C# property with a getter and a setter.
    /// </summary>
    public class GetSetPropertyElement : PropertyElement, IGetProperty, ISetProperty
    {
        private GetSetHandle getter, setter;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSetPropertyElement"/> class.
        /// </summary>
        /// <param name="modifiers">The access modifiers of the property.</param>
        /// <param name="name">The name of the property.</param>
        /// <param name="type">The return type of the property.</param>
        public GetSetPropertyElement(AccessModifiers modifiers, string name, string type)
            : base(modifiers, name, type)
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
        /// Gets a <see cref="PatchElement" /> to which the code for properties getter method should be emitted.
        /// </summary>
        public PatchElement Get
        {
            get { return getter.Content; }
        }
        /// <summary>
        /// Gets a <see cref="PatchElement" /> to which the code for properties setter method should be emitted.
        /// </summary>
        public PatchElement Set
        {
            get { return setter.Content; }
        }

        /// <summary>
        /// Gets or sets the access modifiers specific to the properties getter method.
        /// </summary>
        public AccessModifiers GetModifiers
        {
            get { return getter.Access; }
            set { getter.Access = value; }
        }
        /// <summary>
        /// Gets or sets the access modifiers specific to the properties setter method.
        /// </summary>
        public AccessModifiers SetModifiers
        {
            get { return setter.Access; }
            set { setter.Access = value; }
        }
    }
}
