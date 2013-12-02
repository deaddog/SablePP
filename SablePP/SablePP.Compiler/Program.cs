using System;
using SablePP.Compiler.Execution;

namespace SablePP.Compiler
{
    class Program
    {
#if WINFORMS
        [STAThread]
        private static void Main(string[] args)
        {
            new EditorCompiler().Main(args);
        }
#else
        private static void Main(string[] args)
        {
            new ConsoleCompiler().Main(args);
        }
#endif
    }
}