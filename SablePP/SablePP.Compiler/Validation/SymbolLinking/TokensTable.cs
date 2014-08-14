using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class TokensTable : DeclarationTable<PToken>
    {
        protected override DeclarationIdentifier<PToken> construct(TIdentifier identifier, PToken declaration)
        {
            return new DeclarationIdentifier<PToken>(identifier, declaration);
        }

        protected override TIdentifier getIdentifier(PToken declaration)
        {
            return declaration.Identifier;
        }
    }
}
