using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class TokensTable : Table<TokenIdentifier, PToken>
    {
        protected override TokenIdentifier construct(TIdentifier identifier, PToken declaration)
        {
            return new TokenIdentifier(identifier, declaration);
        }

        protected override TIdentifier getIdentifier(PToken declaration)
        {
            return declaration.Identifier;
        }
    }
}
