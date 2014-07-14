namespace SablePP.Compiler.Nodes.Identifiers
{
    public class TokenIdentifier : TIdentifier
    {
        private PToken token;

        public TokenIdentifier(TIdentifier identifier, PToken token)
            :base(identifier)
        {
            this.token = token;
        }

        public PToken Declaration
        {
            get { return token; }
        }
    }
}
