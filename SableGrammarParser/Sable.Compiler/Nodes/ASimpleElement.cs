namespace Sable.Compiler.Nodes
{
    public partial class ASimpleElement
    {
        public override PElementid Elementid
        {
            get { return GetElementid(); }
        }
        public override PElementname Elementname
        {
            get { return GetElementname(); }
        }
    }
}
