using SablePP.Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Generate.Productions
{
    public class ProductionElement
    {
        private PElement element;

        public ProductionElement(PElement element)
        {
            this.element = element;
        }

        public string ProductionOrTokenClass
        {
            get
            {
                TIdentifier typeId = element.PElementid.TIdentifier;
                return (typeId.IsToken ? "T" + SablePP.Compiler.CommonMethods.ToCamelCase(typeId.AsToken.Name) : "P" + SablePP.Compiler.CommonMethods.ToCamelCase(typeId.AsProduction.Name));
            }
        }

        public string FieldName
        {
            get { return "_" + element.LowerName + "_"; }
        }
        public string PropertyName
        {
            get { return SablePP.Compiler.CommonMethods.ToCamelCase(element.LowerName); }
        }

        public ElementTypes ElementType
        {
            get { return element.GetElementType(); }
        }

        public override string ToString()
        {
            return element.ToString();
        }
    }
}
