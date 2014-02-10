namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Represents a C# file and exposes methods for emitting namespaces and using statements.
    /// </summary>
    public sealed class FileElement : CSharpElement
    {
        private UsingsElement usings;
        /// <summary>
        /// Gets a <see cref="UsingElement"/> describing the using statements included in this <see cref="FileElement"/>.
        /// </summary>
        public UsingsElement Using
        {
            get { return usings; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileElement"/> class.
        /// </summary>
        public FileElement()
        {
            this.usings = new UsingsElement();
            this.insertElement(usings);
        }

        /// <summary>
        /// Creates the a new <see cref="NameSpaceElement"/> and inserts it into this <see cref="FileElement"/>.
        /// </summary>
        /// <param name="name">The name of the namespace that is created.</param>
        /// <returns>A new <see cref="NameSpaceElement"/>.</returns>
        public NameSpaceElement CreateNamespace(string name)
        {
            NameSpaceElement element = new NameSpaceElement(name);
            insertElement(element);
            return element;
        }
    }
}
