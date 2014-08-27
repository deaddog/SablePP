using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SablePP.Generate
{
    public class Production
    {
        private ProductionTranslation translation;
        private AddOnlyList<Alternative> alternatives;

        public Production(ProductionTranslation translation)
            : this(translation, null)
        {
        }

        public Production(ProductionTranslation translation, IEnumerable<Alternative> alternatives)
        {
            this.translation = translation;
            if (alternatives == null)
                this.alternatives = new AddOnlyList<Alternative>();
            else
                this.alternatives = new AddOnlyList<Alternative>(alternatives);
        }

        public ProductionTranslation Translation
        {
            get { return translation; }
        }

        public AddOnlyList<Alternative> Alternatives
        {
            get { return alternatives; }
        }

        public class ProductionTranslation
        {
            private AbstractProduction production;
            private Modifiers? modifier;

            public ProductionTranslation(AbstractProduction production, Modifiers? modifier)
            {
                this.production = production;
                this.modifier = modifier;
            }

            public AbstractProduction Production
            {
                get { return production; }
            }
            public Modifiers? Modifier
            {
                get { return modifier; }
            }
        }
    }
}
