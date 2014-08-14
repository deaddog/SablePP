namespace SablePP.Compiler.Nodes
{
    public partial class PHelper : IDeclaration
    {
        public TIdentifier GetIdentifier()
        {
            return Identifier;
        }
    }
}
