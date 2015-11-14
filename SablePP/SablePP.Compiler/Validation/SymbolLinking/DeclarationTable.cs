using SablePP.Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class DeclarationTable<TDeclaration> : IDeclarationTable
        where TDeclaration : SablePP.Tools.Nodes.Production, IDeclaration
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
        IDeclaration IDeclarationTable.this[string text] => this[text];

        public bool TryGetValue(string text, out TDeclaration declaration)
        {
            return declarations.TryGetValue(text, out declaration);
        }
        bool IDeclarationTable.TryGetValue(string text, out IDeclaration declaration)
        {
            TDeclaration temp;
            bool res = TryGetValue(text, out temp);
            declaration = temp;
            return res;
        }

        public void Clear()
        {
            this.declarations.Clear();
            this.unusedList.Clear();
        }
        public int Count
        {
            get { return declarations.Count; }
        }

        public bool Declare(TDeclaration declaration)
        {
            TIdentifier identifier = declaration.GetIdentifier();
            string text = identifier.Text;

            if (declarations.ContainsKey(text))
                return false;
            else
            {
                var reference = new DeclarationIdentifier<TDeclaration>(identifier, declaration);
                identifier.ReplaceBy(reference);
                declarations.Add(text, declaration);

                unusedList.Add(declaration);

                return true;
            }
        }
        bool IDeclarationTable.Declare(IDeclaration declaration) => Declare((TDeclaration)declaration);
        public bool Link(TIdentifier identifier)
        {
            TDeclaration declaration = null;
            if (declarations.TryGetValue(identifier.Text, out declaration))
            {
                var reference = new DeclarationIdentifier<TDeclaration>(identifier, declaration);
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

        public IEnumerable<KeyValuePair<string, TDeclaration>> Declarations
        {
            get
            {
                foreach (var kvp in declarations)
                    yield return kvp;
            }
        }
        IEnumerable<KeyValuePair<string, IDeclaration>> IDeclarationTable.Declarations
        {
            get
            {
                foreach (var kvp in declarations)
                    yield return new KeyValuePair<string, IDeclaration>(kvp.Key, kvp.Value);
            }
        }

        public IEnumerable<TDeclaration> UnLinked
        {
            get
            {
                foreach (var d in unusedList)
                    yield return d;
            }
        }
        IEnumerable<IDeclaration> IDeclarationTable.UnLinked
        {
            get
            {
                foreach (var d in unusedList)
                    yield return d;
            }
        }
    }
}
