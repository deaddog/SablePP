using System;
using System.IO;
using System.Text;

namespace SablePP.Tools.Generate
{
    internal class CodeStreamWriter : IDisposable
    {
        private Stream stream;
        private Encoding encoding;
        private int indentation;
        private int indentationSize;

        private string currentLine;

        public CodeStreamWriter(Stream stream, Encoding encoding, int indentationSize)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (!stream.CanWrite)
                throw new ArgumentException("Writing must be enabled for stream.", "stream");
            this.stream = stream;

            if (encoding == null)
                throw new ArgumentNullException("encoding");
            this.encoding = encoding;

            if (indentationSize <= 0)
                throw new ArgumentOutOfRangeException("indentationSize", "Indentation size must be greater than zero.");

            this.indentation = 0;
            this.indentationSize = indentationSize;

            this.currentLine = string.Empty;
        }

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
        public int IndentationSize
        {
            get { return indentationSize; }
        }

        private string getIndentationString(int indent)
        {
            return string.Empty.PadRight(indent * indentationSize);
        }

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
        public void WriteNewline()
        {
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
