namespace SablePP.Generate.SableCC
{
    internal class Output
    {
        private int exitCode;
        private string errorString;

        public Output(int exitCode, string errorString)
        {
            this.exitCode = exitCode;
            this.errorString = errorString;
        }

        public int ExitCode => exitCode;
        public string ErrorString => errorString;
    }
}
