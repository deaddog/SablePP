using SablePP.Compiler.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Compiler.Analysis
{
    public partial class DepthFirstAdapter
    {
        public void VisitNamespaces(IEnumerable<TNamespace> nodes)
        {
            HandleNamespaces(nodes.ToArray());
        }
        protected virtual void HandleNamespaces(TNamespace[] nodes)
        {
            Visit(nodes);
        }

        public void VisitHelpers(IEnumerable<PHelper> nodes)
        {
            HandleHelpers(nodes.ToArray());
        }
        protected virtual void HandleHelpers(PHelper[] nodes)
        {
            Visit(nodes);
        }

        public void VisitStates(IEnumerable<PState> nodes)
        {
            HandleStates(nodes.ToArray());
        }
        protected virtual void HandleStates(PState[] nodes)
        {
            Visit(nodes);
        }

        public void VisitTokens(IEnumerable<PToken> nodes)
        {
            HandleTokens(nodes.ToArray());
        }
        protected virtual void HandleTokens(PToken[] nodes)
        {
            Visit(nodes);
        }

        public void VisitIgnoredTokens(IEnumerable<TIdentifier> nodes)
        {
            HandleIgnoredTokens(nodes.ToArray());
        }
        protected virtual void HandleIgnoredTokens(TIdentifier[] nodes)
        {
            Visit(nodes);
        }

        public void VisitProductions(IEnumerable<PProduction> nodes)
        {
            HandleProductions(nodes.ToArray());
        }
        protected virtual void HandleProductions(PProduction[] nodes)
        {
            Visit(nodes);
        }

        public void VisitAstProductions(IEnumerable<PProduction> nodes)
        {
            HandleAstProductions(nodes.ToArray());
        }
        protected virtual void HandleAstProductions(PProduction[] nodes)
        {
            Visit(nodes);
        }

        public void VisitHighlightRules(IEnumerable<PHighlightrule> nodes)
        {
            HandleHighlightRules(nodes.ToArray());
        }
        protected virtual void HandleHighlightRules(PHighlightrule[] nodes)
        {
            Visit(nodes);
        }
    }
}
