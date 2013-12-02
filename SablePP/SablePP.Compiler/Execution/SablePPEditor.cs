using SablePP.Tools.Editor;
using System;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public class SablePPEditor : EditorForm
    {
        private CompilerExecuter executer;

        private ToolStripMenuItem tools;
        private ToolStripMenuItem generateButton;

        public SablePPEditor()
        {
            this.Executer = executer = new CompilerExecuter(false);
            this.Text = "SPP Editor";
            this.FileExtension = "sablecc";

            tools = this.AddMenuItem("&Tools");

            generateButton = new ToolStripMenuItem("&Build", null, generateButton_Click, Keys.F5);

            tools.DropDownItems.Add(generateButton);
        }

        protected override void OnFiletoolsEnabledChanged(EventArgs e)
        {
            generateButton.Enabled = FiletoolsEnabled;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
        }
    }
}
