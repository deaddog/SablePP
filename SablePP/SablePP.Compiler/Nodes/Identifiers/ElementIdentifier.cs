namespace SablePP.Compiler.Nodes.Identifiers
{
    public class ElementIdentifier : DeclarationIdentifier<PElement>
    {
        public ElementIdentifier(TIdentifier identifier, PElement element)
            : base(identifier, element)
        {
        }
    }
}
