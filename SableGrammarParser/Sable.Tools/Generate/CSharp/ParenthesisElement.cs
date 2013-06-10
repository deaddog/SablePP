using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sable.Tools.Generate.CSharp
{
    public class ParenthesisElement : ExecutableElement, IDisposable
    {
        public ParenthesisElement()
        {
            emit("(", UseSpace.NotPreferred, UseSpace.NotPreferred);
            InsertContents();
            emit(")", UseSpace.NotPreferred, UseSpace.NotPreferred);
        }

        void IDisposable.Dispose()
        {
            // Nothing to dispose, but implementing IDisposable allows for the use of the "using" construct.
        }
    }
}
