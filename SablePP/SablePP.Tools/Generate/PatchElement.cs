using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Generate
{
    /// <summary>
    /// A <see cref="CodeElement"/> that exposes the protected methods defined by <see cref="ComplexElement"/> as public methods.
    /// </summary>
    public class PatchElement : ComplexElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatchElement"/> class.
        /// </summary>
        public PatchElement()
        {
        }

        /// <summary>
        /// Inserts a <see cref="CodeElement"/> as the last child of this <see cref="PatchElement"/>.
        /// </summary>
        /// <param name="element">The element to insert.</param>
        public void InsertElement(CodeElement element)
        {
            base.insertElement(element);
        }

        /// <summary>
        /// Emits <paramref name="text"/> to the end of this <see cref="PatchElement"/>.
        /// </summary>
        /// <param name="text">The text to emit.</param>
        /// <param name="args">Optional array of arguments to insert into the string. See <see cref="String.Format(String, Object[])"/>.</param>
        public void Emit(string text, params object[] args)
        {
            base.emit(text, args);
        }
        /// <summary>
        /// Emits text to the end of this <see cref="PatchElement"/>.
        /// </summary>
        /// <param name="text">The text to emit.</param>
        /// <param name="prepend">A <see cref="UseSpace"/> determining if this text should be prepended with a space.</param>
        /// <param name="append">A <see cref="UseSpace"/> determining if this text should be appended with a space.</param>
        /// <param name="args">Optional array of arguments to insert into the string. See <see cref="String.Format(String, Object[])"/>.</param>
        public void Emit(string text, UseSpace prepend, UseSpace append, params object[] args)
        {
            base.emit(text, prepend, append, args);
        }
        /// <summary>
        /// Emits <paramref name="text"/>, followed by a newline, to the end of this <see cref="PatchElement"/>. Space prepending is <see cref="UseSpace.NotPreferred"/>.
        /// </summary>
        /// <param name="text">The text to emit.</param>
        /// <param name="args">Optional array of arguments to insert into the string. See <see cref="String.Format(String, Object[])"/>.</param>
        public void EmitLine(string text, params object[] args)
        {
            base.emitLine(text, args);
        }
        /// <summary>
        /// Emits <paramref name="text"/>, followed by a newline, to the end of this <see cref="PatchElement"/>.
        /// </summary>
        /// <param name="text">The text to emit.</param>
        /// <param name="prepend">A <see cref="UseSpace"/> determining if this text should be prepended with a space.</param>
        /// <param name="args">Optional array of arguments to insert into the string. See <see cref="String.Format(String, Object[])"/>.</param>
        public void EmitLine(string text, UseSpace prepend, params object[] args)
        {
            base.emitLine(text, prepend, args);
        }

        /// <summary>
        /// Emits a new line at the end of this <see cref="PatchElement"/>.
        /// </summary>
        public void EmitNewLine()
        {
            base.emitNewLine();
        }

        /// <summary>
        /// Occurs when a new line is emitted (inserted) in this <see cref="PatchElement"/>.
        /// </summary>
        public event Action NewLineEmitted;
        /// <summary>
        /// Raises the <see cref="NewLineEmitted"/> event.
        /// </summary>
        protected sealed override void newLineEmitted()
        {
            if (NewLineEmitted != null)
                NewLineEmitted();
        }

        /// <summary>
        /// Increases the indentation for the coming elements in this <see cref="PatchElement"/>.
        /// </summary>
        public void IncreaseIndentation()
        {
            base.increaseIndentation();
        }
        /// <summary>
        /// Decreases the indentation for the coming elements in this <see cref="PatchElement"/>.
        /// </summary>
        public void DecreaseIndentation()
        {
            base.decreaseIndentation();
        }

        /// <summary>
        /// Changes the indentation for the coming elements in this <see cref="PatchElement"/>.
        /// </summary>
        /// <param name="difference">The change in indentation. Use negative values to decrease indentation and positive to increase. 0 (zero) will have no effect.</param>
        public void ChangeIndentation(int difference)
        {
            base.changeIndentation(difference);
        }
    }
}
