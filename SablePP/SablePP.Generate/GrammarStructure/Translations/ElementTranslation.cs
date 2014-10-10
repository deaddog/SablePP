using System;

namespace SablePP.Generate.Translations
{
    public class ElementTranslation : Translation
    {
        private Alternative.Element element;

        public ElementTranslation(Alternative.Element element)
        {
            if (element == null)
                throw new ArgumentNullException("null");

            this.element = element;
        }

        public Alternative.Element Element
        {
            get { return element; }
        }

        public override string GetListElementType()
        {
            if (element is Alternative.TokenElement)
                return (element as Alternative.TokenElement).Token.Name;
            else
            {
                var production = (element as Alternative.ProductionElement).Production;
                if (production.Translation.HasToken)
                    return production.Translation.Token.Name;
                else
                    return production.Translation.Production.Name;
            }
        }
        public override bool GeneratesList()
        {
            return element.GeneratesList();
        }
    }
}
