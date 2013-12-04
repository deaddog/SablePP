using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FastColoredTextBoxNS;

using SablePP.Tools.Error;
using SablePP.Tools.Lexing;
using SablePP.Tools.Nodes;
using SablePP.Tools.Parsing;

namespace SablePP.Tools.Editor
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
            string fileText = FileOpened ? string.Format("{0}{1}", File.Name, _changed ? "*" : "") : "";
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
                saveFileDialog1.Filter = string.Format(EditorResources.FileDescription, Text) + "|*." + (extension ?? EditorResources.DefaultExtension);
            }
        }

        #endregion

        #region FileHandle fields

        private Encoding encoding;

        private FileInfo _file = null;
        public FileInfo File
        {
            get { return _file; }
            private set
            {
                _file = value;
                if (_file == null)
                    _changed = false;

                updateTitle();

                FiletoolsEnabled = _file != null;
            }
        }
        public bool FileOpened
        {
            get { return File != null; }
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

            encoding = Encoding.UTF8;

            splitContainer1.Enabled = true;

            codeTextBox1.Text = EditorSettings.Default.DefaultCode;
            changed = false;

            File = new FileInfo(EditorResources.Untitled + "." + (extension ?? EditorResources.DefaultExtension));

            codeTextBox1.Focus();
            codeTextBox1.SelectionLength = 0;
            codeTextBox1.SelectionStart = EditorSettings.Default.DefaultStart;

            if (codeTextBox1.Text == string.Empty)
                codeTextBox1.OnTextChangedDelayed(codeTextBox1.Range);

            return DialogResult.OK;

        }
        private DialogResult openFile()
        {
            DialogResult res;
            if (FileOpened)
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
            if (FileOpened)
            {
                DialogResult res = closeFile();
                if (res != System.Windows.Forms.DialogResult.OK)
                    return res;
            }

            splitContainer1.Enabled = true;
            File = new FileInfo(filepath);
            using (StreamReader reader = new StreamReader(File.FullName, true))
            {
                codeTextBox1.Text = reader.ReadToEnd();
                this.encoding = reader.CurrentEncoding;
            }
            changed = false;

            codeTextBox1.Focus();

            if (codeTextBox1.Text == string.Empty)
                codeTextBox1.OnTextChangedDelayed(codeTextBox1.Range);

            return DialogResult.OK;
        }
        private DialogResult saveFile()
        {
            if (!FileOpened)
                return System.Windows.Forms.DialogResult.Cancel;

            if (!File.Exists)
                return saveFileAs();

            using (FileStream fs = new FileStream(File.FullName, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fs, encoding))
                writer.Write(codeTextBox1.Text);
            changed = false;

            return DialogResult.OK;
        }
        private DialogResult saveFileAs()
        {
            if (!FileOpened)
                return System.Windows.Forms.DialogResult.Cancel;

            DialogResult res = saveFileDialog1.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK)
                return res;

            FileInfo f = new FileInfo(saveFileDialog1.FileName);

            using (FileStream fs = new FileStream(f.FullName, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fs, encoding))
                writer.Write(codeTextBox1.Text);

            File = f;
            changed = false;


            return DialogResult.OK;
        }
        private DialogResult closeFile()
        {
            if (!FileOpened)
                return System.Windows.Forms.DialogResult.OK;

            if (changed)
            {
                DialogResult res = MessageBox.Show(
                    "It seems you have made changes to your file \"" + File.Name + "\", would you like to save it before closing?",
                    "File changed",
                    MessageBoxButtons.YesNoCancel);
                if (res == System.Windows.Forms.DialogResult.Yes)
                    res = saveFile();

                if (res == System.Windows.Forms.DialogResult.Cancel)
                    return res;
            }

            encoding = null;
            File = null;

            splitContainer1.Enabled = false;
            codeTextBox1.Text = "";
            errorTextBox1.ClearErrors();
            return DialogResult.OK;
        }

        #endregion

        public EditorForm()
        {
            InitializeComponent();

            this.codeTextBox1.ErrorAdded += (s, e) => this.errorTextBox1.AddError(e.Error);
            this.codeTextBox1.ErrorsCleared += (s, e) => this.errorTextBox1.ClearErrors();

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

            #endregion

            #region Edit menu events setup

            copyToolStripMenuItem.Click += (s, e) => codeTextBox1.Copy();
            cutToolStripMenuItem.Click += (s, e) => codeTextBox1.Cut();
            pasteToolStripMenuItem.Click += (s, e) => codeTextBox1.Paste();

            undoToolStripMenuItem.Click += (s, e) => codeTextBox1.Undo();
            redoToolStripMenuItem.Click += (s, e) => codeTextBox1.Redo();

            selectAllToolStripMenuItem.Click += (s, e) => codeTextBox1.SelectAll();

            #endregion

            newFile();

        }

        public void ShowMessage(string text)
        {
            ShowMessage(null, text);
        }
        public void ShowMessage(Image image, string text)
        {
            messageTimer.Start();

            fillerLabel.Image = image;
            fillerLabel.Text = text;
        }
        private void messageTimer_Tick(object sender, EventArgs e)
        {
            messageTimer.Stop();

            fillerLabel.Image = null;
            fillerLabel.Text = "";
        }

        public ToolStripMenuItem AddMenuItem(string text)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(text);
            AddMenuItem(item);
            return item;
        }
        public void AddMenuItem(ToolStripItem item)
        {
            this.menuStrip1.Items.Add(item);
        }

        private bool filetoolsenabled = false;
        public bool FiletoolsEnabled
        {
            get { return filetoolsenabled; }
            private set
            {
                if (filetoolsenabled == value)
                    return;

                filetoolsenabled = value;

                saveToolStripMenuItem.Enabled
                    = saveAsToolStripMenuItem.Enabled
                    = saveAsDefaultToolStripMenuItem.Enabled
                    = closeToolStripMenuItem.Enabled
                    = editToolStripMenuItem.Enabled
                    = filetoolsenabled;

                OnFiletoolsEnabledChanged(EventArgs.Empty);
            }
        }

        public event EventHandler FiletoolsEnabledChanged;
        protected virtual void OnFiletoolsEnabledChanged(EventArgs e)
        {
            if (FiletoolsEnabledChanged != null)
                FiletoolsEnabledChanged(this, e);
        }

        public ICompilerExecuter Executer
        {
            get { return codeTextBox1.Executer; }
            set { codeTextBox1.Executer = value; }
        }

        private void codeTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            string lineText = lineLabel.Text.Substring(0, lineLabel.Text.IndexOf(':') + 1) + " ";
            lineLabel.Text = lineText + (codeTextBox1.Selection.Start.iLine + 1);

            string positionText = positionLabel.Text.Substring(0, positionLabel.Text.IndexOf(':') + 1) + " ";
            positionLabel.Text = positionText + (codeTextBox1.Selection.Start.iChar + 1);
        }
        private void codeTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.changed = true;
        }
    }
}
