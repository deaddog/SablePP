using System;
using System.Collections.Generic;
using System.Linq;
using SablePP.Compiler.Analysis;

namespace SablePP.Compiler.Generate
{
    public abstract class GenerateVisitor : DepthFirstAdapter
    {
        protected static string ToCamelCase(string text)
        {
            return SablePP.Compiler.CommonMethods.ToCamelCase(text);
        }
    }
}
