using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Generate.CSharp
{
    public class TypeParametersElement : CodeElement, IEnumerable<string>
    {
        private List<string> types;

        private TypeParametersElement()
        {
            this.types = new List<string>();
        }

        public void Add(string type)
        {
            this.types.Add(type);
        }
        public bool Remove(string type)
        {
            return types.Remove(type);
        }

        public string this[int index]
        {
            get { return types[index]; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                else
                    types[index] = value;
            }
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            foreach (var s in types)
                yield return s;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (var s in types)
                yield return s;
        }

        internal override UseSpace Append
        {
            get { return UseSpace.Never; }
        }
        internal override UseSpace Prepend
        {
            get { return UseSpace.Never; }
        }
        internal override void Generate(CodeStreamWriter streamwriter)
        {
            if (types.Count > 0)
            {
                streamwriter.WriteString("<");
                bool first = true;
                foreach (var type in types)
                {
                    if (!first)
                        streamwriter.WriteString(", ");
                    first = false;

                    streamwriter.WriteString(type);
                }
                streamwriter.WriteString(">");
            }
        }
        internal static TypeParametersElement Parse(string signature)
        {
            TypeParametersElement element = new TypeParametersElement();

            string[] parameters = signature.Split(',');
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
                if (parameters[i].Length > 0)
                    element.types.Add(parameters[i]);
            }

            return element;
        }
    }
}
