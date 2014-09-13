using System;

namespace SablePP.Generate.RegularExpressions
{
    public class ReferenceRegExp : RegExp
    {
        private Helper reference;

        public ReferenceRegExp(Helper reference)
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
