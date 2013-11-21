using System;
using Sable.Compiler.Nodes;

namespace Sable.Compiler.Generate.Productions
{
    public abstract class ProductionVisitor : GenerateVisitor
    {
        protected string GetFieldName(PElement element)
        {
            return "_" + element.LowerName + "_";
        }
        protected string GetPropertyName(PElement element)
        {
            return ToCamelCase(element.LowerName);
        }
    }
}
