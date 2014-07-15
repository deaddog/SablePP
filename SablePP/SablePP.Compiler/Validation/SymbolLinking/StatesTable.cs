using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;
using System.Collections.Generic;

namespace SablePP.Compiler.Validation.SymbolLinking
{
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

}
