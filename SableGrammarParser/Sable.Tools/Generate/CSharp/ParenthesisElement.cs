using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sable.Tools.Generate.CSharp
{
    public class ParenthesisElement : ExecutableElement, IDisposable
    {
        private Types type;
        public Types Type
        {
            get { return type; }
        }

        public ParenthesisElement(Types type = Types.Round)
        {
            this.type = type;

            emit(start, UseSpace.NotPreferred, UseSpace.NotPreferred);
            InsertContents();
            emit(end, UseSpace.NotPreferred, UseSpace.NotPreferred);
        }

        private string start
        {
            get
            {
                switch (type)
                {
                    case Types.Round: return "(";
                    case Types.Angled: return "<";
                    case Types.Curly: return "{";
                    case Types.Square: return "[";
                    default:
                        throw new NotImplementedException("Unknown parenthesis type.");
                }
            }
        }
        private string end
        {
            get
            {
                switch (type)
                {
                    case Types.Round: return ")";
                    case Types.Angled: return ">";
                    case Types.Curly: return "}";
                    case Types.Square: return "]";
                    default:
                        throw new NotImplementedException("Unknown parenthesis type.");
                }
            }
        }

        public enum Types
        {
            Round,
            Angled,
            Curly,
            Square
        }

        void IDisposable.Dispose()
        {
            // Nothing to dispose, but implementing IDisposable allows for the use of the "using" construct.
        }
    }
}
