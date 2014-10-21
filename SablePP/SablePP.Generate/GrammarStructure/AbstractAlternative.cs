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
            foreach (var e in this.elements)
                e.parent = this;
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
        private Element[] sharedElements = null;
        public void ClearSharedElements()
        {
            sharedElements = null;
        }

        public Element[] SharedElements
        {
            get
            {
                if (sharedElements == null)
                {
                    var shared = this.Elements.ToList();

                    for (int i = 0; i < production.Alternatives.Count; i++)
                    {
                        var elements = production.Alternatives[i].Elements;

                        for (int s = 0; s < shared.Count; s++)
                        {
                            var t = elements.FirstOrDefault(x => x.Name == shared[s].Name);
                            if (t == null || t.Modifier != shared[s].Modifier)
                                shared.RemoveAt(s--);
                        }
                    }

                    sharedElements = shared.ToArray();
                }

                return sharedElements;
            }
        }
        public Element[] UniqueElements
        {
            get { return Elements.Where(m => !SharedElements.Any(x => x.Name == m.Name)).ToArray(); }
        }
        public AbstractProduction Production
        {
            get { return production; }
            internal set { production = value; }
        }

        public abstract class Element : GrammarPart
        {
            private string name;
            private Modifiers modifier;

            public Element(string name, Modifiers modifier)
            {
                this.name = name;
                this.modifier = modifier;
            }

            internal override bool canBeParent(GrammarPart part)
            {
                return part is AbstractAlternative;
            }
            public AbstractAlternative Parent
            {
                get { return base.parent as AbstractAlternative; }
            }

            public string Name
            {
                get { return name; }
            }

            public abstract string GeneratedName { get; }

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
            public override string GeneratedName
            {
                get { return token.Name; }
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
            public override string GeneratedName
            {
                get { return production.Name; }
            }
        }
    }
}
