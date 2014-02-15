using System;
using System.Collections.Generic;

namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Represents a C# file and exposes methods for emitting namespaces and using statements.
    /// </summary>
    public sealed class FileElement : ComplexElement, IEnumerable<NameSpaceElement>
    {
        private UsingsElement usings;
        /// <summary>
        /// Gets a <see cref="UsingElement"/> describing the using statements included in this <see cref="FileElement"/>.
        /// </summary>
        public UsingsElement Using
        {
            get { return usings; }
        }

        private List<NameSpaceElement> namespaces;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileElement"/> class.
        /// </summary>
        public FileElement()
        {
            this.usings = new UsingsElement();
            this.insertElement(usings);

            this.namespaces = new List<NameSpaceElement>();
        }

        /// <summary>
        /// Adds a <see cref="NameSpaceElement"/> to this <see cref="FileElement"/>.
        /// </summary>
        /// <param name="namespace">The namespace that should be inserted.</param>
        public void Add(NameSpaceElement @namespace)
        {
            if (@namespace == null)
                throw new ArgumentNullException("namespace");

            namespaces.Add(@namespace);
            insertElement(@namespace);
        }

        IEnumerator<NameSpaceElement> IEnumerable<NameSpaceElement>.GetEnumerator()
        {
            foreach (var n in namespaces)
                yield return n;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (var n in namespaces)
                yield return n;
        }
    }
}
