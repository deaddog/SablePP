namespace SablePP.Compiler.Nodes.Identifiers
{
    public class HelperIdentifier : DeclarationIdentifier<PHelper>
    {
        public HelperIdentifier(TIdentifier identifier, PHelper helper)
            :base(identifier, helper)
        {
        }
    }
}
