namespace SablePP.Compiler.Nodes
{
    public partial class ANewalternativeTranslation
    {
        public override string ClassName
        {
            get { return Alternative.AsPAlternative.Production.ClassName; }
        }

        public override bool IsList
        {
            get { return false; }
        }
    }
}
