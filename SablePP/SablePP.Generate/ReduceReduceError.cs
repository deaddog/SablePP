namespace SablePP.Generate
{
    public class ReduceReduceError : CompilationError
    {
        private string message;

        public ReduceReduceError(string message)
            : base(ErrorTypes.ReduceReduce)
        {
            this.message = message;
        }

        public override string Message => message;
    }
}
