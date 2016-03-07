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
    }
}
