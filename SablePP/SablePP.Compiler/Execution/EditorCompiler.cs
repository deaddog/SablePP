using System;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public class EditorCompiler : CompilerBase
    {
        protected override void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SablePPEditor());
        }
    }
}
