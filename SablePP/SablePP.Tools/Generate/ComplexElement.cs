using System;
using System.Collections.Generic;

namespace SablePP.Tools.Generate
{
    /// <summary>
    /// A <see cref="CodeElement"/> that allows for insertion of child-elements through a selection of protected methods.
    /// Custom elements should inherit this element.
    /// </summary>
    public abstract class ComplexElement : CodeElement, IDisposable
    {
        private LinkedList<CodeElement> elements;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplexElement"/> class.
        /// </summary>
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

        /// <summary>
        /// Inserts a <see cref="CodeElement"/> as the last child of this <see cref="ComplexElement"/>.
        /// </summary>
        /// <param name="element">The element to insert.</param>
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

        /// <summary>
        /// Emits <paramref name="text"/> to the end of this <see cref="ComplexElement"/>.
        /// </summary>
        /// <param name="text">The text to emit.</param>
        /// <param name="prepend">A <see cref="UseSpace"/> determining if this text should be prepended with a space.</param>
        /// <param name="append">A <see cref="UseSpace"/> determining if this text should be appended with a space.</param>
        /// <param name="args">Optional array of arguments to insert into the string. See <see cref="String.Format(String, Object[])"/>.</param>
        protected void emit(string text, UseSpace prepend, UseSpace append, params object[] args)
        {
            if (args != null && args.Length > 0)
                text = string.Format(text, args);

            if (elements.Count > 0 && elements.Last.Value is TextElement)
                (elements.Last.Value as TextElement).AppendText(text, prepend, append);
            else
                insertElement(new TextElement(text, prepend, append));
        }
        /// <summary>
        /// Emits <paramref name="text"/>, followed by a newline, to the end of this <see cref="ComplexElement"/>. Space prepending is <see cref="UseSpace.NotPreferred"/>.
        /// </summary>
        /// <param name="text">The text to emit.</param>
        /// <param name="args">Optional array of arguments to insert into the string. See <see cref="String.Format(String, Object[])"/>.</param>
        public void emitLine(string text, params object[] args)
        {
            emitLine(text, UseSpace.NotPreferred, args);
        }
        /// <summary>
        /// Emits <paramref name="text"/>, followed by a newline, to the end of this <see cref="ComplexElement"/>.
        /// </summary>
        /// <param name="text">The text to emit.</param>
        /// <param name="prepend">A <see cref="UseSpace"/> determining if this text should be prepended with a space.</param>
        /// <param name="args">Optional array of arguments to insert into the string. See <see cref="String.Format(String, Object[])"/>.</param>
        public void emitLine(string text, UseSpace prepend, params object[] args)
        {
            emit(text, prepend, UseSpace.Never, args);
            emitNewLine();
        }

        /// <summary>
        /// Emits a new line at the end of this <see cref="ComplexElement"/>.
        /// </summary>
        protected void emitNewLine()
        {
            insertElement(new NewLineElement());
            newLineEmitted();
        }
        /// <summary>
        /// When overridden in a derived class, handles element-specific operations when a newline is inserted into the element.
        /// The <see cref="ComplexElement.newLineEmitted"/> has no effect.
        /// </summary>
        protected virtual void newLineEmitted()
        {
        }

        /// <summary>
        /// Increases the indentation for the coming elements in this <see cref="ComplexElement"/>.
        /// </summary>
        protected void increaseIndentation()
        {
            changeIndentation(1);
        }
        /// <summary>
        /// Decreases the indentation for the coming elements in this <see cref="ComplexElement"/>.
        /// </summary>
        protected void decreaseIndentation()
        {
            changeIndentation(-1);
        }

        /// <summary>
        /// Changes the indentation for the coming elements in this <see cref="ComplexElement"/>.
        /// </summary>
        /// <param name="difference">The change in indentation. Use negative values to decrease indentation and positive to increase. 0 (zero) will have no effect.</param>
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

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents the number of elements contained in this <see cref="ComplexElement"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} elements", elements.Count);
        }

        private static PatchElement FlattenElement(ComplexElement element)
        {
            PatchElement result = new PatchElement();

            foreach (var e in Walk(element))
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

        /// <summary>
        /// When overridden in a derived class, performs actions that are required before disposing this <see cref="ComplexElement"/>.
        /// Disposing a <see cref="ComplexElement"/> will flatten its substructure.
        /// </summary>
        protected virtual void Dispose()
        {
        }

        void IDisposable.Dispose()
        {
            Dispose();

            disposed = true;

            if (parent != null)
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
