namespace SablePP.Compiler.Nodes.Identifiers
{
    public class AlternativeIdentifier : DeclarationIdentifier<PAlternative>
    {
        public AlternativeIdentifier(TIdentifier identifier, PAlternative alternative)
            : base(identifier, alternative)
        {
        }
    }
}
