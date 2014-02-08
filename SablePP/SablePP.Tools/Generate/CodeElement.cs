using System;
using System.IO;
using System.Text;

namespace SablePP.Tools.Generate
{
    public abstract class CodeElement
    {
        internal ComplexElement parent;

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
        /// <param name="indentationSize">Size of indentation (in spaces) when emitting a new line.</param>
        /// <returns>
        /// A string that contains all the code contained by this <see cref="CodeElement"/>.
        /// </returns>
        public string ToString(int indentationSize)
        {
            byte[] buffer;

            using (MemoryStream ms = new MemoryStream())
            {
                this.Generate(new CodeStreamWriter(ms, Encoding.Unicode, indentationSize));
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
            ToStream(stream, Encoding.UTF8, 4);
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
        /// <param name="indentationSize">Size of indentation (in spaces) when emitting a new line.</param>
        public void ToStream(Stream stream, Encoding encoding, int indentationSize)
        {
            this.Generate(new CodeStreamWriter(stream, encoding, indentationSize));
        }
        /// <summary>
        /// Writes the code of this <see cref="CodeElement"/> and all its children (if any) to a file using a specific encoding.
        /// If the file already exists, it is replaced; if not, it is created.
        /// </summary>
        /// <param name="filename">The path of the file to which code should be written.</param>
        /// <param name="encoding">The encoding used for writing.</param>
        /// <param name="indentationSize">Size of indentation (in spaces) when emitting a new line.</param>
        public void ToFile(string filename, Encoding encoding, int indentationSize)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create))
                ToStream(fs, encoding, indentationSize);
        }
    }
}
