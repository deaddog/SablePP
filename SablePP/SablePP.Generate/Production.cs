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
        private Alternative[] alternatives;

        public Production(IEnumerable<Alternative> alternatives)
            : this(null, alternatives)
        {
        }

        public Production(ProductionTranslation translation, IEnumerable<Alternative> alternatives)
        {
            if (alternatives == null)
                throw new ArgumentNullException("alternatives");

            this.translation = translation;
            this.alternatives = alternatives.ToArray();

            if (this.alternatives.Length == 0)
                throw new ArgumentOutOfRangeException("alternatives", "A production must contain at least one alternative.");
        }

        public ProductionTranslation Translation
        {
            get { return translation; }
        }

        public Alternative[] Alternatives
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
