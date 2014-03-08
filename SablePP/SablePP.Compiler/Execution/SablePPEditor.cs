﻿using SablePP.Tools.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public class SablePPEditor : EditorForm
    {
        private BackgroundWorker generateWorker;
        private CompilerExecuter executer;

        private EditorSettings settings = EditorSettings.Default;

        private ToolStripMenuItem tools;
        private ToolStripMenuItem outputButton = new ToolStripMenuItem("Set &Output Directory...");
        private ToolStripMenuItem generateButton = new ToolStripMenuItem("&Build");

        public SablePPEditor()
        {
            this.Executer = executer = new CompilerExecuter(true);
            this.Text = "SPP Editor";
            this.FileExtension = "sablepp";

            this.generateWorker = new BackgroundWorker();
            this.generateWorker.DoWork += generateWorker_DoWork;
            this.generateWorker.RunWorkerCompleted += generateWorker_RunWorkerCompleted;

            tools = this.AddMenuItem("&Tools");
            tools.Enabled = false;

            outputButton.Click += outputButton_Click;
            outputButton.Enabled = false;

            generateButton.Click += generateButton_Click;
            generateButton.Enabled = false;
            generateButton.ShortcutKeys = Keys.F5;

            tools.DropDownItems.Add(outputButton);
            tools.DropDownItems.Add(generateButton);
        }

        protected override void OnFileChanged(EventArgs e)
        {
            outputButton.Enabled = File != null && File.Exists;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            PathInformation.CleanTemporaryFiles();
        }

        protected override void OnFiletoolsEnabledChanged(EventArgs e)
        {
            tools.Enabled = FiletoolsEnabled;
            outputButton.Enabled = FiletoolsEnabled;
            generateButton.Enabled = FiletoolsEnabled;
        }

        private string getOutputDirectory(out DialogResult result)
        {
            string path = null;

            using (FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                Description = "Select output folder...",
                ShowNewFolderButton = true
            })
            {
                fbd.SelectedPath = settings.OutputPaths[this.File.FullName];

                result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                    path = fbd.SelectedPath;
            }

            return path;
        }

        private void outputButton_Click(object sender, EventArgs e)
        {
            DialogResult result;
            settings.OutputPaths[this.File.FullName] = getOutputDirectory(out result);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            string output = settings.OutputPaths[this.File.FullName];

            if (output == null)
            {
                DialogResult result;
                output = getOutputDirectory(out result);
                if (result != DialogResult.OK)
                    return;

                if (this.File.Exists)
                    settings.OutputPaths[this.File.FullName] = output;
            }

            ShowMessage(MessageIcons.Working, "Building compiler...", 1000 * 60 * 10);
            generateButton.Enabled = false;
            generateWorker.RunWorkerAsync(output);
        }

        private void generateWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string path = e.Argument as string;

            var res = this.WaitForResult();

            if (res.Errors.Length == 0)
                executer.Generate(res.Tree as SablePP.Tools.Nodes.Start<Nodes.PGrammar>, path);

            e.Result = res;
        }

        private void generateWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            var res = e.Result as CodeTextBox.Result;

            if (res.Errors.Length > 0)
                ShowMessage(MessageIcons.Error, "Unable to generate compiler; error in validation.");
            else
                ShowMessage(MessageIcons.Accept, "Code generation completed!");

            generateButton.Enabled = true;
        }
    }
}
