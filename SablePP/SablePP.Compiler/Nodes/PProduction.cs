namespace SablePP.Compiler.Nodes
{
    public partial class PProduction
    {
        public string ClassName
        {
            get { return "P" + this.Identifier.Text.ToCamelCase(); }
        }
    }
}
