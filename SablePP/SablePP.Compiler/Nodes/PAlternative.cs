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
            private PProduction production;
            private PAlternative alternative;
            private PToken token;

            private Modifiers modifier;

            private static Target _null = new Target(Modifiers.Optional);
            public static Target Null
            {
                get { return _null; }
            }

            private static Target emptyList = new Target(Modifiers.ZeroOrMany);
            public static Target EmptyList
            {
                get { return emptyList; }
            }

            private static Target unknown = new Target(Modifiers.Single);
            public static Target Unknown
            {
                get { return unknown; }
            }

            private Target(Modifiers modifiers)
            {
                this.production = null;
                this.alternative = null;
                this.token = null;
                this.modifier = modifiers;
            }

            public Target(PProduction production, Modifiers modifier)
            {
                if (production == null)
                    throw new ArgumentNullException("production");

                this.production = production;
                this.alternative = null;
                this.token = null;
                this.modifier = modifier;
            }
            public Target(PAlternative alternative, Modifiers modifier)
            {
                if (alternative == null)
                    throw new ArgumentNullException("alternative");

                this.production = null;
                this.alternative = alternative;
                this.token = null;
                this.modifier = modifier;
            }
            public Target(PToken token, Modifiers modifier)
            {
                if (token == null)
                    throw new ArgumentNullException("token");

                this.production = null;
                this.alternative = null;
                this.token = token;
                this.modifier = modifier;
            }

            public bool IsProduction
            {
                get { return production != null; }
            }
            public bool IsAlternative
            {
                get { return alternative != null; }
            }
            public bool IsToken
            {
                get { return token != null; }
            }

            public bool IsUnknown
            {
                get { return ReferenceEquals(this, unknown); }
            }
            public bool IsNull
            {
                get { return ReferenceEquals(this, _null); }
            }
            public bool IsEmptyList
            {
                get { return ReferenceEquals(this, emptyList); }
            }

            public PProduction Production
            {
                get { return production; }
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
