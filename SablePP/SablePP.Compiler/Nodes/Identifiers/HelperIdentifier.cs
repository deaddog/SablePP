namespace SablePP.Compiler.Nodes.Identifiers
{
    public class HelperIdentifier : TIdentifier
    {
        private PHelper helper;

        public HelperIdentifier(TIdentifier identifier, PHelper helper)
            :base(identifier)
        {
            this.helper = helper;
        }

        public PHelper Declaration
        {
            get { return helper; }
        }
    }
}
