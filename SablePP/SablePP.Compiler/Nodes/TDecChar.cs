using System;

namespace SablePP.Compiler.Nodes
{
    public partial class TDecChar
    {
        public int Value
        {
            get { return int.Parse(this.Text); }
        }
    }
}
