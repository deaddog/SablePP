using System;

namespace SablePP.Tools.Generate
{
    /// <summary>
    /// Represents a leaf element, indicating that a there should be a change in indentation in the generated code.
    /// </summary>
    public sealed class IndentationElement : CodeElement
    {
        private int difference;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndentationElement"/> class.
        /// </summary>
        /// <param name="difference">The difference in indentation that should be applied. Positive values increases the indentation and negative values decreases it.</param>
        public IndentationElement(int difference)
        {
            this.difference = difference;
        }

        /// <summary>
        /// Gets or sets the difference in indentation that is the effect of this <see cref="IndentationElement"/>. Positive values increases the indentation and negative values decreases it.
        /// </summary>
        public int Difference
        {
            get { return difference; }
            set { difference = value; }
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
        /// Generates a clone of this <see cref="IndentationElement" />.
        /// </summary>
        /// <returns>
        /// A clone of this <see cref="IndentationElement" />.
        /// </returns>
        public override CodeElement CloneFlat()
        {
            return new IndentationElement(this.difference);
        }

        internal override void Generate(CodeStreamWriter streamwriter)
        {
            if (difference == 0)
                return;

            streamwriter.Indentation += difference;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents the 'size' of the indentation.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Indent by {0}", difference);
        }
    }
}
