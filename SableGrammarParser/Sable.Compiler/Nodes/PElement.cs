namespace Sable.Compiler.node
{
    public partial class PElement
    {
        public string LowerName
        {
            get
            {
                PElementname name = Elementname;
                PElementid id = Elementid;
                if (name != null && name is AElementname)
                    return (name as AElementname).GetName().Text;
                else
                    return id.Identifier.Text;
            }
        }

        protected abstract PElementid Elementid
        {
            get;
        }
        protected abstract PElementname Elementname
        {
            get;
        }
    }
}
