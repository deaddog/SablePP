using System;
using System.Text;

namespace SablePP.Tools.Generate
{
    /// <summary>
    /// Represents a leaf element, indicating that a there should be a line change in the generated code.
    /// </summary>
    public sealed class NewLineElement : CodeElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewLineElement"/> class.
        /// </summary>
        public NewLineElement()
        {
        }

        internal override UseSpace Append
        {
            get { return UseSpace.Never; }
        }
        internal override UseSpace Prepend
        {
            get { return UseSpace.Never; }
        }

        /// <summary>
        /// Generates a clone of this <see cref="NewLineElement" />.
        /// </summary>
        /// <returns>
        /// A clone of this <see cref="NewLineElement" />.
        /// </returns>
        public override CodeElement CloneFlat()
        {
            return new NewLineElement();
        }

        internal override void Generate(CodeStreamWriter streamwriter)
        {
            streamwriter.WriteNewline();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance internally.
        /// </summary>
        public override string ToString()
        {
            return "[New line]";
        }
    }
}
