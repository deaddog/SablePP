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
            var _package = node.PackageName;
            var _helpers = node.HasHelpers ? Visit(node.Helpers).ToArray() : new Helper[0];
            var _states = node.HasStates ? Visit(node.States).ToArray() : new State[0];
            var _tokens = node.HasTokens ? Visit(node.Tokens).ToArray() : new Token[0];

            foreach (var p in node.Productions.Productions)
            {
                string name = "P" + p.Identifier.Text.ToCamelCase();
                AbstractProduction abs = new AbstractProduction(name);

                var prod = new Production(new Production.ProductionTranslation(abs, Modifiers.Single));
                productions.Add(p, prod);
                abstractProductions.Add(prod, abs);
            }

            var _productions = node.HasProductions ? Visit(node.Productions).ToArray() : new Production[0];
            var _styles = node.HasHighlightrules ? Visit(node.Highlightrules).ToArray() : new Highlighting[0];

            return new Grammar(_package, _helpers, _states, _tokens, _productions, abstractProductions.Values, _styles);
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
            throw new NotImplementedException();
        }
        public Alternative.Element Visit(PElement node)
        {
            throw new NotImplementedException();
        }
    }
}
