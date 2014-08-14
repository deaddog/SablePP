using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class HelpersTable : DeclarationTable<PHelper>
    {
        protected override DeclarationIdentifier<PHelper> construct(TIdentifier identifier, PHelper declaration)
        {
            return new DeclarationIdentifier<PHelper>(identifier, declaration);
        }
    }
}
