﻿using System;
using System.IO;
using System.Text;

namespace SablePP.Tools.Generate
{
    /// <summary>
    /// Provides methods for generating code from the composite structure defined by <see cref="CodeElement"/>.
    /// </summary>
    public class CodeStreamWriter : IDisposable
    {
        private Stream stream;
        private Encoding encoding;
        private int indentation;
        private string indentationString;

        private string currentLine;

        internal CodeStreamWriter(Stream stream, Encoding encoding, string indentation)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (!stream.CanWrite)
                throw new ArgumentException("Writing must be enabled for stream.", "stream");
            this.stream = stream;

            if (encoding == null)
                throw new ArgumentNullException("encoding");
            this.encoding = encoding;

            if (indentation == null)
                throw new ArgumentNullException("indentation");
            if (indentation.Length == 0)
                throw new ArgumentException("Indentation cannot be the empty string.", "indentation");

            this.indentation = 0;
            this.indentationString = indentation;

            this.currentLine = string.Empty;
        }

        /// <summary>
        /// Gets or sets the current indentation used by the <see cref="CodeStreamWriter"/>.
        /// </summary>
        public int Indentation
        {
            get { return indentation; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "Indentation must be greater than or equal to zero.");

                indentation = value;
            }
        }

        private string getIndentationString(int indent)
        {
            string result = string.Empty;
            
            for (int i = 0; i < indent; i++)
                result += indentationString;

            return result;
        }

        /// <summary>
        /// Writes the a string to the output.
        /// </summary>
        /// <param name="text">The string that should be written to the output stream.
        /// If the string contains newline, indentation is disregarded.</param>
        public void WriteString(string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            if (text.Length == 0)
                return;

            if (currentLine == string.Empty)
                currentLine = getIndentationString(indentation);

            currentLine += text;
        }
        /// <summary>
        /// Writes a newline to the output stream. The next line will obey the indentation defined by <see cref="Indentation"/>.
        /// </summary>
        public void WriteNewline()
        {
            if (currentLine == string.Empty)
                currentLine = getIndentationString(indentation);

            byte[] buffer = encoding.GetBytes(currentLine + "\r\n");
            stream.Write(buffer, 0, buffer.Length);

            currentLine = string.Empty;
        }

        void IDisposable.Dispose()
        {
            byte[] buffer = encoding.GetBytes(currentLine);
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
