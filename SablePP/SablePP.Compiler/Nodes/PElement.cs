using System;

namespace SablePP.Compiler.Nodes
{
    public partial class PElement
    {
        public string LowerName
        {
            get
            {
                PElementname name = PElementname;
                PElementid id = PElementid;
                if (name != null && name is AElementname)
                    return (name as AElementname).Name.Text;
                else
                    return id.TIdentifier.Text;
            }
        }

        public PElementid PElementid
        {
            get { return ((dynamic)this).Elementid; }
        }
        public PElementname PElementname
        {
            get { return ((dynamic)this).Elementname; }
        }

        public ElementTypes GetElementType()
        {
            return getType(this);
        }

        private static ElementTypes getType(PElement element)
        {
            if (element is ASimpleElement)
                return ElementTypes.Simple;
            if (element is AQuestionElement)
                return ElementTypes.Question;
            if (element is APlusElement)
                return ElementTypes.Plus;
            if (element is AStarElement)
                return ElementTypes.Star;

            throw new ArgumentException("Unknown element type; " + element.GetType().Name, "element");
        }
    }
}
