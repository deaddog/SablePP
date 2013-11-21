using System;
using System.Collections.Generic;

namespace SablePP.Tools.Generate
{
    public abstract class ComplexElement : CodeElement, IDisposable
    {
        private LinkedList<CodeElement> elements;
        private bool disposed = false;

        public ComplexElement()
        {
            this.elements = new LinkedList<CodeElement>();
        }

        internal sealed override UseSpace Append
        {
            get { return elements.Count == 0 ? UseSpace.NotPreferred : elements.Last.Value.Append; }
        }
        internal sealed override UseSpace Prepend
        {
            get { return elements.Count == 0 ? UseSpace.NotPreferred : elements.First.Value.Prepend; }
        }

        protected void insertElement(CodeElement element)
        {
            elements.AddLast(element);
            if (element.parent != null)
                throw new ArgumentException("Element is already part of other " + (typeof(ComplexElement)).Name, "element");
            else
                element.parent = this;

            if (disposed)
                throw new InvalidOperationException("Unable to insert elements into this " + (typeof(ComplexElement)).Name + " as it has been disposed.");
        }

        protected void emit(string text, UseSpace prepend, UseSpace append, params object[] args)
        {
            if (args != null && args.Length > 0)
                text = string.Format(text, args);

            if (elements.Count > 0 && elements.Last.Value is TextElement)
                (elements.Last.Value as TextElement).AppendText(text, prepend, append);
            else
                insertElement(new TextElement(text, prepend, append));
        }
        protected void emitNewLine()
        {
            insertElement(new NewLineElement());
        }

        protected void increaseIndentation()
        {
            changeIndentation(1);
        }
        protected void decreaseIndentation()
        {
            changeIndentation(-1);
        }

        protected void changeIndentation(int difference)
        {
            if (difference == 0)
                return;

            if (elements.Count > 0 && elements.Last.Value is IndentationElement)
            {
                IndentationElement e = elements.Last.Value as IndentationElement;
                e.Difference += difference;
                if (e.Difference == 0)
                    elements.RemoveLast();
            }
            else
                insertElement(new IndentationElement(difference));
        }

        internal sealed override void Generate(CodeStreamWriter streamwriter)
        {
            CodeElement[] elementArr = new CodeElement[elements.Count];
            elements.CopyTo(elementArr, 0);
            for (int i = 0; i < elementArr.Length; i++)
            {
                if (i > 0 && useSpace(elementArr[i - 1].Append, elementArr[i].Prepend))
                    streamwriter.WriteString(" ");
                elementArr[i].Generate(streamwriter);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} elements", elements.Count);
        }

        private static PatchElement FlattenElement(ComplexElement element)
        {
            PatchElement result = new PatchElement();

            foreach(var e in Walk(element))
            {
                if (e is TextElement)
                    result.emit((e as TextElement).Text, e.Prepend, e.Append);
                else if (e is NewLineElement)
                    result.EmitNewLine();
                else if (e is IndentationElement)
                    result.changeIndentation((e as IndentationElement).Difference);
            }

            return result;
        }

        private static IEnumerable<CodeElement> Walk(CodeElement element)
        {
            if (element is ComplexElement)
            {
                ComplexElement compl = element as ComplexElement;
                CodeElement[] elementArr = new CodeElement[compl.elements.Count];
                compl.elements.CopyTo(elementArr, 0);
                for (int i = 0; i < elementArr.Length; i++)
                    foreach (var e in Walk(elementArr[i]))
                        yield return e;
            }
            else
                yield return element;
        }

        protected virtual void Dispose()
        {
        }

        void IDisposable.Dispose()
        {
            Dispose();

            disposed = true;

            if(parent!=null)
            {
                PatchElement replacement = FlattenElement(this);
                if (replacement.elements.Count == 1)
                {
                    CodeElement e = replacement.elements.First.Value;
                    LinkedListNode<CodeElement> element = this.parent.elements.Find(this);
                    element.Value = e;
                    e.parent = this.parent;
                }
                else
                {
                    LinkedListNode<CodeElement> element = this.parent.elements.Find(this);
                    element.Value = replacement;
                    replacement.parent = this.parent;
                }
            }
        }
    }
}
