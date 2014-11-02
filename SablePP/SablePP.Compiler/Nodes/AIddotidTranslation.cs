namespace SablePP.Compiler.Nodes
{
   public partial class AIddotidTranslation
   {
       public override string ClassName
       {
           get { return Production.AsPProduction.ClassName; }
       }

       public override bool IsList
       {
           get { return Identifier.AsPElement.GeneratesAsList; }
       }
    }
}
