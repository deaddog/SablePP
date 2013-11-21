namespace SablePP.Compiler.Nodes
{
    public partial class PElementid
    {
        public TIdentifier TIdentifier 
        {
            get { return ((dynamic)this).Identifier; }
        }
    }
}
