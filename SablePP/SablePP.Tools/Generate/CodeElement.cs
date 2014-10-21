using System;
using System.IO;
using System.Text;

namespace SablePP.Tools.Generate
{
    /// <summary>
    /// Represents an element in a composite structure of generated code.
    /// </summary>
    public abstract class CodeElement
    {
        internal ComplexElement parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeElement"/> class.
        /// </summary>
        protected CodeElement()
        {
            this.parent = null;
        }

        internal abstract UseSpace Append
        {
            get;
        }
        internal abstract UseSpace Prepend
        {
            get;
        }

        /// <summary>
        /// Generates a clone of this <see cref="CodeElement"/> structure by copying its content into base element types.
        /// The text, indentation and newline structure is maintained in the clone.
        /// </summary>
        /// <returns>A content-clone of this <see cref="CodeElement"/>.</returns>
        public virtual CodeElement CloneFlat()
        {
            return new TextElement(this.ToString(""), this.Prepend, this.Append);
        }

        /// <summary>
        /// Defines a ruleset that determines if two <see cref="CodeElement"/>s should be separated by a space.
        /// </summary>
        /// <param name="append">A <see cref="UseSpace"/> enum that determines the need for a space after the first element.</param>
        /// <param name="prepend">A <see cref="UseSpace"/> enum that determines the need for a space before the second element.</param>
        /// <returns><c>true</c>, if the two elements should be separated by a space; otherwise, <c>false</c>.</returns>
        protected static bool useSpace(UseSpace append, UseSpace prepend)
        {
            switch (append)
            {
                case UseSpace.Preferred:
                    return prepend != UseSpace.Never;
                case UseSpace.NotPreferred:
                    return prepend == UseSpace.Preferred || prepend == UseSpace.Always;
                case UseSpace.Always:
                    return true;
                case UseSpace.Never:
                    return prepend == UseSpace.Always;
                default:
                    throw new InvalidOperationException();
            }
        }

        internal abstract void Generate(CodeStreamWriter streamwriter);

        /// <summary>
        /// Builds a string with the code contained by this <see cref="CodeElement"/> and all its children (if any).
        /// </summary>
        /// <param name="indentation">A string representing the indentation used when emitting a new line.</param>
        /// <returns>
        /// A string that contains all the code contained by this <see cref="CodeElement"/>.
        /// </returns>
        public string ToString(string indentation)
        {
            byte[] buffer;

            using (MemoryStream ms = new MemoryStream())
            {
                ToStream(ms, Encoding.Unicode, indentation);
                buffer = ms.ToArray();
            }

            return Encoding.Unicode.GetString(buffer);
        }

        /// <summary>
        /// Writes the code of this <see cref="CodeElement"/> and all its children (if any) to a stream.
        /// </summary>
        /// <param name="stream">The stream to which the code should be written.</param>
        public void ToStream(Stream stream)
        {
            ToStream(stream, Encoding.UTF8, "    ");
        }
        /// <summary>
        /// Writes the code of this <see cref="CodeElement"/> and all its children (if any) to a file.
        /// If the file already exists, it is replaced; if not, it is created.
        /// </summary>
        /// <param name="filename">The path of the file to which code should be written.</param>
        public void ToFile(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create))
                ToStream(fs);
        }

        /// <summary>
        /// Writes the code of this <see cref="CodeElement"/> and all its children (if any) to a stream using a specific encoding.
        /// </summary>
        /// <param name="stream">The stream to which the code should be written.</param>
        /// <param name="encoding">The encoding used for writing.</param>
        /// <param name="indentation">A string representing the indentation used when emitting a new line.</param>
        public void ToStream(Stream stream, Encoding encoding, string indentation)
        {
            using (CodeStreamWriter csw = new CodeStreamWriter(stream, encoding, indentation))
                this.Generate(csw);
        }
        /// <summary>
        /// Writes the code of this <see cref="CodeElement"/> and all its children (if any) to a file using a specific encoding.
        /// If the file already exists, it is replaced; if not, it is created.
        /// </summary>
        /// <param name="filename">The path of the file to which code should be written.</param>
        /// <param name="encoding">The encoding used for writing.</param>
        /// <param name="indentation">A string representing the indentation used when emitting a new line.</param>
        public void ToFile(string filename, Encoding encoding, string indentation)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create))
                ToStream(fs, encoding, indentation);
        }
    }
}
