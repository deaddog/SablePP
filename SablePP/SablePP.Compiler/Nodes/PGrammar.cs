using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Nodes
{
    public partial class PGrammar
    {
        public static readonly string DefaultName = "SableCCPP";
        public string PackageName
        {
            get { return HasPackages ? Packages.First().Text : DefaultName; }
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

        public bool HasPackages
        {
            get { return Packages.Any(); }
        }
        public IEnumerable<TPackagename> Packages
        {
            get { return _sections_.OfType<APackageSection>().Select(x => x.Packagename); }
        }

        public bool HasHelpers
        {
            get { return Helpers.Any(); }
        }
        public IEnumerable<PHelper> Helpers
        {
            get
            {
                foreach (var hSec in _sections_.OfType<AHelpersSection>())
                    foreach (var h in hSec.Helpers)
                        yield return h;
            }
        }

        public bool HasStates
        {
            get { return States.Any(); }
        }
        public IEnumerable<PState> States
        {
            get
            {
                foreach (var sSec in _sections_.OfType<AStatesSection>())
                    foreach (var s in sSec.States)
                        yield return s;
            }
        }

        public bool HasTokens
        {
            get { return Tokens.Any(); }
        }
        public IEnumerable<PToken> Tokens
        {
            get
            {
                foreach (var tSec in _sections_.OfType<ATokensSection>())
                    foreach (var t in tSec.Tokens)
                        yield return t;
            }
        }

        public bool HasIgnoredTokens
        {
            get { return IgnoredTokens.Any(); }
        }
        public IEnumerable<TIdentifier> IgnoredTokens
        {
            get
            {
                foreach (var tSec in _sections_.OfType<AIgnoreSection>())
                    foreach (var t in tSec.Tokens)
                        yield return t;
            }
        }

        public bool HasProductions
        {
            get { return Productions.Any(); }
        }
        public IEnumerable<PProduction> Productions
        {
            get
            {
                foreach (var pSec in _sections_.OfType<AProductionsSection>())
                    foreach (var p in pSec.Productions)
                        yield return p;
            }
        }

        public bool HasAstproductions
        {
            get { return AstProductions.Any(); }
        }
        public IEnumerable<PProduction> AstProductions
        {
            get
            {
                foreach (var aSec in _sections_.OfType<AASTSection>())
                    foreach (var p in aSec.Productions)
                        yield return p;
            }
        }

        public bool HasHighlightRules
        {
            get { return HighlightRules.Any(); }
        }
        public IEnumerable<PHighlightrule> HighlightRules
        {
            get
            {
                foreach (var hSec in _sections_.OfType<AHighlightSection>())
                    foreach (var r in hSec.Highlightrules)
                        yield return r;
            }
        }
    }
}
