using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Nodes
{
    public class TranslationTarget
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
