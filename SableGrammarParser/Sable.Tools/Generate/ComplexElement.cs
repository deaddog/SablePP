using System;
using System.Collections.Generic;

namespace Sable.Tools.Generate
{
    public abstract class ComplexElement : CodeElement
    {
        private LinkedList<CodeElement> elements;

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
        }

        protected void emit(string text, UseSpace prepend, UseSpace append, params object[] args)
        {
            if (args != null && args.Length > 0)
                text = string.Format(text, args);
            
            if (elements.Count > 0 && elements.Last.Value is TextElement)
                (elements.Last.Value as TextElement).AppendText(text, prepend, append);
            else
                elements.AddLast(new TextElement(text, prepend, append));
        }
        protected void emitNewLine()
        {
            elements.AddLast(new NewLineElement());
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
                elements.AddLast(new IndentationElement(difference));
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
    }
}
