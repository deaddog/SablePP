using FastColoredTextBoxNS;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Analysis;
using SablePP.Tools.Editor;
using SablePP.Tools.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public partial class SablePPEditor : EditorForm
    {
        #region Locator class

        private class Locator : EnumerationLocator
        {
            public override Token FindDeclaration(Token token)
            {
                if (token is DeclarationIdentifier)
                    return (token as DeclarationIdentifier).Declaration.GetIdentifier();
                else
                    return null;
            }

            protected override bool IsReference(Token declaration, Token token)
            {
                if (token is DeclarationIdentifier)
                    return (token as DeclarationIdentifier).Declaration.GetIdentifier() == declaration;
                else
                    return false;
            }
        }
        private class Renamer : IDeclarationRenamer
        {
            public IEnumerable<Token> FindRenamees(Token token, CodeTextBox.Result result)
            {
                throw new NotImplementedException();
            }

            public bool IsNameValid(Token token, string newName)
            {
                return System.Text.RegularExpressions.Regex.IsMatch(newName, "^[a-z][a-z0-9]*(_[a-z][a-z0-9]*)*$");
            }
        }


        #endregion

        private BackgroundWorker generateWorker;
        private CompilerExecuter executer;

        private EditorSettings settings = EditorSettings.Default;

        private ToolStripMenuItem tools;
        private ToolStripMenuItem outputButton = new ToolStripMenuItem("Set &Output Directory...");
        private ToolStripMenuItem generateButton = new ToolStripMenuItem("&Build");
        private ToolStripMenuItem livecodeButton = new ToolStripMenuItem("&LiveCode Tool");

        private ToolStripMenuItem goToButton = new ToolStripMenuItem("Go to definition...");
        private ToolStripMenuItem renameButton = new ToolStripMenuItem();
        private string renameText = "Rename \"{0}\"";
        private string renameTextDisabled = "Rename ...";

        public SablePPEditor()
        {
            InitializeComponent();

            codeTextBox1.GotFocus += (s, e) => HookEditToTextBox(codeTextBox1);
            liveCodeControl1.RecievedFocus += (s, e) => HookEditToTextBox(liveCodeControl1.CodeTextBox);

            HookEditToTextBox(codeTextBox1);

            this.codeTextBox1.Executer = executer = new CompilerExecuter();
            this.Text = "SPP Editor";
            this.FileExtension = "sablepp";

            this.generateWorker = new BackgroundWorker();
            this.generateWorker.DoWork += generateWorker_DoWork;
            this.generateWorker.RunWorkerCompleted += generateWorker_RunWorkerCompleted;

            tools = this.AddMenuItem("&Tools");

            outputButton.Click += outputButton_Click;
            outputButton.Enabled = false;

            generateButton.Click += generateButton_Click;
            generateButton.Enabled = false;
            generateButton.ShortcutKeys = Keys.F5;

            livecodeButton.Click += livecodeButton_Click;
            livecodeButton.ShortcutKeys = Keys.F2;

            tools.DropDownItems.Add(outputButton);
            tools.DropDownItems.Add(generateButton);
            tools.DropDownItems.Add(new ToolStripSeparator());
            tools.DropDownItems.Add(livecodeButton);

            goToButton.Click += (s, e) => codeTextBox1.GoToDeclaration();
            goToButton.Enabled = false;
            goToButton.ShortcutKeys = Keys.F12;

            renameButton.Click += renameButton_Click;
            renameButton.Enabled = false;
            renameButton.ShortcutKeys = Keys.F11;

            EditMenu.DropDownItems.Add(new ToolStripSeparator());
            EditMenu.DropDownItems.Add(goToButton);
            EditMenu.DropDownItems.Add(renameButton);

            codeTextBox1.DeclarationLocator = new Locator();
        }

        /// <summary>
        /// Updates the <see cref="SimpleEditor"/> interface and raises the <see cref="E:NewFileCreated" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnNewFileCreated(EventArgs e)
        {
            splitContainer1.Enabled = true;

            codeTextBox1.Text = DefaultCode;
            codeTextBox1.Focus();
            codeTextBox1.SelectionLength = 0;
            codeTextBox1.SelectionStart = 0;

            if (codeTextBox1.Text == string.Empty)
                codeTextBox1.OnTextChangedDelayed(codeTextBox1.Range);

            codeTextBox1.ClearUndo();

            base.OnNewFileCreated(e);
        }
        /// <summary>
        /// Updates the <see cref="SimpleEditor"/> interface and raises the <see cref="E:FileOpened" /> event.
        /// </summary>
        /// <param name="e">The <see cref="FileOpenedEventArgs" /> instance containing the event data.</param>
        protected override void OnFileOpened(FileOpenedEventArgs e)
        {
            splitContainer1.Enabled = true;

            codeTextBox1.Text = e.Content;
            codeTextBox1.ClearUndo();

            codeTextBox1.Focus();

            if (codeTextBox1.Text == string.Empty)
                codeTextBox1.OnTextChangedDelayed(codeTextBox1.Range);

            base.OnFileOpened(e);
        }
        /// <summary>
        /// Updates the <see cref="SimpleEditor"/> interface and raises the <see cref="E:FileSaving" /> event.
        /// </summary>
        /// <param name="e">The <see cref="FileSavingEventArgs" /> instance containing the event data.</param>
        protected override void OnFileSaving(FileSavingEventArgs e)
        {
            e.Content = codeTextBox1.Text;

            base.OnFileSaving(e);
        }
        /// <summary>
        /// Updates the <see cref="SimpleEditor"/> interface and raises the <see cref="E:FileClosed" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnFileClosed(EventArgs e)
        {
            splitContainer1.Enabled = false;
            codeTextBox1.Text = "";

            liveCodeControl1.UnLoadCompiler();

            base.OnFileClosed(e);
        }

        private void codeTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            // Update the position labels in the bottom right corner
            string lineText = lineLabel.Text.Substring(0, lineLabel.Text.IndexOf(':') + 1) + " ";
            lineLabel.Text = lineText + (codeTextBox1.Selection.Start.iLine + 1);

            string positionText = positionLabel.Text.Substring(0, positionLabel.Text.IndexOf(':') + 1) + " ";
            positionLabel.Text = positionText + (codeTextBox1.Selection.Start.iChar + 1);

            if (codeTextBox1.HasDeclaration())
            {
                var id = codeTextBox1.SelectedToken as DeclarationIdentifier;
                goToButton.Enabled = true;
                renameButton.Enabled = codeTextBox1.SelectedToken == id.Declaration.GetIdentifier();
                renameButton.Text = string.Format(renameText, codeTextBox1.SelectedToken.Text);
            }
            else
            {
                goToButton.Enabled = renameButton.Enabled = false;
                renameButton.Text = renameTextDisabled;
            }
        }
        private void codeTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            base.MarkFileAsChanged();
            if (!liveCodeSplitter.Panel2Collapsed)
                liveCodeControl1.MarkAsChanged();
        }

        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            var files = GetDraggedFiles(e);
            if (files.Length != 1)
                e.Effect = DragDropEffects.None;
            else
            {
                FileOpeningEventArgs fdea = new FileOpeningEventArgs(files[0], Path.GetExtension(files[0]) == "." + this.FileExtension);
                OnFileOpening(fdea);
                e.Effect = fdea.AllowFile ? DragDropEffects.Move : DragDropEffects.None;
            }
        }
        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            OpenFile(GetDraggedFiles(e)[0]);
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            if (codeTextBox1.SelectedToken != null && codeTextBox1.SelectedToken is DeclarationIdentifier)
                using (RenameForm form = new RenameForm(codeTextBox1.SelectedToken as DeclarationIdentifier))
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        throw new NotImplementedException();
                    }
        }

        protected override void OnFileChanged(EventArgs e)
        {
            outputButton.Enabled = File != null && File.Exists;
        }

        protected override void OnFiletoolsEnabledChanged(EventArgs e)
        {
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
            var dir = getOutputDirectory(out result);
            if (result == System.Windows.Forms.DialogResult.OK)
                settings.OutputPaths[this.File.FullName] = dir;
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

            messageTimer1.ShowMessage(MessageIcons.Working, "Building compiler...", 1000 * 60 * 10);
            generateButton.Enabled = false;
            generateWorker.RunWorkerAsync(output);
        }

        void livecodeButton_Click(object sender, EventArgs e)
        {
            if (liveCodeSplitter.Panel2Collapsed)
            {
                // Show live editor
                liveCodeSplitter.Panel2Collapsed = false;
                livecodeButton.Checked = true;
            }
            else
            {
                // Hide live editor
                liveCodeSplitter.Panel2Collapsed = true;
                livecodeButton.Checked = false;

                liveCodeControl1.UnLoadCompiler();
            }
        }

        private bool testForErrors(Tools.Error.CompilerError[] errors)
        {
            return errors.Any(e => e.ErrorType == Tools.Error.ErrorType.Error);
        }

        private void generateWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string path = e.Argument as string;

            var res = this.codeTextBox1.WaitForResult();

            if (!testForErrors(res.Errors))
                executer.Generate(res.Tree as SablePP.Tools.Nodes.Start<Nodes.PGrammar>, path);

            e.Result = res;
        }

        private void generateWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            var res = e.Result as CodeTextBox.Result;

            if (testForErrors(res.Errors))
                messageTimer1.ShowMessage(MessageIcons.Error, "Unable to generate compiler; error in validation.");
            else
            {
                messageTimer1.ShowMessage(MessageIcons.Accept, "Code generation completed!");
                var root = res.Tree as SablePP.Tools.Nodes.Start<SablePP.Compiler.Nodes.PGrammar>;
                var grammar = root.Root as SablePP.Compiler.Nodes.AGrammar;

                if (!liveCodeSplitter.Panel2Collapsed)
                    liveCodeControl1.LoadCompiler(settings.OutputPaths[this.File.FullName], grammar.Namespace);
            }

            generateButton.Enabled = true;
        }
    }
}
