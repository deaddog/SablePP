namespace SablePP.Generate
{
    public class CompilationResult
    {
        private CompilationError error;

        internal CompilationResult()
            : this(null)
        {
        }
        internal CompilationResult(CompilationError error)
        {
            this.error = error;
        }

        public CompilationError Error
        {
            get { return error; }
        }
    }
}
