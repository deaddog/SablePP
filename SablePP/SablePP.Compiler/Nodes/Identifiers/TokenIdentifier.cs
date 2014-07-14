namespace SablePP.Compiler.Nodes.Identifiers
{
    public class TokenIdentifier : DeclarationIdentifier<PToken>
    {
        public TokenIdentifier(TIdentifier identifier, PToken token)
            : base(identifier, token)
        {
        }
    }
}
