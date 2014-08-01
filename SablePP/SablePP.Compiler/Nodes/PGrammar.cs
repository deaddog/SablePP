using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Nodes
{
    public partial class PGrammar
    {
        public static readonly string DefaultName = "SableCCPP";
        private string packagename = null;
        public string PackageName
        {
            get
            {
                if (packagename == null)
                {
                    if (HasPackage)
                        packagename = Package.Packagename.Text;
                    else
                        packagename = DefaultName;
                }
                return packagename;
            }
        }

        private string rootProduction = null;
        public string RootProduction
        {
            get
            {
                if (rootProduction == null)
                {
                    var prod = HasAstproductions ? Astproductions.Productions : Productions.Productions;
                    rootProduction = "P" + prod[0].Identifier.Text.ToCamelCase();
                }
                return rootProduction;
            }
        }

        public bool HasPackage
        {
            get { return (this as AGrammar).HasPackage; }
        }
        public PPackage Package
        {
            get { return (this as AGrammar).Package; }
        }

        public bool HasHelpers
        {
            get { return (this as AGrammar).HasHelpers; }
        }
        public PHelpers Helpers
        {
            get { return (this as AGrammar).Helpers; }
        }

        public bool HasStates
        {
            get { return (this as AGrammar).HasStates; }
        }
        public PStates States
        {
            get { return (this as AGrammar).States; }
        }

        public bool HasTokens
        {
            get { return (this as AGrammar).HasTokens; }
        }
        public PTokens Tokens
        {
            get { return (this as AGrammar).Tokens; }
        }

        public bool HasIgnoredtokens
        {
            get { return (this as AGrammar).HasIgnoredtokens; }
        }
        public PIgnoredtokens Ignoredtokens
        {
            get { return (this as AGrammar).Ignoredtokens; }
        }

        public bool HasProductions
        {
            get { return (this as AGrammar).HasProductions; }
        }
        public PProductions Productions
        {
            get { return (this as AGrammar).Productions; }
        }

        public bool HasAstproductions
        {
            get { return (this as AGrammar).HasAstproductions; }
        }
        public PAstproductions Astproductions
        {
            get { return (this as AGrammar).Astproductions; }
        }

        public bool HasHighlightrules
        {
            get { return (this as AGrammar).HasHighlightrules; }
        }
        public PHighlightrules Highlightrules
        {
            get { return (this as AGrammar).Highlightrules; }
        }
    }
}
