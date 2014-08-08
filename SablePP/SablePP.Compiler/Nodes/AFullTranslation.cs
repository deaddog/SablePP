namespace SablePP.Compiler.Nodes
{
    public partial class AFullTranslation
    {
        public override string ClassName
        {
            get { return Translation.ClassName; }
        }

        public override bool IsList
        {
            get { return Translation.IsList; }
        }
    }
}
