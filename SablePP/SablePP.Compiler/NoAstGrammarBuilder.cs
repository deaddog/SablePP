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
    public class NoAstGrammarBuilder : GrammarBuilder
    {
        private Dictionary<PProduction, Production> productions;

        private Dictionary<Production, AbstractProduction> abstractProductions;
        private Dictionary<Alternative, AbstractAlternative> abstractAlternatives;

        internal NoAstGrammarBuilder()
        {
            this.productions = new Dictionary<PProduction, Production>();

            this.abstractProductions = new Dictionary<Production, AbstractProduction>();
            this.abstractAlternatives = new Dictionary<Alternative, AbstractAlternative>();
        }

        public override Grammar Visit(AGrammar node)
        {
            var _namespace = node.Namespace;
            var _helpers = node.HasHelpers ? Visit(node.Helpers).ToArray() : new Helper[0];
            var _states = node.HasStates ? Visit(node.States).ToArray() : new State[0];
            var _tokens = node.HasTokens ? Visit(node.Tokens).ToArray() : new Token[0];

            foreach (var p in node.Productions)
            {
                string name = "P" + p.Identifier.Text.ToCamelCase();
                AbstractProduction abs = new AbstractProduction(name);

                var prod = new Production(new Production.ProductionTranslation(abs, Modifiers.Single));
                productions.Add(p, prod);
                abstractProductions.Add(prod, abs);
            }

            foreach (var p in node.Productions)
                Visit(p);

            var _styles = node.HasHighlightRules ? Visit(node.HighlightRules).ToArray() : new Highlighting[0];

            return new Grammar(_namespace, _helpers, _states, _tokens, productions.Values, abstractProductions.Values, _styles);
        }

        public void Visit(PProduction node)
        {
            var prod = productions[node];
            var abs = abstractProductions[prod];

            foreach (var a in node.Alternatives)
            {
                Alternative alternative;
                AbstractAlternative abstractAlternative;

                Visit(a, out alternative, out abstractAlternative);

                prod.Alternatives.Add(alternative);
                abs.Alternatives.Add(abstractAlternative);
            }
        }

        public void Visit(PAlternative node, out Alternative alternative, out AbstractAlternative absAlternative)
        {
            string name = node.Production.Identifier.Text.ToCamelCase();
            if (node.HasAlternativename)
                name = node.Alternativename.Name.Text.ToCamelCase() + name;
            name = "A" + name;

            var elements = new List<Alternative.Element>();
            var absElements = new List<AbstractAlternative.Element>();
            var transArgs = new List<Translation>();

            foreach (var e in node.Elements)
            {
                Alternative.Element element;
                AbstractAlternative.Element absElement;

                Visit(e, out element, out absElement);
                elements.Add(element);
                absElements.Add(absElement);

                Translation trans = new ElementTranslation(element);
                if (e.IsList)
                    trans = new ListTranslation(new Translation[] { trans });
                transArgs.Add(trans);
            }

            absAlternative = new AbstractAlternative(name, absElements);
            alternative = new Alternative(elements, new NewTranslation(absAlternative, transArgs));
        }
        public void Visit(PElement node, out Alternative.Element element, out AbstractAlternative.Element absElement)
        {
            string name = node.Elementid.Identifier.Text.ToCamelCase();

            if (node.HasElementname)
                name = node.Elementname.Name.Text;
            else if (node.IsList)
                name += "s";

            var mod = node.Modifier.GetModifier();
            var id = node.Elementid.Identifier;

            if (id.IsPProduction)
            {
                var prod = productions[id.AsPProduction];
                element = new Alternative.ProductionElement(prod, mod);
                absElement = new AbstractAlternative.ProductionElement(name.ToCamelCase(), abstractProductions[prod], mod);
            }
            else if (id.IsPToken)
            {
                element = new Alternative.TokenElement(tokens[id.AsPToken], mod);
                absElement = new AbstractAlternative.TokenElement(name.ToCamelCase(), tokens[id.AsPToken], mod);
            }
            else
                throw new ArgumentException("Element must must refer to either an ast node or a token.");
        }
    }
}
