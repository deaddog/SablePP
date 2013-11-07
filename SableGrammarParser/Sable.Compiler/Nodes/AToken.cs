using System;

namespace Sable.Compiler.Nodes
{
    public partial class AToken
    {
        public string ClassName
        {
            get { return "T" + this.Identifier.Text.ToCamelCase(); }
        }
    }
}
