namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Represent an object for handling code-generation of a C# namespace.
    /// </summary>
    public sealed class NameSpaceElement : CSharpElement
    {
        private string name;
        /// <summary>
        /// Gets the full name of the namespace.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        private UsingsElement usings;
        /// <summary>
        /// Gets a <see cref="UsingsElement"/> describing the using statements included in this <see cref="NameSpaceElement"/>.
        /// </summary>
        public UsingsElement Using
        {
            get { return usings; }
        }

        private bool hasClasses;
        private PatchElement classes;
        /// <summary>
        /// Gets a value indicating whether the namespace contains any <see cref="ClassElement"/>s.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="NameSpaceElement"/> contains any <see cref="ClassElement"/>s; otherwise, <c>false</c>.
        /// </value>
        public bool HasClasses
        {
            get { return hasClasses; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameSpaceElement"/> class.
        /// </summary>
        /// <param name="name">The name of the namespace.</param>
        public NameSpaceElement(string name)
        {
            this.name = name;
            this.usings = new UsingsElement();
            this.classes = new PatchElement();
            this.hasClasses = false;

            emitLine("namespace {0}", name);
            emitLine("{");
            increaseIndentation();
            insertElement(usings);
            insertElement(classes);
            decreaseIndentation();
            emitLine("}");
        }

        /// <summary>
        /// Adds a <see cref="ClassElement"/> to the <see cref="NameSpaceElement"/>.
        /// </summary>
        /// <param name="class">The class that is added to this <see cref="NameSpaceElement"/>.</param>
        public void Add(ClassElement @class)
        {
            classes.InsertElement(@class);
            hasClasses = true;
        }

        /// <summary>
        /// Emits a newline to the namespace.
        /// </summary>
        public void EmitNewLine()
        {
            classes.EmitNewLine();
        }
    }
}
