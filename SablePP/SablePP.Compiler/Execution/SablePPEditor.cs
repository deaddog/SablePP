using SablePP.Tools.Editor;
using System;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public class SablePPEditor : EditorForm
    {
        ToolStripMenuItem tools;

        public SablePPEditor()
        {
            this.Executer = new CompilerExecuter(false);
            this.Text = "SPP Editor";
            this.FileExtension = "sablecc";

            tools = this.AddMenuItem("&Tools");
        }
    }
}
