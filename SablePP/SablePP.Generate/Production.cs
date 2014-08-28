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
            private Token token;
            private Modifiers? modifier;

            public ProductionTranslation(Token token, Modifiers? modifier)
            {
                if (token == null)
                    throw new ArgumentNullException("token");

                this.production = null;
                this.token = token;
                this.modifier = modifier;
            }
            public ProductionTranslation(AbstractProduction production, Modifiers? modifier)
            {
                if (production == null)
                    throw new ArgumentNullException("production");

                this.production = production;
                this.token = null;
                this.modifier = modifier;
            }

            public bool HasProduction
            {
                get { return production != null; }
            }
            public bool HasToken
            {
                get { return token != null; }
            }

            public AbstractProduction Production
            {
                get { return production; }
            }
            public Token Token
            {
                get { return token; }
            }

            public Modifiers? Modifier
            {
                get { return modifier; }
            }
        }
    }
}
