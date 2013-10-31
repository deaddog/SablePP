namespace Sable.Compiler.Nodes
{
    public partial class PElement
    {
        public string LowerName
        {
            get
            {
                PElementname name = PElementname;
                PElementid id = PElementid;
                if (name != null && name is AElementname)
                    return (name as AElementname).GetName().Text;
                else
                    return id.TIdentifier.Text;
            }
        }

        public PElementid PElementid
        {
            get { return ((dynamic)this).Elementid; }
        }
        public abstract PElementname PElementname
        {
            get { return ((dynamic)this).Elementname; }
        }
    }
}
