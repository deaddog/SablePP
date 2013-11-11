using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FastColoredTextBoxNS;

using Sable.Tools.Error;
using Sable.Tools.Lexing;
using Sable.Tools.Nodes;
using Sable.Tools.Parsing;

namespace Sable.Tools.Editor
{
    public partial class EditorForm : Form
    {
        #region Form Text/Application name

        private string text;
        new public string Text
        {
            get { return text; }
            set
            {
                this.text = value;
                openFileDialog1.Filter = string.Format(EditorResources.FileDescription, Text) + "|*." + (extension ?? EditorResources.DefaultExtension);
                updateTitle();
            }
        }
        private void updateTitle()
        {
            string fileText = fileOpened ? string.Format("{0}{1}", file.Name, _changed ? "*" : "") : "";
            if (text == null || text.Length == 0)
                base.Text = fileText;
            else if (fileText.Length > 0)
                base.Text = text + " - " + fileText;
            else
                base.Text = text;
        }

        #endregion

        #region File extension

        private string extension = null;
        public string FileExtension
        {
            get { return extension; }
            set
            {
                if (value != null && value.Length == 0)
                    value = null;
                extension = value;
                openFileDialog1.Filter = string.Format(EditorResources.FileDescription, Text) + "|*." + (extension ?? EditorResources.DefaultExtension);
            }
        }

        #endregion

        #region FileHandle fields

        private FileInfo _file = null;
        private FileInfo file
        {
            get { return _file; }
            set
            {
                _file = value;
                if (_file == null)
                    _changed = false;

                updateTitle();

                saveToolStripMenuItem.Enabled
                    = saveAsToolStripMenuItem.Enabled
                    = saveAsDefaultToolStripMenuItem.Enabled
                    = closeToolStripMenuItem.Enabled
                    = (_file != null);
            }
        }
        private bool fileOpened
        {
            get { return file != null; }
        }
        private bool _changed = false;
        private bool changed
        {
            get { return _changed; }
            set { _changed = value; updateTitle(); }
        }

        #endregion

        #region FileHandle events and methods

        protected override void OnClosing(CancelEventArgs e)
        {
            if (closeFile() != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private DialogResult newFile()
        {
            DialogResult res = closeFile();
            if (res != System.Windows.Forms.DialogResult.OK)
                return res;

            splitContainer1.Enabled = true;

            codeTextBox1.Text = EditorSettings.Default.DefaultCode;
            changed = false;

            file = new FileInfo(EditorResources.Untitled + "." + (extension ?? EditorResources.DefaultExtension));

            codeTextBox1.Focus();
            codeTextBox1.SelectionLength = 0;
            codeTextBox1.SelectionStart = EditorSettings.Default.DefaultStart;

            return DialogResult.OK;

        }
        private DialogResult openFile()
        {
            DialogResult res;
            if (fileOpened)
            {
                res = closeFile();
                if (res != System.Windows.Forms.DialogResult.OK)
                    return res;
            }

            openFileDialog1.FileName = "";
            res = openFileDialog1.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK)
                return res;

            return openFile(openFileDialog1.FileName);
        }
        private DialogResult openFile(string filepath)
        {
            if (fileOpened)
            {
                DialogResult res = closeFile();
                if (res != System.Windows.Forms.DialogResult.OK)
                    return res;
            }

            splitContainer1.Enabled = true;
            file = new FileInfo(filepath);
            using (StreamReader reader = new StreamReader(file.FullName, true))
                codeTextBox1.Text = reader.ReadToEnd();
            changed = false;

            codeTextBox1.Focus();

            return DialogResult.OK;
        }
        private DialogResult saveFile()
        {
            if (!fileOpened)
                return System.Windows.Forms.DialogResult.Cancel;

            if (!file.Exists)
                return saveFileAs();

            using (FileStream fs = new FileStream(file.FullName, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.Unicode))
                writer.Write(codeTextBox1.Text);
            changed = false;

            return DialogResult.OK;
        }
        private DialogResult saveFileAs()
        {
            if (!fileOpened)
                return System.Windows.Forms.DialogResult.Cancel;

            DialogResult res = saveFileDialog1.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK)
                return res;

            FileInfo f = new FileInfo(saveFileDialog1.FileName);

            using (FileStream fs = new FileStream(f.FullName, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.Unicode))
                writer.Write(codeTextBox1.Text);

            file = f;
            changed = false;


            return DialogResult.OK;
        }
        private DialogResult closeFile()
        {
            if (!fileOpened)
                return System.Windows.Forms.DialogResult.OK;

            if (changed)
            {
                DialogResult res = MessageBox.Show(
                    "It seems you have made changes to your file \"" + file.Name + "\", would you like to save it before closing?",
                    "File changed",
                    MessageBoxButtons.YesNoCancel);
                if (res == System.Windows.Forms.DialogResult.Yes)
                    res = saveFile();

                if (res == System.Windows.Forms.DialogResult.Cancel)
                    return res;
            }

            file = null;

            splitContainer1.Enabled = false;
            codeTextBox1.Text = "";
            errorTextBox1.Text = "";
            return DialogResult.OK;
        }

        #endregion

        public EditorForm()
        {
            InitializeComponent();

            this.Text = EditorResources.DefaultTitle;

            #region FileHandle initialize

            newToolStripMenuItem.Click += (s, e) => newFile();
            openToolStripMenuItem.Click += (s, e) => openFile();

            saveToolStripMenuItem.Click += (s, e) => saveFile();
            saveAsToolStripMenuItem.Click += (s, e) => saveFileAs();

            closeToolStripMenuItem.Click += (s, e) => closeFile();
            exitToolStripMenuItem.Click += (s, e) => this.Close();

            saveAsDefaultToolStripMenuItem.Click += (s, e) =>
            {
                EditorSettings.Default.DefaultCode = codeTextBox1.Text;
                EditorSettings.Default.DefaultStart = codeTextBox1.SelectionStart;
                EditorSettings.Default.Save();
            };

            newFile();

            #endregion

        }

        private CompilerExecuter executer;

        public CompilerExecuter Executer
        {
            get { return executer; }
            set { executer = value; }
        }

        private void compileWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CompilerExecuter executer = ((dynamic)e.Argument).Executer as CompilerExecuter;
            string input = ((dynamic)e.Argument).Input as string;

            ErrorManager errorManager = new ErrorManager();
            Node ast;

            using (StringReader sr = new StringReader(input))
            {
                ILexer lexer = executer.GetLexer(sr);
                IParser parser = executer.GetParser(lexer);

                try
                {
                    ast = parser.Parse();
                }
                catch (LexerException ex)
                {
                    errorManager.Register(new CompilerError(ex.Line, ex.Position, 1, ex.Message));
                    ast = null;
                }
                catch (ParserException ex)
                {
                    errorManager.Register(new CompilerError(ex.LastLine, ex.LastPosition, 1, ex.Message));
                    ast = null;
                }
            }

            if (ast != null)
                executer.ValidateAST(ast, errorManager);

            e.Result = new { Errors = errorManager.ToArray(), AST = ast };
        }
        private void compileWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CompilerError[] errors = ((dynamic)e.Result).Errors as CompilerError[];
            Node ast = ((dynamic)e.Result).AST as Node;

            errorTextBox1.ClearErrors();
            codeTextBox1.ClearErrors();

            foreach (var err in errors)
            {
                Range r = new Range(codeTextBox1, err.Start.LinePosition - 1, err.Start.LineNumber - 1, err.End.LinePosition, err.End.LineNumber - 1);

                errorTextBox1.AddError(r, err.ErrorMessage);
                codeTextBox1.AddError(r, err.ErrorMessage);
            }
        }

        private void compileTimer_Tick(object sender, EventArgs e)
        {
            if (fileOpened)
            {
                if (compileWorker.IsBusy)
                {
                    compileTimer.Stop();
                    compileTimer.Start();
                }
                else
                {
                    compileWorker.RunWorkerAsync(new { Executer = executer, Input = codeTextBox1.Text });
                }
            }
            else
            {
                errorTextBox1.Text = "";
                compileTimer.Stop();
            }
        }

        private void codeTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            string lineText = lineLabel.Text.Substring(0, lineLabel.Text.IndexOf(':') + 1) + " ";
            lineLabel.Text = lineText + (codeTextBox1.Selection.Start.iLine + 1);

            string positionText = positionLabel.Text.Substring(0, positionLabel.Text.IndexOf(':') + 1) + " ";
            positionLabel.Text = positionText + (codeTextBox1.Selection.Start.iChar + 1);
        }
        private void codeTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            changed = true;
            compileTimer.Stop();
            compileTimer.Start();
        }
    }
}
