using SablePP.Generate;
using System;

namespace SablePP.Compiler.Nodes
{
    public struct TranslationTarget : IEquatable<TranslationTarget>
    {
        private PProduction production;
        private PAlternative alternative;
        private PToken token;

        private Modifiers modifier;

        private static TranslationTarget _null = new TranslationTarget(Modifiers.Optional);
        public static TranslationTarget Null
        {
            get { return _null; }
        }

        private static TranslationTarget emptyList = new TranslationTarget(Modifiers.ZeroOrMany);
        public static TranslationTarget EmptyList
        {
            get { return emptyList; }
        }

        private static TranslationTarget unknown = new TranslationTarget(Modifiers.Single);
        public static TranslationTarget Unknown
        {
            get { return unknown; }
        }

        private TranslationTarget(Modifiers modifiers)
        {
            this.production = null;
            this.alternative = null;
            this.token = null;
            this.modifier = modifiers;
        }

        public TranslationTarget(PProduction production, Modifiers modifier)
        {
            if (production == null)
                throw new ArgumentNullException("production");

            this.production = production;
            this.alternative = null;
            this.token = null;
            this.modifier = modifier;
        }
        public TranslationTarget(PAlternative alternative, Modifiers modifier)
        {
            if (alternative == null)
                throw new ArgumentNullException("alternative");

            this.production = null;
            this.alternative = alternative;
            this.token = null;
            this.modifier = modifier;
        }
        public TranslationTarget(PToken token, Modifiers modifier)
        {
            if (token == null)
                throw new ArgumentNullException("token");

            this.production = null;
            this.alternative = null;
            this.token = token;
            this.modifier = modifier;
        }

        public static bool operator ==(TranslationTarget t1, TranslationTarget t2)
        {
            return t1.Equals(t2);
        }
        public static bool operator !=(TranslationTarget t1, TranslationTarget t2)
        {
            return !t1.Equals(t2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is TranslationTarget))
                return false;
            else
                return Equals((TranslationTarget)obj);
        }
        public bool Equals(TranslationTarget obj)
        {
            return this.production == obj.production
                && this.alternative == obj.alternative
                && this.token == obj.token
                && this.modifier == obj.modifier;
        }

        public override int GetHashCode()
        {
            int hash = modifier.GetHashCode();

            if (production != null)
                hash ^= production.GetHashCode();
            if (alternative != null)
                hash ^= alternative.GetHashCode();
            if (token != null)
                hash ^= token.GetHashCode();

            return hash;
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
            get { return this == unknown; }
        }
        public bool IsNull
        {
            get { return this == _null; }
        }
        public bool IsEmptyList
        {
            get { return this == emptyList; }
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
