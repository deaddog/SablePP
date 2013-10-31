namespace Sable.Compiler.Nodes
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

        public abstract PElementid Elementid
        {
            get;
        }
        public abstract PElementname Elementname
        {
            get;
        }
    }
}
