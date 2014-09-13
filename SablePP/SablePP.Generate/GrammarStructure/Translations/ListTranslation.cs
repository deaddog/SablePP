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
        }

        public Translation[] Elements
        {
            get { return elements; }
        }
    }
}
