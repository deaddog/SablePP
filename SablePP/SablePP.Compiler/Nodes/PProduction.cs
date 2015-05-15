using System;
using System.Linq;

namespace SablePP.Compiler.Nodes
{
    public partial class PProduction : IDeclaration
    {
        public bool IsFirst
        {
            get
            {
                var par = this.GetParent();
                if (par is AProductionsSection)
                    return ReferenceEquals((par as AProductionsSection).Productions[0], this);
                else if (par is AASTSection)
                    return ReferenceEquals((par as AASTSection).Productions[0], this);
                else
                    return false;
            }
        }
        public string ClassName
        {
            get { return "P" + this.Identifier.Text.ToCamelCase(); }
        }

        public PAlternative UnnamedAlternative
        {
            get { return (from a in _alternatives_ where !a.HasAlternativename select a).FirstOrDefault(); }
        }

        public TIdentifier GetIdentifier()
        {
            return Identifier;
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
