using SablePP.Compiler.Nodes;
using System.Collections.Generic;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public interface IDeclarationTable
    {
        IDeclaration this[string text] { get; }

        bool TryGetValue(string text, out IDeclaration declaration);

        void Clear();
        int Count { get; }

        bool Declare(IDeclaration declaration);
        bool Link(TIdentifier identifier);

        bool Contains(string text);

        IEnumerable<KeyValuePair<string, IDeclaration>> Declarations { get; }
        IEnumerable<IDeclaration> UnLinked { get; }
    }
}
