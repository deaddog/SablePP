namespace Sable.Tools.Generate.CSharp
{
    public sealed class FileElement : CSharpElement
    {
        private UsingsElement usings;
        public UsingsElement Using
        {
            get { return usings; }
        }

        public FileElement()
        {
            this.usings = new UsingsElement();
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
