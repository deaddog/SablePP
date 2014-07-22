namespace SablePP.Compiler.Nodes
{
    public partial class PProduction
    {
        public bool IsFirst
        {
            get
            {
                var par = this.GetParent();
                if (par is PProductions)
                    return ReferenceEquals((par as PProductions).Productions[0], this);
                else if (par is PAstproductions)
                    return ReferenceEquals((par as PAstproductions).Productions[0], this);
                else
                    return false;
            }
        }
        public string ClassName
        {
            get { return "P" + this.Identifier.Text.ToCamelCase(); }
        }
    }
}
