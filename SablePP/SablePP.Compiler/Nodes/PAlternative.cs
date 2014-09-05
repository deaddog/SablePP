using System;

namespace SablePP.Compiler.Nodes
{
    public partial class PAlternative : IDeclaration
    {
        public PProduction Production
        {
            get { return GetFirstParent<PProduction>(); }
        }

        public string ClassName
        {
            get
            {
                string productionName = Production.ClassName.Substring(1);

                if (this.HasAlternativename)
                    return "A" + Alternativename.Name.Text.ToCamelCase() + productionName;
                else
                    return "A" + productionName;
            }
        }

        public TIdentifier GetIdentifier()
        {
            if (HasAlternativename)
                return Alternativename.Name;
            else
                return null;
        }

        private TranslationTarget? astTarget;
        public TranslationTarget AstTarget
        {
            get { return astTarget.HasValue ? astTarget.Value : TranslationTarget.Unknown; }
            set
            {
                if (astTarget != null)
                    throw new InvalidOperationException("Cannot set production target twice.");

                astTarget = value;
            }
        }
    }
}
