namespace SablePP.Generate
{
    public class CompilationError
    {
        private ErrorTypes errorType;
        public ErrorTypes ErrorType
        {
            get { return errorType;  }
        }
        
        private string message;
        public string Message
        {
            get { return message; }
        }

        public CompilationError(ErrorTypes errorType, string message)
        {
            this.errorType = errorType;
            this.message = message;
        }
    }
}
