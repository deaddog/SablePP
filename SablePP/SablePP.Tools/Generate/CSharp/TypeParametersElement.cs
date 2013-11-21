using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Generate.CSharp
{
    public class TypeParametersElement : CSharpElement
    {
        private PatchElement contents = null;
        private List<string> types;

        public TypeParametersElement()
        {
            this.types = new List<string>();
        }

        public void Add(string type)
        {
            if (contents == null)
            {
                emit("<", UseSpace.Never, UseSpace.Never);
                contents = new PatchElement();
                insertElement(contents);
                emit(">", UseSpace.Never, UseSpace.Never);
            }

            types.Add(type);
            if (types.Count > 1)
                contents.Emit(",", UseSpace.Never, UseSpace.Always);
            contents.Emit(type, UseSpace.NotPreferred, UseSpace.NotPreferred);
        }
        public string this[int index]
        {
            get { return types[index]; }
        }
    }
}
