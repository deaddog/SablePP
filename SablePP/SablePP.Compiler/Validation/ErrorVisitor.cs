using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Error;
using SablePP.Tools.Nodes;
using System;
using System.Collections.Generic;

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

        private void visitEach(IEnumerable<Node> nodes)
        {
            foreach (var n in nodes)
                Visit(n);
        }
        public virtual void VisitPackages(IEnumerable<TPackagename> nodes)
        {
            visitEach(nodes);
        }
        public virtual void VisitHelpers(IEnumerable<PHelper> nodes)
        {
            visitEach(nodes);
        }
        public virtual void VisitStates(IEnumerable<PState> nodes)
        {
            visitEach(nodes);
        }
        public virtual void VisitTokens(IEnumerable<PToken> nodes)
        {
            visitEach(nodes);
        }
        public virtual void VisitIgnoredTokens(IEnumerable<TIdentifier> nodes)
        {
            visitEach(nodes);
        }
        public virtual void VisitProductions(IEnumerable<PProduction> nodes)
        {
            visitEach(nodes);
        }
        public virtual void VisitAstProductions(IEnumerable<PProduction> nodes)
        {
            visitEach(nodes);
        }
        public virtual void VisitHighlightRules(IEnumerable<PHighlightrule> nodes)
        {
            visitEach(nodes);
        }
    }
}
