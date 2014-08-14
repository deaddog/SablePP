using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;
using System.Collections.Generic;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class StatesTable : DeclarationTable<PState>
    {
        protected override DeclarationIdentifier<PState> construct(TIdentifier identifier, PState declaration)
        {
            return new DeclarationIdentifier<PState>(identifier, declaration);
        }

        protected override TIdentifier getIdentifier(PState declaration)
        {
            return declaration.Identifier;
        }
    }
}
