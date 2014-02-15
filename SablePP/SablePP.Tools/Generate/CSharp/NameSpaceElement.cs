﻿namespace SablePP.Tools.Generate.CSharp
{
    public sealed class NameSpaceElement : ComplexElement
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
        public bool HasClasses
        {
            get { return hasClasses; }
        }

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
            emitLine("}", UseSpace.Never, UseSpace.Never);
        }

        public void Add(ClassElement @class)
        {
            classes.InsertElement(@class);
            hasClasses = true;
        }

        public void EmitNewLine()
        {
            classes.EmitNewLine();
        }
        public void EmitRegionStart(string text)
        {
            classes.Emit("#region " + text, UseSpace.Never, UseSpace.Never);
            classes.EmitNewLine();
        }
        public void EmitRegionEnd()
        {
            classes.Emit("#endregion", UseSpace.Never, UseSpace.Never);
            classes.EmitNewLine();
        }
    }
}
