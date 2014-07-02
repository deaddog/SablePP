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
                    return Elementid.Identifier.Text;
            }
        }

        public ElementTypes GetElementType()
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
}
