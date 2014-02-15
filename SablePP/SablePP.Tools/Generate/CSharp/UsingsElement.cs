using System;

namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Represents a collection of using statements for C# code generation.
    /// </summary>
    public sealed class UsingsElement : CSharpElement
    {
        private PatchElement usingsElement;

        /// <summary>
        /// Adds a usings statement to the collection.
        /// </summary>
        /// <param name="key">The name of the namespace to add.</param>
        /// <param name="mapsto">(Optional) The name of the namespace to which <paramref name="key"/> points.</param>
        public void Add(string key, string mapsto = null)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            if (mapsto == null)
                mapsto = string.Empty;

            if (usingsElement == null)
            {
                usingsElement = new PatchElement();
                insertElement(usingsElement);
                emitNewLine();
            }

            key = key.Trim();
            mapsto = mapsto.Trim();
            if (mapsto.Length == 0)
                usingsElement.Emit("using {0};", UseSpace.Never, UseSpace.Never, key);
            else
                usingsElement.Emit("using {0} = {1}", UseSpace.Never, UseSpace.Never, key, mapsto);

            usingsElement.EmitNewLine();
        }

        /// <summary>
        /// Emits a newline character to the <see cref="UsingsElement"/>.
        /// </summary>
        public void EmitNewline()
        {
            if (usingsElement == null)
            {
                usingsElement = new PatchElement();
                insertElement(usingsElement);
                emitNewLine();
            }
            usingsElement.EmitNewLine();
        }
    }
}
