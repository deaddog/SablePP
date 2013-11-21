using System;
using SablePP.Tools.Error;

namespace SablePP.Tools.Editor
{
    public class ErrorEventArgs : EventArgs
    {
        private CompilerError error;

        public ErrorEventArgs(CompilerError error)
        {
            this.error = error;
        }

        public CompilerError Error
        {
            get { return error; }
        }
    }
}
