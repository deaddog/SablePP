using System;
using System.IO;
using System.Text;

namespace Sable.Tools.Generate
{
    public class CodeStreamWriter : IDisposable
    {
        private Stream stream;
        private Encoding encoding;
        private int indentation;
        private int indentationSize;

        private CodeElement lastElement;

        private CodeStreamWriter(Stream stream, Encoding encoding, int indentationSize)
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
        }

        public static void Generate(Stream stream, CodeElement element)
        {
            Generate(stream, Encoding.UTF8, 4, element);
        }

        public static void Generate(Stream stream, Encoding encoding, int indentationSize, CodeElement element)
        {
            element.Generate(new CodeStreamWriter(stream, encoding, indentationSize));
        }

        public static string ToString(CodeElement element, int indentationSize = 4)
        {
            byte[] buffer;

            using (MemoryStream ms = new MemoryStream())
            {
                element.Generate(new CodeStreamWriter(ms, Encoding.Unicode, indentationSize));
                buffer = ms.ToArray();
            }

            return Encoding.Unicode.GetString(buffer);
        }

        public int Indentation
        {
            get { return indentation; }
            set { indentation = value; }
        }
        public int IndentationSize
        {
            get { return indentationSize; }
        }

        internal CodeElement LastElement
        {
            get { return lastElement; }
            set
            {
                if (value != null)
                {
                    if (!(value is NewLineElement) && !(value is TextElement))
                        throw new ArgumentException("Last element can only be newline or text.");
                }
                lastElement = value;
            }
        }

        public void WriteString(string text)
        {
            byte[] buffer = encoding.GetBytes(text);
            stream.Write(buffer, 0, buffer.Length);
        }
        public void RemoveFromEnd(string text)
        {
            int cut = encoding.GetByteCount(text);
            if (cut > stream.Length)
                throw new ArgumentOutOfRangeException("text", "Value longer than current length of stream.");

            stream.Seek(-cut, System.IO.SeekOrigin.Current);
            stream.SetLength(stream.Length - cut);
        }

        void IDisposable.Dispose()
        {
        }
    }
}
