namespace Sable.Compiler.Generate.CSharp
{
    public sealed class NameSpaceElement : ComplexElement
    {
        private string name;
        public string Name
        {
            get { return name; }
        }

        private UsingElement usings;
        public UsingElement Using
        {
            get { return usings; }
        }

        private PatchElement classes;

        public NameSpaceElement(string name)
        {
            this.name = name;
            this.usings = new UsingElement();
            this.classes = new PatchElement();

            emit("namespace {0}", UseSpace.Never, UseSpace.Never, name);
            emitNewLine();
            emit("{", UseSpace.Never, UseSpace.Never);
            emitNewLine();
            increaseIndentation();
            insertElement(usings);
            insertElement(classes);
            decreaseIndentation();
            emit("}", UseSpace.Never, UseSpace.Never);
            emitNewLine();
        }

        public ClassElement CreateClass(string name, AccessModifiers modifiers)
        {
            ClassElement element = new ClassElement(name, modifiers);
            classes.InsertElement(element);
            return element;
        }
    }
}
