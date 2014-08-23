using System;

namespace SablePP.Generate.Translations
{
    public class ElementTranslation
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
    }
}
