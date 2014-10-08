using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SablePP.Generate
{
    public class Grammar : GrammarPart
    {
        private string @namespace;
        private Helper[] helpers;
        private State[] states;
        private Token[] tokens;
        private Production[] productions;
        private AbstractProduction[] abstractProductions;
        private Highlighting[] highlighting;

        public Grammar(string @namespace,
            IEnumerable<Helper> helpers,
            IEnumerable<State> states,
            IEnumerable<Token> tokens,
            IEnumerable<Production> productions,
            IEnumerable<AbstractProduction> abstractProductions,
            IEnumerable<Highlighting> highlighting)
        {
            this.@namespace = @namespace;

            this.helpers = helpers.ToArray();
            foreach (var h in this.helpers)
                h.parent = this;

            this.states = states.ToArray();
            this.tokens = tokens.ToArray();
            this.productions = productions.ToArray();
            this.abstractProductions = abstractProductions.ToArray();
            this.highlighting = highlighting.ToArray();
        }

        public CompilationResult Compile()
        {
            return SablePP.Generate.SableCC.Compiler.ValidateWithSableCC(this);
        }

        internal override bool canBeParent(GrammarPart part)
        {
            return false;
        }

        public string Namespace
        {
            get { return @namespace; }
        }
        public Helper[] Helpers
        {
            get { return helpers; }
        }
        public State[] States
        {
            get { return states; }
        }
        public Token[] Tokens
        {
            get { return tokens; }
        }
        public Production[] Productions
        {
            get { return productions; }
        }
        public AbstractProduction[] AbstractProductions
        {
            get { return abstractProductions; }
        }
        public Highlighting[] HighlightingRules
        {
            get { return highlighting; }
        }
    }
}
