using SablePP.Tools.Editor;
using System;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public class SablePPEditor : EditorForm
    {
        private CompilerExecuter executer;

        private ToolStripMenuItem tools;
        private ToolStripMenuItem outputButton = new ToolStripMenuItem("&Output directory...");
        private ToolStripMenuItem generateButton = new ToolStripMenuItem("&Build");

        public SablePPEditor()
        {
            this.Executer = executer = new CompilerExecuter(false);
            this.Text = "SPP Editor";
            this.FileExtension = "sablecc";

            tools = this.AddMenuItem("&Tools");

            outputButton.Click += outputButton_Click;

            generateButton.Click += generateButton_Click;
            generateButton.ShortcutKeys = Keys.F5;

            tools.DropDownItems.Add(outputButton);
            tools.DropDownItems.Add(generateButton);
        }

        protected override void OnFiletoolsEnabledChanged(EventArgs e)
        {
            generateButton.Enabled = FiletoolsEnabled;
        }

        private void outputButton_Click(object sender, EventArgs e)
        {
        }
        private void generateButton_Click(object sender, EventArgs e)
        {
        }
    }
}
