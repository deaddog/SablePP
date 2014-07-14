using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;
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
        private DeclarationTable<DProduction> productions;
        private DeclarationTable<DProduction> astProductions;
        private Dictionary<string, DHighlightRule> highlight;

        public DeclarationTables()
        {
            bool firstProduction = true;
            bool firstASTProduction = true;

            this.helpers = new DeclarationTable<DHelper>(id => new DHelper(id));
            this.states = new DeclarationTable<DState>(id => new DState(id));
            this.tokens = new DeclarationTable<DToken>(id => new DToken(id));
            this.productions = new DeclarationTable<DProduction>(id => { var p = new DProduction(id, firstProduction); firstProduction = false; return p; });
            this.astProductions = new DeclarationTable<DProduction>(id => { var p = new DProduction(id, firstASTProduction); firstASTProduction = false; return p; });
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
        public DeclarationTable<DProduction> Productions
        {
            get { return productions; }
        }
        public DeclarationTable<DProduction> AstProductions
        {
            get { return astProductions; }
        }
        public Dictionary<string, DHighlightRule> HighlightRules
        {
            get { return highlight; }
        }

        public abstract class Table<Tid, TDeclarationType> 
            where Tid : TIdentifier
            where TDeclarationType : SablePP.Tools.Nodes.Production
        {
            private Dictionary<string, TDeclarationType> declarations;
            private List<TDeclarationType> unusedList;

            public TDeclarationType this[string text]
            {
                get { return declarations[text]; }
            }

            protected abstract Tid construct(TIdentifier identifier, TDeclarationType declaration);
            protected abstract TIdentifier getIdentifier(TDeclarationType declaration);

            public bool Declare(TDeclarationType declaration)
            {
                TIdentifier identifier =  getIdentifier(declaration);
                string text = identifier.Text;

                if (declarations.ContainsKey(text))
                    return false;
                else
                {
                    Tid reference = construct(identifier, declaration);
                    identifier.ReplaceBy(reference);
                    unusedList.Remove(declaration);

                    unusedList.Add(declaration);

                    return true;
                }
            }

            public bool Link(TIdentifier identifier)
            {
                TDeclarationType declaration = null;
                if (declarations.TryGetValue(identifier.Text, out declaration))
                {
                    Tid reference = construct(identifier, declaration);
                    identifier.ReplaceBy(reference);
                    unusedList.Remove(declaration);

                    return true;
                }
                else
                    return false;
            }

            public bool Contains(string text)
            {
                return declarations.ContainsKey(text);
            }

            public IEnumerable<TDeclarationType> NonLinked
            {
                get
                {
                    foreach (var d in unusedList)
                        yield return d;
                }
            }
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

            public bool Contains(TIdentifier identifier)
            {
                return Contains(identifier.Text);
            }
            public bool Contains(string text)
            {
                return declarations.ContainsKey(text);
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
