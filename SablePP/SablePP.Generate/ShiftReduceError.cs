namespace SablePP.Generate
{
    public class ShiftReduceError : CompilationError
    {
        private string message;

        public ShiftReduceError(string message) 
            : base(ErrorTypes.ShiftReduce)
        {
            this.message = message;
        }

        public override string Message => message;
    }
}
