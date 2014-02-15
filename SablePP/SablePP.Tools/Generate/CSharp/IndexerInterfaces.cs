namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Exposes properties that represent a C# indexer.
    /// </summary>
    public interface IIndexer
    {
        /// <summary>
        /// Gets or sets the access modifiers of the indexer.
        /// </summary>
        AccessModifiers Modifiers { get; set; }

        /// <summary>
        /// Gets the return type of the indexer.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the indexers collection of parameters.
        /// </summary>
        ParametersElement Parameters { get; }
    }

    /// <summary>
    /// Exposes properties specific to a C# indexer with a getter.
    /// </summary>
    public interface IGetIndexer : IIndexer
    {
        /// <summary>
        /// Gets a <see cref="PatchElement"/> to which the code for indexers getter method should be emitted.
        /// </summary>
        PatchElement Get { get; }

        /// <summary>
        /// Gets or sets the access modifiers specific to the indexers getter method.
        /// </summary>
        AccessModifiers GetModifiers { get; set; }
    }

    /// <summary>
    /// Exposes properties specific to a C# indexer with a setter.
    /// </summary>
    public interface ISetIndexer : IIndexer
    {
        /// <summary>
        /// Gets a <see cref="PatchElement"/> to which the code for indexers setter method should be emitted.
        /// </summary>
        PatchElement Set { get; }

        /// <summary>
        /// Gets or sets the access modifiers specific to the indexers setter method.
        /// </summary>
        AccessModifiers SetModifiers { get; set; }
    }

    /// <summary>
    /// Exposes properties specific to a C# indexer with both a getter and a setter.
    /// </summary>
    public interface IGetSetIndexer : IGetIndexer, ISetIndexer
    {
    }
}
