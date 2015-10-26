using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Error;
using SablePP.Tools.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Compiler.Validation
{
    public abstract class ErrorVisitor : DepthFirstAdapter
    {
        private ErrorManager errorManager;
        protected ErrorManager ErrorManager
        {
            get { return errorManager; }
        }

        public ErrorVisitor(ErrorManager errorManager)
        {
            if (errorManager == null)
                throw new ArgumentNullException("errorManager");

            this.errorManager = errorManager;
        }

        protected void RegisterError(Node node, string errorMessage, params object[] args)
        {
            errorManager.Register(node, errorMessage, args);
        }

        protected void RegisterWarning(Node node, string errorMessage, params object[] args)
        {
            errorManager.Register(node, ErrorType.Warning, errorMessage, args);
        }

        protected void RegisterMessage(Node node, string errorMessage, params object[] args)
        {
            errorManager.Register(node, ErrorType.Message, errorMessage, args);
        }

        private void visitEach(Node[] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
                Visit(nodes[i]);
        }

        public void VisitNamespaces(IEnumerable<TNamespace> nodes)
        {
            CaseNamespaces(nodes.ToArray());
        }
        protected virtual void CaseNamespaces(TNamespace[] nodes)
        {
            visitEach(nodes);
        }

        public void VisitHelpers(IEnumerable<PHelper> nodes)
        {
            CaseHelpers(nodes.ToArray());
        }
        protected virtual void CaseHelpers(PHelper[] nodes)
        {
            visitEach(nodes);
        }

        public void VisitStates(IEnumerable<PState> nodes)
        {
            CaseStates(nodes.ToArray());
        }
        protected virtual void CaseStates(PState[] nodes)
        {
            visitEach(nodes);
        }

        public void VisitTokens(IEnumerable<PToken> nodes)
        {
            CaseTokens(nodes.ToArray());
        }
        protected virtual void CaseTokens(PToken[] nodes)
        {
            visitEach(nodes);
        }

        public void VisitIgnoredTokens(IEnumerable<TIdentifier> nodes)
        {
            CaseIgnoredTokens(nodes.ToArray());
        }
        protected virtual void CaseIgnoredTokens(TIdentifier[] nodes)
        {
            visitEach(nodes);
        }

        public void VisitProductions(IEnumerable<PProduction> nodes)
        {
            CaseProductions(nodes.ToArray());
        }
        protected virtual void CaseProductions(PProduction[] nodes)
        {
            visitEach(nodes);
        }

        public void VisitAstProductions(IEnumerable<PProduction> nodes)
        {
            CaseAstProductions(nodes.ToArray());
        }
        protected virtual void CaseAstProductions(PProduction[] nodes)
        {
            visitEach(nodes);
        }

        public void VisitHighlightRules(IEnumerable<PHighlightrule> nodes)
        {
            CaseHighlightRules(nodes.ToArray());
        }
        protected virtual void CaseHighlightRules(PHighlightrule[] nodes)
        {
            visitEach(nodes);
        }
    }
}
