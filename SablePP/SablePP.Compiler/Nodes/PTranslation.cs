using System;

namespace SablePP.Compiler.Nodes
{
    public partial class PTranslation
    {
        private TranslationTarget? target;
        public TranslationTarget Target
        {
            get { return target.HasValue ? target.Value : TranslationTarget.Unknown; }
            set
            {
                if (target != null)
                    throw new InvalidOperationException("Cannot set translation target twice.");

                target = value;
            }
        }

        public bool IsTargetSet
        {
            get { return target.HasValue; }
        }

        public abstract string ClassName
        {
            get;
        }

        public abstract bool IsList
        {
            get;
        }
    }
}
