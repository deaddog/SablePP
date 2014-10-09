namespace SablePP.Generate.Translations
{
    public abstract class Translation : GrammarPart
    {
        internal override bool canBeParent(GrammarPart part)
        {
            return part is Alternative || part is Translation;
        }
        public Alternative ParentAlternative
        {
            get { return base.parent as Alternative; }
        }
        public Translation ParentTranslation
        {
            get { return base.parent as Translation; }
        }
    }
}
