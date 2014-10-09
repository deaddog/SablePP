using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate.Translations
{
    public class NewTranslation : Translation
    {
        private AbstractAlternative alternative;
        private Translation[] arguments;

        public NewTranslation(AbstractAlternative alternative, IEnumerable<Translation> arguments)
        {
            this.alternative = alternative;
            this.arguments = arguments.ToArray();
            foreach (var t in this.arguments)
                t.parent = this;
        }

        public AbstractAlternative Alternative
        {
            get { return alternative; }
        }
        public Translation[] Arguments
        {
            get { return arguments; }
        }
    }
}
