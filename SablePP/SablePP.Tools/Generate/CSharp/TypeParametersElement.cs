using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Represents a list of types in the declaration of a type or member.
    /// </summary>
    public class TypeParametersElement : CodeElement, IEnumerable<string>
    {
        private List<string> types;

        private TypeParametersElement()
        {
            this.types = new List<string>();
        }

        /// <summary>
        /// Adds a type name to the <see cref="TypeParametersElement"/>.
        /// </summary>
        /// <param name="type">The name of the type that is added.</param>
        public void Add(string type)
        {
            this.types.Add(type);
        }
        /// <summary>
        /// Removes a type name from the <see cref="TypeParametersElement"/>.
        /// </summary>
        /// <param name="type">The name of the type that should be removed.</param>
        /// <returns><c>true</c>, if the type name was removed from the <see cref="TypeParametersElement"/>; otherwise, false.</returns>
        public bool Remove(string type)
        {
            return types.Remove(type);
        }

        /// <summary>
        /// Gets or sets the type name at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the type name in the <see cref="TypeParametersElement"/>.</param>
        /// <returns>The type name at <paramref name="index"/>.</returns>
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

        /// <summary>
        /// Gets the number of types in this <see cref="TypeParametersElement"/>.
        /// </summary>
        public int Count
        {
            get { return types.Count; }
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
