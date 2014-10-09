﻿using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate
{
    public class AbstractAlternative : GrammarPart
    {
        private string name;
        private Element[] elements;
        private AbstractProduction production;

        public AbstractAlternative(string name, IEnumerable<Element> elements)
        {
            this.name = name;
            this.elements = elements.ToArray();
        }

        internal override bool canBeParent(GrammarPart part)
        {
            return part is AbstractProduction;
        }
        public AbstractProduction Parent
        {
            get { return base.parent as AbstractProduction; }
        }

        public string Name
        {
            get { return name; }
        }
        public Element[] Elements
        {
            get { return elements; }
        }
        public AbstractProduction Production
        {
            get { return production; }
            internal set { production = value; }
        }

        public abstract class Element
        {
            private string name;
            private Modifiers modifier;

            public Element(string name, Modifiers modifier)
            {
                this.name = name;
                this.modifier = modifier;
            }

            public string Name
            {
                get { return name; }
            }

            public Modifiers Modifier
            {
                get { return modifier; }
            }
        }

        public class TokenElement : Element
        {
            private Token token;

            public TokenElement(string name, Token token, Modifiers modifier)
                : base(name, modifier)
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

            public ProductionElement(string name, AbstractProduction production, Modifiers modifier)
                : base(name, modifier)
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
