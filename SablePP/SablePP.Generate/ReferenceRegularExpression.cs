using System;

namespace SablePP.Generate
{
    public class ReferenceRegularExpression : RegularExpression
    {
        private Helper reference;

        public ReferenceRegularExpression(Helper reference)
        {
            if (reference == null)
                throw new ArgumentNullException("reference");

            this.reference = reference;
        }

        public Helper ReferencedHelper
        {
            get { return reference; }
        }
    }
}
