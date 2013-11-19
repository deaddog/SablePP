using System;
using FastColoredTextBoxNS;

namespace Sable.Tools.Editor
{
    public class ErrorEventArgs : EventArgs
    {
        private Place start, end;
        private string message;

        public ErrorEventArgs(Place start, Place end, string message)
        {
            this.start = start;
            this.end = end;
            this.message = message;
        }

        public Place Start
        {
            get { return start; }
        }
        public Place End
        {
            get { return end; }
        }
        public string Message
        {
            get { return message; }
        }
    }
}
