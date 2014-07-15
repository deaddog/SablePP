namespace SablePP.Compiler.Nodes.Identifiers
{
    public class ProductionIdentifier : DeclarationIdentifier<PProduction>
    {
        public ProductionIdentifier(TIdentifier identifier, PProduction production)
            : base(identifier, production)
        {
        }
    }
}
