using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public abstract class DeclarationTable<TID, TDeclaration>
        where TID : DeclarationIdentifier<TDeclaration>
        where TDeclaration : SablePP.Tools.Nodes.Production
    {
        private Dictionary<string, TDeclaration> declarations;
        private List<TDeclaration> unusedList;

        public DeclarationTable()
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
