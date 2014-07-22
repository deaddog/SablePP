using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;
using System;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class AlternativesTable : DeclarationTable<PAlternative>
    {
        protected override DeclarationIdentifier<PAlternative> construct(TIdentifier identifier, PAlternative declaration)
        {
            return new DeclarationIdentifier<PAlternative>(identifier, declaration);
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
