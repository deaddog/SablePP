using SablePP.Tools.Generate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.SableCC
{
    internal class Builder
    {
        private PatchElement root;

        private Builder()
        {
            this.root = new PatchElement();
        }

        public static void BuildToFile(Grammar grammar, string filepath)
        {
            Builder builder = new Builder();
            builder.Start(grammar);
            builder.root.ToFile(filepath, Encoding.Unicode, "  ");
        }

        private void Start(Grammar grammar)
        {
            throw new NotImplementedException();
        }
    }
}
