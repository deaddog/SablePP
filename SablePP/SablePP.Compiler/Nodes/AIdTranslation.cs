using System;

namespace SablePP.Compiler.Nodes
{
    public partial class AIdTranslation
    {
        public override string ClassName
        {
            get
            {
                var element = Identifier.AsPElement;
                if (element.Elementid.Identifier.IsPAlternative)
                    return element.Elementid.Identifier.AsPAlternative.Production.ClassName;
                else if (element.Elementid.Identifier.IsPProduction)
                {
                    var p = element.Elementid.Identifier.AsPProduction;
                    if (p != null && p.HasProdtranslation)
                    {
                        var id = p.Prodtranslation.Identifier;
                        if (id.IsPProduction)
                            return id.AsPProduction.ClassName;
                        else if (id.IsPToken)
                            return id.AsPToken.ClassName;
                        else
                            throw new InvalidOperationException();
                    }
                    else
                        return element.Elementid.Identifier.AsPProduction.ClassName;
                }
                else if (element.Elementid.Identifier.IsPToken)
                    return element.Elementid.Identifier.AsPToken.ClassName;
                else
                    throw new System.NotImplementedException();
            }
        }

        public override bool IsList
        {
            get { return Identifier.AsPElement.GeneratesAsList; }
        }
    }
}
