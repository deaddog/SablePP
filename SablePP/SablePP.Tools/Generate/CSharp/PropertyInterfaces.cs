namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Exposes properties that represent a C# property.
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the access modifiers of the property.
        /// </summary>
        AccessModifiers Modifiers { get; set; }

        /// <summary>
        /// Gets the return type of the property.
        /// </summary>
        string Type { get; }
    }

    /// <summary>
    /// Exposes properties specific to a C# property with a getter.
    /// </summary>
    public interface IGetProperty : IProperty
    {
        /// <summary>
        /// Gets a <see cref="PatchElement"/> to which the code for properties getter method should be emitted.
        /// </summary>
        PatchElement Get { get; }

        /// <summary>
        /// Gets or sets the access modifiers specific to the properties getter method.
        /// </summary>
        AccessModifiers GetModifiers { get; set; }
    }

    /// <summary>
    /// Exposes properties specific to a C# property with a setter.
    /// </summary>
    public interface ISetProperty : IProperty
    {
        /// <summary>
        /// Gets a <see cref="PatchElement"/> to which the code for properties setter method should be emitted.
        /// </summary>
        PatchElement Set { get; }

        /// <summary>
        /// Gets or sets the access modifiers specific to the properties setter method.
        /// </summary>
        AccessModifiers SetModifiers { get; set; }
    }

    /// <summary>
    /// Exposes properties specific to a C# property with both a getter and a setter.
    /// </summary>
    public interface IGetSetProperty : IGetProperty, ISetProperty
    {
    }
}
