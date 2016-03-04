namespace SablePP.Generate
{
    public abstract class CompilationError
    {
        private ErrorTypes errorType;
        public ErrorTypes ErrorType
        {
            get { return errorType;  }
        }
        
        public abstract string Message { get; }

        public CompilationError(ErrorTypes errorType)
        {
            this.errorType = errorType;
        }
    }
}
