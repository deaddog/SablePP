using FastColoredTextBoxNS;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Analysis;
using SablePP.Tools.Editor;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public partial class SablePPEditor : EditorForm
    {
        private BackgroundWorker generateWorker;
        private CompilerExecuter executer;

        private EditorSettings settings = EditorSettings.Default;

        private Style highlightstyle = new SelectionStyle(new SolidBrush(Color.FromArgb(226, 230, 214)));

        private ToolStripMenuItem tools;
        private ToolStripMenuItem outputButton = new ToolStripMenuItem("Set &Output Directory...");
        private ToolStripMenuItem generateButton = new ToolStripMenuItem("&Build");
        private ToolStripMenuItem livecodeButton = new ToolStripMenuItem("&LiveCode Tool");

        private LiveCodeEditor lce;

        private ToolStripMenuItem goToButton = new ToolStripMenuItem("Go to definition...");

        public SablePPEditor()
        {
            InitializeComponent();

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

            lce = new LiveCodeEditor()
            {
                ManagingForm = this
            };
            lce.VisibleChanged += (s, e) => livecodeButton.Checked = lce.Visible;

            goToButton.Click += goToButton_Click;
            goToButton.Enabled = false;
            goToButton.ShortcutKeys = Keys.F12;

            EditMenu.DropDownItems.Add(new ToolStripSeparator());
            EditMenu.DropDownItems.Add(goToButton);

            codeTextBox1.Styles[0] = highlightstyle;
        }

        private void codeTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            // Update the position labels in the bottom right corner
            string lineText = lineLabel.Text.Substring(0, lineLabel.Text.IndexOf(':') + 1) + " ";
            lineLabel.Text = lineText + (codeTextBox1.Selection.Start.iLine + 1);

            string positionText = positionLabel.Text.Substring(0, positionLabel.Text.IndexOf(':') + 1) + " ";
            positionLabel.Text = positionText + (codeTextBox1.Selection.Start.iChar + 1);

            // Update the highlighting style to mark all related tokens
            codeTextBox1.Range.ClearStyle(highlightstyle);

            var find = codeTextBox1.TokenFromPlace(codeTextBox1.Selection.Start);
            if (find != null && find is DeclarationIdentifier)
            {
                var id = find as DeclarationIdentifier;
                goToButton.Enabled = true;

                foreach (var token in DepthFirstTreeWalker.GetTokens(codeTextBox1.LastResult.Tree).OfType<DeclarationIdentifier>())
                    if (id.Declaration == token.Declaration || (id.IsPElement && id.AsPElement.Elementid.Identifier == token))
                    {
                        var r = codeTextBox1.RangeFromToken(token);
                        if (!codeTextBox1.Range.Contains(r.Start) || !(codeTextBox1.Range.Contains(r.End)))
                            return;
                        r.SetStyle(highlightstyle);
                    }
            }
            else
                goToButton.Enabled = false;
        }

        private void goToButton_Click(object sender, EventArgs e)
        {
            var t = codeTextBox1.TokenFromPlace(codeTextBox1.Selection.Start);
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
                    id = id.AsState.Identifier;
                else
                    id = null;

                if (id != null)
                {
                    var range = codeTextBox1.RangeFromToken(id);
                    codeTextBox1.Selection = range;
                    if (!codeTextBox1.VisibleRange.Contains(range.Start) || !codeTextBox1.VisibleRange.Contains(range.End))
                        codeTextBox1.DoSelectionVisible();
                }
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

        void livecodeButton_Click(object sender, EventArgs e)
        {
            if (!livecodeButton.Checked)
                lce.Show();
            else
                lce.Hide();
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
                ShowMessage(MessageIcons.Error, "Unable to generate compiler; error in validation.");
            else
            {
                ShowMessage(MessageIcons.Accept, "Code generation completed!");
                var root = res.Tree as SablePP.Tools.Nodes.Start<SablePP.Compiler.Nodes.PGrammar>;
                var grammar = root.Root as SablePP.Compiler.Nodes.AGrammar;

                lce.LoadCompiler(grammar.PackageName);
            }

            generateButton.Enabled = true;
        }
    }
}
