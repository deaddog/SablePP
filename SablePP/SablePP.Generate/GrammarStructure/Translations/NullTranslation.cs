namespace SablePP.Generate.Translations
{
    public class NullTranslation : Translation
    {
        public override string GetListElementType()
        {
            return null;
        }
        public override bool GeneratesList()
        {
            return false;
        }
    }
}
