using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class ProductionsTable : DeclarationTable<PProduction>
    {
        protected override DeclarationIdentifier<PProduction> construct(TIdentifier identifier, PProduction declaration)
        {
            return new DeclarationIdentifier<PProduction>(identifier, declaration);
        }
    }
}
