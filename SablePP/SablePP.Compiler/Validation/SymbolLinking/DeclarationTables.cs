using SablePP.Compiler.Nodes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class DeclarationTables
    {
        private DeclarationTable<DHelper> helpers;
        private DeclarationTable<DState> states;
        private DeclarationTable<DToken> tokens;
        private Dictionary<string, DProduction> productions;
        private Dictionary<string, DProduction> astProductions;
        private Dictionary<string, DHighlightRule> highlight;

        public DeclarationTables()
        {
            this.helpers = new DeclarationTable<DHelper>(id => new DHelper(id));
            this.states = new DeclarationTable<DState>(id => new DState(id));
            this.tokens = new DeclarationTable<DToken>(id => new DToken(id));
            this.productions = new Dictionary<string, DProduction>();
            this.astProductions = new Dictionary<string, DProduction>();
            this.highlight = new Dictionary<string, DHighlightRule>();
        }

        public DeclarationTable<DHelper> Helpers
        {
            get { return helpers; }
        }
        public DeclarationTable<DState> States
        {
            get { return states; }
        }
        public DeclarationTable<DToken> Tokens
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

        public class DeclarationTable<TDeclaration> where TDeclaration : Declaration
        {
            private Func<TIdentifier, TDeclaration> construct;
            private Dictionary<string, TDeclaration> declarations;
            private List<TDeclaration> unusedList;

            public DeclarationTable(Func<TIdentifier, TDeclaration> construct)
            {
                this.construct = construct;
                this.declarations = new Dictionary<string, TDeclaration>();
                this.unusedList = new List<TDeclaration>();
            }

            public TDeclaration this[TIdentifier identifier]
            {
                get { return this[identifier.Text]; }
            }
            public TDeclaration this[string text]
            {
                get { return declarations[text]; }
            }

            public bool Declare(TIdentifier identifier)
            {
                string text = identifier.Text;

                if (declarations.ContainsKey(text))
                    return false;
                else
                {
                    TDeclaration declaration = construct(identifier);
                    identifier.SetDeclaration(declaration);

                    declarations.Add(text, declaration);
                    unusedList.Add(declaration);

                    return true;
                }
            }

            public bool Link(TIdentifier identifier)
            {
                TDeclaration declaration = null;
                if (declarations.TryGetValue(identifier.Text, out declaration))
                {
                    identifier.SetDeclaration(declaration);
                    unusedList.Remove(declaration);

                    return true;
                }
                else
                    return false;
            }

            public IEnumerable<TDeclaration> NonLinked
            {
                get
                {
                    foreach (var d in unusedList)
                        yield return d;
                }
            }
        }
    }
}
