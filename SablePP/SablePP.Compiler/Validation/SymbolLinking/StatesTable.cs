using SablePP.Compiler.Nodes;
namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class StatesTable : DeclarationTable<PState>
    {
        protected override DeclarationIdentifier<PState> construct(TIdentifier identifier, PState declaration)
        {
            return new DeclarationIdentifier<PState>(identifier, declaration);
        }
    }
}
