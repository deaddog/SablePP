using System;
using System.Text;

namespace SablePP.Tools.Error
{
    public class ErrorArgumentEventArgs : EventArgs
    {
        private object argument;
        private string text;

        public ErrorArgumentEventArgs(object argument)
        {
            this.argument = argument;
            this.text = argument.ToString();
        }

        public object Argument
        {
            get { return argument; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }
}
