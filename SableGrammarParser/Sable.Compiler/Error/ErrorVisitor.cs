﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sable.Tools.Error;
using Sable.Tools.Nodes;
using Sable.Compiler.Analysis;
using Sable.Compiler.Nodes;

namespace Sable.Compiler.Error
{
    public abstract class ErrorVisitor : DepthFirstAdapter
    {
        private ErrorManager errorManager;

        protected ErrorVisitor()
        {
            this.errorManager = null;
        }

        public IEnumerable<CompilerError> GetErrors()
        {
            foreach (CompilerError error in errorManager)
                yield return error;
        }

        protected void RegisterError(Node node, string errorMessage, params object[] args)
        {
            if (errorManager == null)
                throw new InvalidOperationException("An ErrorVisitor must always be started using the StartVisitor-method.");

            errorManager.Register(new CompilerError(node, errorMessage, args));
        }

        protected T StartVisitor<T>(T visitor, Node node)
            where T : ErrorVisitor
        {
            if (this.errorManager == null)
                this.errorManager = new ErrorManager();

            visitor.errorManager = this.errorManager;
            node.Apply(visitor);
            return visitor;
        }

        public static T StartNewVisitor<T>(T visitor, Node node)
            where T : ErrorVisitor
        {
            visitor.errorManager = new ErrorManager();
            node.Apply(visitor);
            return visitor;
        }
    }
}
