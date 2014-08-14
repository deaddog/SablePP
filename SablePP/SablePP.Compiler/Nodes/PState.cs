namespace SablePP.Compiler.Nodes
{
    public partial class PState
    {
        public bool IsFirst
        {
            get
            {
                var par = this.GetFirstParent<PStates>();
                return ReferenceEquals(par.States[0], this);
            }
        }

        public string LexerName
        {
            get { return _identifier_.Text.ToUpper(); }
        }
    }
}
