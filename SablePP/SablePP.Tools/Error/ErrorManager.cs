using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SablePP.Tools.Nodes;

namespace SablePP.Tools.Error
{
    /// <summary>
    /// Manages semantic errors throughout semantic checks of an AST.
    /// </summary>
    public class ErrorManager : IEnumerable<CompilerError>
    {
        private ErrorComparison comparer;
        private List<CompilerError> errorList;
        public int Count { get { return errorList.Count; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorManager"/> class.
        /// </summary>
        public ErrorManager()
        {
            this.comparer = new ErrorComparison();
            errorList = new List<CompilerError>();
        }

        /// <summary>
        /// Registers the specified error.
        /// </summary>
        /// <param name="error">The error that should be added to the <see cref="ErrorManager"/>.</param>
        public void Register(CompilerError error)
        {
            int pos = errorList.BinarySearch(error, comparer);
            if (pos < 0) 
                pos = ~pos;
            else
            {
                do { pos++; }
                while (pos < errorList.Count && comparer.Compare(errorList[pos], error) == 0);
            }
            errorList.Insert(pos, error);
        }

        public void Register(Node node, string errorMessage, params object[] args)
        {
            if (args != null && args.Length > 0)
                errorMessage = string.Format(errorMessage, translateArguments(args));

            Register(new CompilerError(node, errorMessage));
        }

        private object[] translateArguments(object[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                ErrorArgumentEventArgs ea = new ErrorArgumentEventArgs(args[i]);
                if (TranslateArgument != null)
                    TranslateArgument(this, ea);
                args[i] = ea.Text;
            }

            return args;
        }

        public event ErrorArgumentEventHandler TranslateArgument;

        IEnumerator<CompilerError> IEnumerable<CompilerError>.GetEnumerator()
        {
            foreach (var err in errorList)
                yield return err;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (var err in errorList)
                yield return err;
        }

        private class ErrorComparison : IComparer<CompilerError>
        {
            public int Compare(CompilerError x, CompilerError y)
            {
                return x.Start.CompareTo(y.Start);
            }
        }
    }
}
