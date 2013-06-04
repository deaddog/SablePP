using System;

namespace Sable.Compiler.Generate.CSharp
{
    public sealed class UsingElement : ComplexElement
    {
        private PatchElement usingsElement;

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
    }
}
