using SablePP.Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Generate.Productions
{
    public class ProductionElement
    {
        private string prodOrtoken, fieldName, propertyName;
        private ElementTypes type;

        public ProductionElement(PElement element)
        {
            TIdentifier typeId = element.PElementid.TIdentifier;
            this.prodOrtoken = (typeId.IsToken ? 
                "T" + SablePP.Compiler.CommonMethods.ToCamelCase(typeId.AsToken.Name) : 
                "P" + SablePP.Compiler.CommonMethods.ToCamelCase(typeId.AsProduction.Name));

            this.fieldName = "_" + element.LowerName + "_";
            this.propertyName = SablePP.Compiler.CommonMethods.ToCamelCase(element.LowerName);
            this.type = element.GetElementType();
        }
        public ProductionElement(string productionOrTokenClass, string fieldName, string propertyName, ElementTypes elementType)
        {
            this.prodOrtoken = productionOrTokenClass;
            this.fieldName = fieldName;
            this.propertyName = propertyName;
            this.type = elementType;
        }

        public string ProductionOrTokenClass
        {
            get { return prodOrtoken; }
        }

        public string FieldName
        {
            get { return fieldName; }
        }
        public string PropertyName
        {
            get { return propertyName; }
        }

        public ElementTypes ElementType
        {
            get { return type; }
        }

        public override string ToString()
        {
            return PropertyName + " : " + ElementType;
        }
    }
}
