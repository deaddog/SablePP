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
        private HelpersTable helpers;
        private DeclarationTable<DState> states;
        private DeclarationTable<DToken> tokens;
        private DeclarationTable<DProduction> productions;
        private DeclarationTable<DProduction> astProductions;
        private Dictionary<string, DHighlightRule> highlight;

        public DeclarationTables()
        {
            bool firstProduction = true;
            bool firstASTProduction = true;

            this.helpers = new HelpersTable();
            this.states = new DeclarationTable<DState>(id => new DState(id));
            this.tokens = new DeclarationTable<DToken>(id => new DToken(id));
            this.productions = new DeclarationTable<DProduction>(id => { var p = new DProduction(id, firstProduction); firstProduction = false; return p; });
            this.astProductions = new DeclarationTable<DProduction>(id => { var p = new DProduction(id, firstASTProduction); firstASTProduction = false; return p; });
            this.highlight = new Dictionary<string, DHighlightRule>();
        }

        public HelpersTable Helpers
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

        public class HelpersTable : Table<HelperIdentifier, PHelper>
        {
            protected override HelperIdentifier construct(TIdentifier identifier, PHelper declaration)
            {
                return new HelperIdentifier(identifier, declaration);
            }

            protected override TIdentifier getIdentifier(PHelper declaration)
            {
                return declaration.Identifier;
            }
        }

        public class StatesTable
        {
            private Dictionary<string, StateIdentifier> declarations;
            private List<StateIdentifier> unusedList;

            public StatesTable()
            {
                this.declarations = new Dictionary<string, StateIdentifier>();
                this.unusedList = new List<StateIdentifier>();
            }

            public StateIdentifier this[string text]
            {
                get { return declarations[text]; }
            }

            public bool Declare(TIdentifier declaration)
            {
                string text = declaration.Text;

                if (declarations.ContainsKey(text))
                    return false;
                else
                {
                    StateIdentifier reference = new StateIdentifier(declaration, declarations.Count == 0);
                    declaration.ReplaceBy(reference);
                    declarations.Add(text, reference);

                    if (!reference.IsFirst)
                        unusedList.Add(reference);

                    return true;
                }
            }

            public bool Link(TIdentifier identifier)
            {
                StateIdentifier declaration = null;
                if (declarations.TryGetValue(identifier.Text, out declaration))
                {
                    StateIdentifier reference = new StateIdentifier(identifier, declaration);
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

            public IEnumerable<StateIdentifier> NonLinked
            {
                get
                {
                    foreach (var d in unusedList)
                        yield return d;
                }
            }
        }

        public abstract class Table<TID, TDeclaration>
            where TID : DeclarationIdentifier<TDeclaration>
            where TDeclaration : SablePP.Tools.Nodes.Production
        {
            private Dictionary<string, TDeclaration> declarations;
            private List<TDeclaration> unusedList;

            public Table()
            {
                this.declarations = new Dictionary<string, TDeclaration>();
                this.unusedList = new List<TDeclaration>();
            }

            public TDeclaration this[string text]
            {
                get { return declarations[text]; }
            }

            protected abstract TID construct(TIdentifier identifier, TDeclaration declaration);
            protected abstract TIdentifier getIdentifier(TDeclaration declaration);

            public bool Declare(TDeclaration declaration)
            {
                TIdentifier identifier = getIdentifier(declaration);
                string text = identifier.Text;

                if (declarations.ContainsKey(text))
                    return false;
                else
                {
                    TID reference = construct(identifier, declaration);
                    identifier.ReplaceBy(reference);
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
                    TID reference = construct(identifier, declaration);
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

            public IEnumerable<TDeclaration> NonLinked
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
