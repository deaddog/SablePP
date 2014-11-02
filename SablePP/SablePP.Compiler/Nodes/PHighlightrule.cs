namespace SablePP.Compiler.Nodes
{
    public partial class PHighlightrule : IDeclaration
    {
        public TIdentifier GetIdentifier()
        {
            return Name;
        }
    }
}
