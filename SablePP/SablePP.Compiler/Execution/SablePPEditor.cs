using SablePP.Tools.Editor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public class SablePPEditor : EditorForm
    {
        private CompilerExecuter executer;

        private EditorSettings settings = EditorSettings.Default;

        private ToolStripMenuItem tools;
        private ToolStripMenuItem outputButton = new ToolStripMenuItem("&Output directory...");
        private ToolStripMenuItem generateButton = new ToolStripMenuItem("&Build");

        public SablePPEditor()
        {
            this.Executer = executer = new CompilerExecuter(false);
            this.Text = "SPP Editor";
            this.FileExtension = "sablecc";

            tools = this.AddMenuItem("&Tools");

            outputButton.Click += (s, e) => updateOutputDirectory();

            generateButton.Click += generateButton_Click;
            generateButton.ShortcutKeys = Keys.F5;

            tools.DropDownItems.Add(outputButton);
            tools.DropDownItems.Add(generateButton);
        }

        protected override void OnFiletoolsEnabledChanged(EventArgs e)
        {
            outputButton.Enabled = FiletoolsEnabled;
            generateButton.Enabled = FiletoolsEnabled;
        }

        private DialogResult updateOutputDirectory()
        {
            DialogResult result;

            using (FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                Description = "Select output folder...",
                ShowNewFolderButton = true
            })
            {
                fbd.SelectedPath = settings.OutputPaths[this.File.FullName];

                result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                    settings.OutputPaths[this.File.FullName] = fbd.SelectedPath;
            }

            return result;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (settings.OutputPaths[this.File.FullName] == null && updateOutputDirectory() != DialogResult.OK)
                return;

            var res = this.LastResult;
            if (res.Errors.Length > 0)
                ShowMessage("Unable to generate compiler; error in validation.");
            else
            {
                executer.Generate(res.Tree as SablePP.Tools.Nodes.Start<Nodes.PGrammar>, settings.OutputPaths[this.File.FullName]);
                ShowMessage("Code generation completed!");
            }
        }
    }
}
