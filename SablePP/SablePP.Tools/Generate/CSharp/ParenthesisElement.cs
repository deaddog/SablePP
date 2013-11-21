using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Generate.CSharp
{
    public class ParenthesisElement : ExecutableElement
    {
        private Types type;
        public Types Type
        {
            get { return type; }
        }

        public ParenthesisElement(Types type = Types.Round)
        {
            this.type = type;

            emit(start, UseSpace.Never, UseSpace.Never);
            InsertContents();
            emit(end, UseSpace.Never, UseSpace.Never);
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
    }
}
