using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sable.Compiler.Generate.CSharp
{
    public enum AccessModifiers
    {
        @public = 1,
        @private = 2,
        @protected = 4,
        @partial = 8,
        @new = 16,
        @internal = 32,
        @abstract = 64,
        @virtual = 128,
        @override = 256
    }
}
