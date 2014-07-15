namespace SablePP.Compiler.Nodes
{
    public partial class PToken
    {
        private bool? ignored = null;
        public bool IsIgnored
        {
            get { return ignored.HasValue ? ignored.Value : false; }
            set { ignored = value; }
        }
    }
}
