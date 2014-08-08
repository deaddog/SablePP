namespace SablePP.Compiler.Nodes
{
   public partial class AListTranslation
    {
        public override string ClassName
        {
            get { return Elements[0].ClassName; }
        }

        public override bool IsList
        {
            get { return true; }
        }
    }
}
