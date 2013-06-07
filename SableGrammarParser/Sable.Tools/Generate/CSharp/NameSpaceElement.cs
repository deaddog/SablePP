namespace Sable.Tools.Generate.CSharp
{
    public sealed class NameSpaceElement : CSharpElement
    {
        private string name;
        public string Name
        {
            get { return name; }
        }

        private UsingsElement usings;
        public UsingsElement Using
        {
            get { return usings; }
        }

        private bool hasClasses;
        private PatchElement classes;

        public NameSpaceElement(string name)
        {
            this.name = name;
            this.usings = new UsingsElement();
            this.classes = new PatchElement();
            this.hasClasses = false;

            emit("namespace {0}", UseSpace.Never, UseSpace.Never, name);
            emitBlockStart();
            insertElement(usings);
            insertElement(classes);
            emitBlockEnd();
        }

        public ClassElement CreateClass(string name, AccessModifiers modifiers, string implements = null)
        {
            if (hasClasses)
                classes.EmitNewLine();

            ClassElement element = new ClassElement(name, modifiers, implements);
            classes.InsertElement(element);

            hasClasses = true;
            return element;
        }
    }
}
