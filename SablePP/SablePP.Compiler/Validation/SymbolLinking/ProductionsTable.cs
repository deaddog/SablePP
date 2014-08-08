using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class ProductionsTable : DeclarationTable<PProduction>
    {
        protected override DeclarationIdentifier<PProduction> construct(TIdentifier identifier, PProduction declaration)
        {
            return new DeclarationIdentifier<PProduction>(identifier, declaration);
        }

        protected override TIdentifier getIdentifier(PProduction declaration)
        {
            return declaration.Identifier;
        }
    }
}
