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
                if (par is PProductions)
                    return ReferenceEquals((par as PProductions).Productions[0], this);
                else if (par is PAstproductions)
                    return ReferenceEquals((par as PAstproductions).Productions[0], this);
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
            private PToken token;

            private Modifiers modifier;

            public Target(PProduction production, Modifiers modifier)
            {
                if (production == null)
                    throw new ArgumentNullException("production");

                this.production = production;
                this.token = null;
                this.modifier = modifier;
            }
            public Target(PToken token, Modifiers modifier)
            {
                if (token == null)
                    throw new ArgumentNullException("token");

                this.production = null;
                this.token = token;
                this.modifier = modifier;
            }

            public bool IsProduction
            {
                get { return production != null; }
            }
            public bool IsToken
            {
                get { return token != null; }
            }

            public PProduction Production
            {
                get { return production; }
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
