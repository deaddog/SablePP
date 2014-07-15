using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;
using System;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class AlternativesTable : DeclarationTable<AlternativeIdentifier, PAlternative>
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
}
