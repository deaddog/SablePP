using FastColoredTextBoxNS;
using SablePP.Compiler.Nodes.Identifiers;
using SablePP.Tools.Analysis;
using SablePP.Tools.Editor;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public class SablePPEditor : EditorForm
    {
        private BackgroundWorker generateWorker;
        private CompilerExecuter executer;

        private EditorSettings settings = EditorSettings.Default;

        private Style highlightstyle = new SelectionStyle(new SolidBrush(Color.FromArgb(226, 230, 214)));

        private ToolStripMenuItem tools;
        private ToolStripMenuItem outputButton = new ToolStripMenuItem("Set &Output Directory...");
        private ToolStripMenuItem generateButton = new ToolStripMenuItem("&Build");

        private ToolStripMenuItem goToButton = new ToolStripMenuItem("Go to definition...");

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

            goToButton.Click += goToButton_Click;
            goToButton.Enabled = false;
            goToButton.ShortcutKeys = Keys.F12;

            EditMenu.DropDownItems.Add(new ToolStripSeparator());
            EditMenu.DropDownItems.Add(goToButton);

            this.CodeTextBox.SelectionChanged += CodeTextBox_SelectionChanged;
            this.CodeTextBox.CompilationCompleted += CodeTextBox_SelectionChanged;

            CodeTextBox.Styles[0] = highlightstyle;
        }

        private void CodeTextBox_SelectionChanged(object sender, EventArgs e)
        {
            CodeTextBox.Range.ClearStyle(highlightstyle);

            var find = CodeTextBox.TokenFromPlace(CodeTextBox.Selection.Start);
            if (find != null && find is DeclarationIdentifier)
            {
                var id = find as DeclarationIdentifier;
                goToButton.Enabled = true;

                foreach (var token in DepthFirstTreeWalker.GetTokens(CodeTextBox.LastResult.Tree).OfType<DeclarationIdentifier>())
                    if (id.Declaration == token.Declaration || (id.IsPElement && id.AsPElement.Elementid.Identifier == token))
                    {
                        var r = CodeTextBox.RangeFromToken(token);
                        if (!CodeTextBox.Range.Contains(r.Start) || !(CodeTextBox.Range.Contains(r.End)))
                            return;
                        r.SetStyle(highlightstyle);
                    }
            }
            else if (find != null && find is StateIdentifier)
            {
                var id = find as StateIdentifier;
                goToButton.Enabled = true;

                foreach (var token in DepthFirstTreeWalker.GetTokens(CodeTextBox.LastResult.Tree).OfType<StateIdentifier>())
                    if (id.Declaration == token.Declaration)
                    {
                        var r = CodeTextBox.RangeFromToken(token);
                        if (!CodeTextBox.Range.Contains(r.Start) || !(CodeTextBox.Range.Contains(r.End)))
                            return;
                        r.SetStyle(highlightstyle);
                    }
            }
            else
                goToButton.Enabled = false;
        }

        private void goToButton_Click(object sender, EventArgs e)
        {
            var t = CodeTextBox.TokenFromPlace(CodeTextBox.Selection.Start);
            if (t != null && t is SablePP.Compiler.Nodes.TIdentifier)
            {
                var id = t as SablePP.Compiler.Nodes.TIdentifier;
                if (id.IsPAlternative)
                {
                    if (id.AsPAlternative.HasAlternativename)
                        id = id.AsPAlternative.Alternativename.Name;
                    else
                        id = null;
                }
                else if (id.IsPElement)
                {
                    if (id.AsPElement.HasElementname)
                        id = id.AsPElement.Elementname.Name;
                    else
                        id = id.AsPElement.Elementid.Identifier;
                }
                else if (id.IsPHelper)
                    id = id.AsPHelper.Identifier;
                else if (id.IsPHighlightrule)
                    id = id.AsPHighlightrule.Name;
                else if (id.IsPProduction)
                    id = id.AsPProduction.Identifier;
                else if (id.IsPToken)
                    id = id.AsPToken.Identifier;
                else if (id.IsState)
                    id = id.AsState;
                else
                    id = null;

                if (id != null)
                {
                    var range = CodeTextBox.RangeFromToken(id);
                    CodeTextBox.Selection = range;
                    if (!CodeTextBox.VisibleRange.Contains(range.Start) || !CodeTextBox.VisibleRange.Contains(range.End))
                        CodeTextBox.DoSelectionVisible();
                }
            }
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

        private bool testForErrors(Tools.Error.CompilerError[] errors)
        {
            return errors.Any(e => e.ErrorType == Tools.Error.ErrorType.Error);
        }

        private void generateWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string path = e.Argument as string;

            var res = this.WaitForResult();

            if (!testForErrors(res.Errors))
                executer.Generate(res.Tree as SablePP.Tools.Nodes.Start<Nodes.PGrammar>, path);

            e.Result = res;
        }

        private void generateWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            var res = e.Result as CodeTextBox.Result;

            if (testForErrors(res.Errors))
                ShowMessage(MessageIcons.Error, "Unable to generate compiler; error in validation.");
            else
                ShowMessage(MessageIcons.Accept, "Code generation completed!");

            generateButton.Enabled = true;
        }
    }
}
