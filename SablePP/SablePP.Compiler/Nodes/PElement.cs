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
            get { return HasModifier && (Modifier is AStarModifier || Modifier is APlusModifier); }
        }

        public ElementTypes ElementType
        {
            get
            {
                if (!HasModifier)
                    return ElementTypes.Simple;
                if (Modifier is AQuestionModifier)
                    return ElementTypes.Question;
                if (Modifier is APlusModifier)
                    return ElementTypes.Plus;
                if (Modifier is AStarModifier)
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
                    {
                        id = prod.Prodtranslation.Identifier;
                        if (id.IsPProduction)
                            return id.AsPProduction.ClassName;
                        else if (id.IsPToken)
                            return id.AsPToken.ClassName;
                        else
                            throw new InvalidOperationException();
                    }
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
