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
    }
}
