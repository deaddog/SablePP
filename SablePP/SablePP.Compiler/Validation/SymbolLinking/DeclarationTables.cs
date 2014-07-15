﻿using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public static class DeclarationTables
    {
        #region Helpers

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

        #endregion

        #region States

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

        #endregion

        #region Tokens

        public class TokensTable : Table<TokenIdentifier, PToken>
        {
            protected override TokenIdentifier construct(TIdentifier identifier, PToken declaration)
            {
                return new TokenIdentifier(identifier, declaration);
            }

            protected override TIdentifier getIdentifier(PToken declaration)
            {
                return declaration.Identifier;
            }
        }


        #endregion

        #region Productions

        public class ProductionsTable : Table<ProductionIdentifier, PProduction>
        {
            protected override ProductionIdentifier construct(TIdentifier identifier, PProduction declaration)
            {
                return new ProductionIdentifier(identifier, declaration);
            }

            protected override TIdentifier getIdentifier(PProduction declaration)
            {
                return declaration.Identifier;
            }
        }

        public class AlternativesTable : Table<AlternativeIdentifier, PAlternative>
        {
            protected override AlternativeIdentifier construct(TIdentifier identifier, PAlternative declaration)
            {
                return new AlternativeIdentifier(identifier, declaration);
            }

            protected override TIdentifier getIdentifier(PAlternative declaration)
            {
                if (declaration.HasAlternativename)
                    return declaration.Alternativename.Name;
                else
                    throw new ArgumentException("Alternative has no name.", "declaration");
            }
        }

        public class ElementsTable : Table<ElementIdentifier, PElement>
        {
            protected override ElementIdentifier construct(TIdentifier identifier, PElement declaration)
            {
                return new ElementIdentifier(identifier, declaration);
            }

            protected override TIdentifier getIdentifier(PElement declaration)
            {
                if (declaration.HasElementname)
                    return declaration.Elementname.Name;
                else
                    return declaration.Elementid.Identifier;
            }
        }

        #endregion

        #region Highlight rules

        public class HighlightrulesTable : Table<HightlightruleIdentifier, PHighlightrule>
        {
            protected override HightlightruleIdentifier construct(TIdentifier identifier, PHighlightrule declaration)
            {
                return new HightlightruleIdentifier(identifier, declaration);
            }

            protected override TIdentifier getIdentifier(PHighlightrule declaration)
            {
                return declaration.Name;
            }
        }

        #endregion

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

            public void Clear()
            {
                this.declarations.Clear();
                this.unusedList.Clear();
            }

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
    }
}
