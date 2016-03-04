using System;
using System.Text.RegularExpressions;

namespace SablePP.Generate.SableCC
{
    internal class Output
    {
        private readonly int exitCode;
        private readonly string errorString;

        public Output(int exitCode, string errorString)
        {
            this.exitCode = exitCode;
            this.errorString = errorString;
        }

        public int ExitCode => exitCode;
        public string ErrorString => errorString;

        public CompilationError handleSableException()
        {
            Regex errorRegex = new Regex(@"(?<type>shift|reduce)/reduce conflict in state");

            Match m = errorRegex.Match(errorString);
            ErrorTypes type;

            if (!m.Success)
                type = ErrorTypes.Unknown;
            else
                type = m.Groups["type"].Value == "shift" ? ErrorTypes.ShiftReduce : ErrorTypes.ReduceReduce;

            if (type == ErrorTypes.ShiftReduce)
                return new ShiftReduceError(errorString);
            else if (type == ErrorTypes.ReduceReduce)
                return new ReduceReduceError(errorString);
            else

                throw new InvalidOperationException("Unknown error type from SableCC.");
        }
    }
}
