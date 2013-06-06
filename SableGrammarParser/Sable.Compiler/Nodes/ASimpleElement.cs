namespace Sable.Compiler.node
{
    public partial class ASimpleElement
    {
        protected override PElementid Elementid
        {
            get { return GetElementid(); }
        }
        protected override PElementname Elementname
        {
            get { return GetElementname(); }
        }
    }
}
