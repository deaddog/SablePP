using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Generate.CSharp
{
    public class TypeParametersElement : CodeElement, IEnumerable<string>
    {
        private List<string> types;

        internal TypeParametersElement()
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
    }
}
