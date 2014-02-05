using SablePP.Tools.Error;
using SablePP.Tools.Nodes;
using System;

namespace SablePP.Tools
{
    public class CompilationOptions
    {
        private ErrorManager errorManager;

        public CompilationOptions(ErrorManager errorManager)
        {
            this.errorManager = errorManager;
        }

        public ErrorManager ErrorManager
        {
            get { return errorManager; }
        }
    }
}
