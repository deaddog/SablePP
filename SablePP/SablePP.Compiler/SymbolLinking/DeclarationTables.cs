using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.SymbolLinking
{
    public class DeclarationTables
    {
        private Dictionary<string, DHelper> helpers;
        private Dictionary<string, DState> states;
        private Dictionary<string, DToken> tokens;
        private Dictionary<string, DProduction> productions;
        private Dictionary<string, DProduction> astProductions;
        private Dictionary<string, DHighlightRule> highlight;

        public DeclarationTables()
        {
            this.helpers = new Dictionary<string, DHelper>();
            this.states = new Dictionary<string, DState>();
            this.tokens = new Dictionary<string, DToken>();
            this.productions = new Dictionary<string, DProduction>();
            this.astProductions = new Dictionary<string, DProduction>();
            this.highlight = new Dictionary<string, DHighlightRule>();
        }

        public Dictionary<string, DHelper> Helpers
        {
            get { return helpers; }
        }
        public Dictionary<string, DState> States
        {
            get { return states; }
        }
        public Dictionary<string, DToken> Tokens
        {
            get { return tokens; }
        }
        public Dictionary<string, DProduction> Productions
        {
            get { return productions; }
        }
        public Dictionary<string, DProduction> AstProductions
        {
            get { return astProductions; }
        }
        public Dictionary<string, DHighlightRule> HighlightRules
        {
            get { return highlight; }
        }
    }
}
