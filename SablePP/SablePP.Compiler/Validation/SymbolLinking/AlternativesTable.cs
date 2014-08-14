using SablePP.Compiler.Nodes;
using System;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class AlternativesTable : DeclarationTable<PAlternative>
    {
        protected override DeclarationIdentifier<PAlternative> construct(TIdentifier identifier, PAlternative declaration)
        {
            return new DeclarationIdentifier<PAlternative>(identifier, declaration);
        }
    }
}
