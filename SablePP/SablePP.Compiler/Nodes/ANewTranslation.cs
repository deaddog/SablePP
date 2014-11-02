namespace SablePP.Compiler.Nodes
{
    public partial class ANewTranslation
    {
        public override string ClassName
        {
            get { return Production.AsPProduction.ClassName; }
        }

        public override bool IsList
        {
            get { return false; }
        }
    }
}
