using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SablePP.Generate
{
    public class Grammar
    {
        private string packageName;
        private Helper[] helpers;
        private State[] states;
        private Token[] tokens;
        private Production[] productions;
        private AbstractProduction[] abstractProductions;

        public Grammar(string packageName, IEnumerable<Helper> helpers, IEnumerable<State> states, IEnumerable<Token> tokens, IEnumerable<Production> productions, IEnumerable<AbstractProduction> abstractProductions)
        {
            this.packageName = packageName;
            this.helpers = helpers.ToArray();
            this.states = states.ToArray();
            this.tokens = tokens.ToArray();
            this.productions = productions.ToArray();
            this.abstractProductions = abstractProductions.ToArray();
        }

        public string PackageName
        {
            get { return packageName; }
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
    }
}
