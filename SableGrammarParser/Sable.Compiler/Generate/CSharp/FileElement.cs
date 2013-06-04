namespace Sable.Compiler.Generate.CSharp
{
    public sealed class FileElement : ComplexElement
    {
        private UsingElement usings;
        public UsingElement Using
        {
            get { return usings; }
        }

        public FileElement()
        {
            this.usings = new UsingElement();
            this.insertElement(usings);
        }

        public NameSpaceElement CreateNamespace(string name)
        {
            NameSpaceElement element = new NameSpaceElement(name);
            insertElement(element);
            return element;
        }
    }
}
