using SablePP.Generate.Translations;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate
{
    public class Alternative : GrammarPart
    {
        private Element[] elements;
        private Translation translation;
        private Production production;

        public Alternative(IEnumerable<Element> elements, Translation translation)
        {
            this.elements = elements.ToArray();
            foreach (var e in this.elements)
                e.parent = this;

            this.translation = translation;
            this.translation.parent = this;
        }

        internal override bool canBeParent(GrammarPart part)
        {
            return part is Production;
        }
        public Production Parent
        {
            get { return base.parent as Production; }
        }

        public Element[] Elements
        {
            get { return elements; }
        }
        public Translation Translation
        {
            get { return translation; }
        }
        public Production Production
        {
            get { return production; }
            internal set { production = value; }
        }

        public abstract class Element : GrammarPart
        {
            private Modifiers modifier;

            public Element(Modifiers modifier)
            {
                this.modifier = modifier;
            }

            internal override bool canBeParent(GrammarPart part)
            {
                return part is Alternative;
            }
            public Alternative Parent
            {
                get { return base.parent as Alternative; }
            }

            public Modifiers Modifier
            {
                get { return modifier; }
            }

            public abstract string GetGeneratedName();
            public abstract bool GeneratesList();
        }

        public class TokenElement : Element
        {
            private Token token;

            public TokenElement(Token token, Modifiers modifier)
                : base(modifier)
            {
                this.token = token;
            }

            public Token Token
            {
                get { return token; }
            }

            public override string GetGeneratedName()
            {
                return token.Name;
            }
            public override bool GeneratesList()
            {
                return Modifier == Modifiers.OneOrMany || Modifier == Modifiers.ZeroOrMany;
            }
        }

        public class ProductionElement : Element
        {
            private Production production;

            public ProductionElement(Production production, Modifiers modifier)
                : base(modifier)
            {
                this.production = production;
            }

            public Production Production
            {
                get { return production; }
            }

            public override string GetGeneratedName()
            {
                if (production.Translation.HasToken)
                    return production.Translation.Token.Name;
                else
                    return production.Translation.Production.Name;
            }
            public override bool GeneratesList()
            {
                var mod = production.Translation.Modifier;
                return
                    Modifier == Modifiers.OneOrMany ||
                    Modifier == Modifiers.ZeroOrMany ||
                    mod == Modifiers.OneOrMany ||
                    mod == Modifiers.ZeroOrMany;
            }
        }
    }
}
