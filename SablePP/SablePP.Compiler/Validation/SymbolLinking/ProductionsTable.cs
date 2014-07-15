using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class ProductionsTable : DeclarationTable<ProductionIdentifier, PProduction>
    {
        protected override ProductionIdentifier construct(TIdentifier identifier, PProduction declaration)
        {
            return new ProductionIdentifier(identifier, declaration);
        }

        protected override TIdentifier getIdentifier(PProduction declaration)
        {
            return declaration.Identifier;
        }
    }
}
