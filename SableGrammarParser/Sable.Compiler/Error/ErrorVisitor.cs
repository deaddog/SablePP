using System;

using Sable.Tools.Error;
using Sable.Tools.Nodes;
using Sable.Compiler.Analysis;

namespace Sable.Compiler.Error
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
            this.errorManager = errorManager;
        }

        protected void RegisterError(Node node, string errorMessage, params object[] args)
        {
            if (errorManager == null)
                throw new InvalidOperationException("An ErrorVisitor must always be started using the StartVisitor-method.");

            errorManager.Register(node, errorMessage, args);
        }
    }
}
