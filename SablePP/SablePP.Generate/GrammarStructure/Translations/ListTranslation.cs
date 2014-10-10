using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate.Translations
{
    public class ListTranslation : Translation
    {
        private Translation[] elements;

        public ListTranslation(IEnumerable<Translation> elements)
        {
            this.elements = elements.ToArray();
            foreach (var t in this.elements)
                t.parent = this;
        }

        public Translation[] Elements
        {
            get { return elements; }
        }

        public override string GetListElementType()
        {
            string nestedName = getNestedElementType();

            if (nestedName != null)
                return nestedName;

            return elementTypeFromParent((dynamic)parent);
        }
        public override bool GeneratesList()
        {
            return true;
        }

        private string getNestedElementType()
        {
            if (Elements.Length == 0)
                return null;
            else if (Elements[0] is ListTranslation)
                return (Elements[0] as ListTranslation).getNestedElementType();
            else
                return GetListElementType();
        }

        private string elementTypeFromParent(NewTranslation parent)
        {
            int index = -1;
            for (int i = 0; i < parent.Arguments.Length; i++)
                if (parent.Arguments[i] == this)
                {
                    index = i;
                    break;
                }
            if (index == -1)
                throw new InvalidOperationException();

            var element = parent.Alternative.Elements[index];
            if (element is AbstractAlternative.TokenElement)
                return (element as AbstractAlternative.TokenElement).Token.Name;
            else
                return (element as AbstractAlternative.ProductionElement).Production.Name;
        }
        private string elementTypeFromParent(Alternative parent)
        {
            return parent.Production.Translation.Production.Name;
        }
    }
}
