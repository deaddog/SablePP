using System;

namespace SablePP.Compiler.Nodes
{
    public partial class AListTranslation
    {
        public override string ClassName
        {
            get
            {
                string nestedName = getNestedClassName();
                if (nestedName != null)
                    return nestedName;

                var parent = this.GetParent();

                if (parent is ANewTranslation)
                    nestedName = classFromParent(parent as ANewTranslation);
                else if (parent is ANewalternativeTranslation)
                    nestedName = classFromParent(parent as ANewalternativeTranslation);
                else if (parent is AFullTranslation)
                    nestedName = classFromParent(parent as AFullTranslation);
                else
                    throw new InvalidOperationException();

                return nestedName;
            }
        }

        private string getNestedClassName()
        {
            if (Elements.Count == 0)
                return null;
            else if (Elements[0] is AListTranslation)
                return (Elements[0] as AListTranslation).getNestedClassName();
            else
                return Elements[0].ClassName;
        }

        private string classFromParent(ANewTranslation parent)
        {
            var index = parent.Arguments.IndexOf(this);
            var alt = parent.Production.AsPProduction.UnnamedAlternative;
            return alt.Elements[index].ClassName;
        }
        private string classFromParent(ANewalternativeTranslation parent)
        {
            var index = parent.Arguments.IndexOf(this);
            return parent.Alternative.AsPAlternative.Elements[index].ClassName;
        }
        private string classFromParent(AFullTranslation parent)
        {
            var production = parent.GetFirstParent<PProduction>();
            if (production.HasProdtranslation)
            {
                if (production.Prodtranslation.Identifier.IsPProduction)
                    return production.Prodtranslation.Identifier.AsPProduction.ClassName;
                else
                    return production.Prodtranslation.Identifier.AsPToken.ClassName;
            }
            else
                return production.ClassName;
        }

        public override bool IsList
        {
            get { return true; }
        }
    }
}
