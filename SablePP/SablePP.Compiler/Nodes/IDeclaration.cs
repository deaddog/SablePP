using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Nodes
{
    public interface IDeclaration
    {
        TIdentifier GetIdentifier();
    }
}
