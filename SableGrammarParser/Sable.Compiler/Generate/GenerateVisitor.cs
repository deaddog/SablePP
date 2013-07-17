using System;
using System.Collections.Generic;
using System.Linq;
using Sable.Compiler.analysis;

namespace Sable.Compiler.Generate
{
    public abstract class GenerateVisitor : DepthFirstAdapter
    {
        protected static string ToCamelCase(string text)
        {
            return Sable.Compiler.CommonMethods.ToCamelCase(text);
        }
    }
}
