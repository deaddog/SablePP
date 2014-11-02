using System;

namespace SablePP.Compiler.Nodes
{
    public partial class ANullTranslation
    {
        public override string ClassName
        {
            get { throw new InvalidOperationException("Cannot retrieve class name from a null translation."); }
        }

        public override bool IsList
        {
            get { return false; }
        }
    }
}
