using SablePP.Generate.Building;
using SablePP.Tools.Generate.CSharp;
using System.Collections.Generic;
using System.Linq;

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
            foreach (var s in this.states)
                s.parent = this;

            this.tokens = tokens.ToArray();
            foreach (var t in this.tokens)
                t.parent = this;

            this.productions = productions.ToArray();
            foreach (var p in this.productions)
                p.parent = this;

            this.abstractProductions = abstractProductions.ToArray();
            foreach (var p in this.abstractProductions)
                p.parent = this;

            this.highlighting = highlighting.ToArray();
            foreach (var h in this.highlighting)
                h.parent = this;
        }

        public CompilationResult Compile()
        {
            return SablePP.Generate.SableCC.Compiler.ValidateWithSableCC(this);
        }

        public FileElement GenerateLexer(CompilationResult result)
        {
            return BLexer.BuildCode(this, result);
        }
        public FileElement GenerateParser(CompilationResult result)
        {
            return BParser.BuildCode(this, result);
        }
        public FileElement GenerateCompilerExecuter()
        {
            return BCompilerExecuter.BuildCode(this);
        }

        public FileElement GenerateTokens()
        {
            return BToken.BuildCode(this);
        }
        public FileElement GenerateProductions()
        {
            return BProduction.BuildCode(this);
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
