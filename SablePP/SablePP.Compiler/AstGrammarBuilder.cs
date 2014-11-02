using SablePP.Compiler.Nodes;
using SablePP.Generate;
using SablePP.Generate.RegularExpressions;
using SablePP.Generate.Translations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SablePP.Compiler
{
    public class AstGrammarBuilder : GrammarBuilder
    {
        private Dictionary<PProduction, Production> productions;
        private Dictionary<PElement, Alternative.Element> elements;

        private Dictionary<PProduction, AbstractProduction> abstractProductions;
        private Dictionary<PAlternative, AbstractAlternative> abstractAlternatives;

        internal AstGrammarBuilder()
        {
            this.productions = new Dictionary<PProduction, Production>();
            this.elements = new Dictionary<PElement, Alternative.Element>();

            this.abstractProductions = new Dictionary<PProduction, AbstractProduction>();
            this.abstractAlternatives = new Dictionary<PAlternative, AbstractAlternative>();
        }

        public override Grammar Visit(AGrammar node)
        {
            var _package = node.PackageName;
            var _helpers = node.HasHelpers ? Visit(node.Helpers).ToArray() : new Helper[0];
            var _states = node.HasStates ? Visit(node.States).ToArray() : new State[0];
            var _tokens = node.HasTokens ? Visit(node.Tokens).ToArray() : new Token[0];

            foreach (var p in node.Astproductions.Productions)
            {
                string name = "P" + p.Identifier.Text.ToCamelCase();
                AbstractProduction prod = new AbstractProduction(name);
                abstractProductions.Add(p, prod);
            }

            var _absProds = node.HasAstproductions ? VisitAbstract(node.Astproductions).ToArray() : new AbstractProduction[0];

            foreach (var p in node.Productions.Productions)
            {
                Production prod;
                if (p.HasProdtranslation)
                    prod = new Production(Visit(p.Prodtranslation));
                else
                {
                    var target = p.AstTarget;
                    if (target.IsToken)
                        prod = new Production(new Production.ProductionTranslation(tokens[target.Token], target.Modifier));
                    else if (target.IsProduction)
                        prod = new Production(new Production.ProductionTranslation(abstractProductions[target.Production], target.Modifier));
                    else
                        throw new InvalidOperationException("Invalid production target.");
                }
                productions.Add(p, prod);
            }

            var _productions = node.HasProductions ? Visit(node.Productions).ToArray() : new Production[0];
            var _styles = node.HasHighlightrules ? Visit(node.Highlightrules).ToArray() : new Highlighting[0];

            return new Grammar(_package, _helpers, _states, _tokens, _productions, _absProds, _styles);
        }

        #region Productions

        public Production.ProductionTranslation Visit(PProdtranslation node)
        {
            Modifiers mod = node.Modifier.GetModifier();

            if (node.Identifier.IsPProduction)
                return new Production.ProductionTranslation(abstractProductions[node.Identifier.AsPProduction], mod);
            else if (node.Identifier.IsPToken)
                return new Production.ProductionTranslation(tokens[node.Identifier.AsPToken], mod);
            else
                throw new ArgumentException("Production translation must be to either an ast node or a token.");
        }

        public IEnumerable<AbstractProduction> VisitAbstract(PAstproductions node)
        {
            return from p in node.Productions select VisitAbstract(p);
        }
        public AbstractProduction VisitAbstract(PProduction node)
        {
            var prod = abstractProductions[node];

            prod.Alternatives.AddRange(from a in node.Alternatives select VisitAbstract(a));

            return prod;
        }

        public AbstractAlternative VisitAbstract(PAlternative node)
        {
            string name = node.Production.Identifier.Text.ToCamelCase();
            if (node.HasAlternativename)
                name = node.Alternativename.Name.Text.ToCamelCase() + name;
            name = "A" + name;

            AbstractAlternative alt = new AbstractAlternative(name, from e in node.Elements select VisitAbstract(e));
            abstractAlternatives.Add(node, alt);
            return alt;
        }
        public AbstractAlternative.Element VisitAbstract(PElement node)
        {
            string name = node.Elementid.Identifier.Text.ToCamelCase();

            if (node.HasElementname)
                name = node.Elementname.Name.Text;
            else if (node.IsList)
                name += "s";

            var mod = node.Modifier.GetModifier();
            var id = node.Elementid.Identifier;

            if (id.IsPProduction)
                return new AbstractAlternative.ProductionElement(name.ToCamelCase(), abstractProductions[id.AsPProduction], mod);
            else if (id.IsPToken)
                return new AbstractAlternative.TokenElement(name.ToCamelCase(), tokens[id.AsPToken], mod);
            else
                throw new ArgumentException("Element must must refer to either an ast node or a token.");
        }

        public IEnumerable<Production> Visit(PProductions node)
        {
            return from p in node.Productions select Visit(p);
        }
        public Production Visit(PProduction node)
        {
            var prod = productions[node];

            prod.Alternatives.AddRange(from a in node.Alternatives select Visit(a));

            return prod;
        }

        public Alternative Visit(PAlternative node)
        {
            var elements = new Alternative.Element[node.Elements.Count];

            for (int i = 0; i < elements.Length; i++)
            {
                var e = node.Elements[i];
                elements[i] = Visit(e);
                this.elements.Add(e, elements[i]);
            }

            if (node.HasTranslation)
                return new Alternative(elements, Visit(node.Translation));
            else
            {
                var translations = new Translation[elements.Length];

                for (int i = 0; i < translations.Length; i++)
                {
                    translations[i] = new ElementTranslation(elements[i]);
                    if (elements[i].Modifier == Modifiers.OneOrMany || elements[i].Modifier == Modifiers.ZeroOrMany)
                        translations[i] = new ListTranslation(new Translation[] { translations[i] });
                }

                var newTranslation = new NewTranslation(abstractAlternatives[node.AstTarget.Alternative], translations);

                return new Alternative(elements, newTranslation);
            }
        }
        public Alternative.Element Visit(PElement node)
        {
            var mod = node.Modifier.GetModifier();

            if (node.Elementid.Identifier.IsPToken)
            {
                var token = tokens[node.Elementid.Identifier.AsPToken];
                return new Alternative.TokenElement(token, mod);
            }
            else if (node.Elementid.Identifier.IsPProduction)
            {
                var prod = productions[node.Elementid.Identifier.AsPProduction];
                return new Alternative.ProductionElement(prod, mod);
            }
            else
                throw new InvalidOperationException("Unknown element target.");
        }

        #endregion

        #region Translations

        public Translation Visit(PTranslation node)
        {
            return Visit((dynamic)node);
        }

        public Translation Visit(AFullTranslation node)
        {
            return Visit(node.Translation);
        }
        public Translation Visit(ANewTranslation node)
        {
            return new NewTranslation(abstractAlternatives[node.Target.Alternative], from t in node.Arguments select Visit(t));
        }
        public Translation Visit(ANewalternativeTranslation node)
        {
            return new NewTranslation(abstractAlternatives[node.Target.Alternative], from t in node.Arguments select Visit(t));
        }
        public Translation Visit(AListTranslation node)
        {
            return new ListTranslation(from t in node.Elements select Visit(t));
        }
        public Translation Visit(ANullTranslation node)
        {
            return new NullTranslation();
        }
        public Translation Visit(AIdTranslation node)
        {
            return new ElementTranslation(elements[node.Identifier.AsPElement]);
        }
        public Translation Visit(AIddotidTranslation node)
        {
            return new ElementTranslation(elements[node.Identifier.AsPElement]);
        }

        #endregion
    }
}
