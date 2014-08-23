﻿using SablePP.Generate.Translations;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate
{
    public class Alternative
    {
        private Element[] elements;
        private Translation translation;

        public Alternative(IEnumerable<Element> elements, Translation translation)
        {
            this.elements = elements.ToArray();
            this.translation = translation;
        }

        public Element[] Elements
        {
            get { return elements; }
        }

        public Translation Translation
        {
            get { return translation; }
        }

        public abstract class Element
        {
            private Modifiers? modifier;

            public Element(Modifiers? modifier)
            {
                this.modifier = modifier;
            }

            public Modifiers? Modifier
            {
                get { return modifier; }
            }
        }

        public class TokenElement : Element
        {
            private Token token;

            public TokenElement(Token token)
                : base(null)
            {
                this.token = token;
            }
            public TokenElement(Token token, Modifiers modifier)
                : base(modifier)
            {
                this.token = token;
            }

            public Token Token
            {
                get { return token; }
            }
        }

        public class ProductionElement : Element
        {
            private AbstractProduction production;

            public ProductionElement(AbstractProduction production)
                : base(null)
            {
                this.production = production;
            }
            public ProductionElement(AbstractProduction production, Modifiers modifier)
                : base(modifier)
            {
                this.production = production;
            }

            public AbstractProduction Production
            {
                get { return production; }
            }
        }
    }
}
