namespace SablePP.Compiler.Nodes.Identifiers
{
    public class ProductionIdentifier : DeclarationIdentifier<PProduction>
    {
        private bool first;

        public ProductionIdentifier(TIdentifier identifier, PProduction production, bool first)
            : base(identifier, production)
        {
            this.first = first;
        }

        public bool IsFirst
        {
            get { return first; }
        }
    }
}
