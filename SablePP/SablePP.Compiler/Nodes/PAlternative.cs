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

        private Target astTarget;
        public Target AstTarget
        {
            get { return astTarget; }
            set
            {
                if (astTarget != null)
                    throw new InvalidOperationException("Cannot set production target twice.");

                astTarget = value;
            }
        }

        public class Target
        {
            private PAlternative alternative;
            private PToken token;

            private Modifiers modifier;

            public Target(PAlternative alternative, Modifiers modifier)
            {
                if (alternative == null)
                    throw new ArgumentNullException("alternative");

                this.alternative = alternative;
                this.token = null;
                this.modifier = modifier;
            }
            public Target(PToken token, Modifiers modifier)
            {
                if (token == null)
                    throw new ArgumentNullException("token");

                this.alternative = null;
                this.token = token;
                this.modifier = modifier;
            }

            public bool IsAlternative
            {
                get { return alternative != null; }
            }
            public bool IsToken
            {
                get { return token != null; }
            }

            public PAlternative Alternative
            {
                get { return alternative; }
            }
            public PToken Token
            {
                get { return token; }
            }

            public Modifiers Modifier
            {
                get { return modifier; }
            }
        }
    }
}
