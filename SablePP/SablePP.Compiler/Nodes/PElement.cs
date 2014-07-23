using System;

namespace SablePP.Compiler.Nodes
{
    public partial class PElement
    {
        public string LowerName
        {
            get
            {
                if (HasElementname)
                    return Elementname.Name.Text;
                else
                    if (IsList)
                        return Elementid.Identifier.Text + "s";
                    else
                        return Elementid.Identifier.Text;
            }
        }

        public bool IsList
        {
            get { return this is AStarElement || this is APlusElement; }
        }

        public ElementTypes ElementType
        {
            get
            {
                if (this is ASimpleElement)
                    return ElementTypes.Simple;
                if (this is AQuestionElement)
                    return ElementTypes.Question;
                if (this is APlusElement)
                    return ElementTypes.Plus;
                if (this is AStarElement)
                    return ElementTypes.Star;

                throw new ArgumentException("Unknown element type; " + this.GetType().Name, "element");
            }
        }

        /// <summary>
        /// Gets the name of the generated class that this <see cref="PElement"/> refers to.
        /// </summary>
        public string ClassName
        {
            get
            {
                var id = Elementid.Identifier;
                if (id.IsPToken)
                    return id.AsPToken.ClassName;
                else if (id.IsPProduction)
                {
                    var prod = id.AsPProduction;
                    if (prod.HasProdtranslation)
                        return prod.Prodtranslation.Identifier.AsPProduction.ClassName;
                    else
                        return prod.ClassName;
                }
                else if (id.IsPAlternative)
                    return id.AsPAlternative.ClassName;
                else
                    throw new InvalidOperationException();
            }
        }
    }
}
