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

        private ProductionElement(PElement element)
        {
            TIdentifier typeId = element.Elementid.Identifier;
            this.prodOrtoken = (typeId.IsToken ?
                "T" + SablePP.Compiler.CommonMethods.ToCamelCase(typeId.AsToken.Name) :
                "P" + SablePP.Compiler.CommonMethods.ToCamelCase(typeId.AsProduction.Name));

            this.fieldName = "_" + element.LowerName + "_";
            this.propertyName = SablePP.Compiler.CommonMethods.ToCamelCase(element.LowerName);
            this.type = element.GetElementType();
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

        private static Dictionary<AProduction, ProductionElement[]> sharedDictionary = new Dictionary<AProduction, ProductionElement[]>();
        private static Dictionary<AAlternative, ProductionElement[]> elementsDictionary = new Dictionary<AAlternative, ProductionElement[]>();

        public static ProductionElement[] GetSharedElements(AProduction node)
        {
            ProductionElement[] temp;
            if (!sharedDictionary.TryGetValue(node, out temp))
            {
                var alternatives = (node.Productionrule as AProductionrule).Alternatives;

                var shared = GetAllElements(alternatives[0] as AAlternative).ToList();

                for (int i = 1; i < alternatives.Count; i++)
                {
                    var elements = GetAllElements(alternatives[i] as AAlternative);

                    for (int s = 0; s < shared.Count; s++)
                    {
                        var t = elements.FirstOrDefault(x => x.PropertyName == shared[s].PropertyName);
                        if (t == null || t.ElementType != shared[s].ElementType)
                            shared.RemoveAt(s--);
                    }
                }
                temp = shared.ToArray();
                sharedDictionary.Add(node, temp);
            }
            return temp;
        }
        public static ProductionElement[] GetSharedElements(AAlternative node)
        {
            return GetSharedElements(node.GetFirstParent<AProduction>());
        }
        public static ProductionElement[] GetUniqueElements(AAlternative node)
        {
            var shared = GetSharedElements(node.GetFirstParent<AProduction>());
            var mine = GetAllElements(node);

            return mine.Where(m => !shared.Any(x => x.propertyName == m.propertyName)).ToArray();
        }
        public static ProductionElement[] GetAllElements(AAlternative node)
        {
            ProductionElement[] temp;
            if (!elementsDictionary.TryGetValue(node, out temp))
            {
                var eP = (node.Elements as AElements).Element;

                PElement[] elements = new PElement[eP.Count];
                eP.CopyTo(elements, 0);

                temp = (from e in elements select new ProductionElement(e)).ToArray();
                elementsDictionary.Add(node, temp);
            }
            return temp;
        }
    }
}
