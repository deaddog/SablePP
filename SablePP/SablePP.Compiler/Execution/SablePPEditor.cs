using SablePP.Tools.Editor;
using System;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public class SablePPEditor : EditorForm
    {
        public SablePPEditor()
        {
            base.Executer = new CompilerExecuter(false);
            base.Text = "SPP Editor";
            base.FileExtension = "sablecc";
        }
    }
}
