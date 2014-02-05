using SablePP.Tools.Error;
using SablePP.Tools.Nodes;
using System;

namespace SablePP.Tools
{
    public class CompilationOptions<T>
        where T : Node
    {
        private Start<T> root;
        private ErrorManager errorManager;

        public CompilationOptions(Start<T> root, ErrorManager errorManager)
        {
            this.root = root;
            this.errorManager = errorManager;
        }

        public Start<T> Root
        {
            get { return root; }
        }
        public ErrorManager ErrorManager
        {
            get { return errorManager; }
        }
    }
}
