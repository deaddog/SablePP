using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FastColoredTextBoxNS;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// A form that handles opening, closing, save etc. of files and uses a <see cref="CodeTextBox"/> and a <see cref="ErrorTextBox"/> for displaying code, running compilation and displaying errors.
    /// This form is not required to implement a compiler. It merely implements standard open/close functionality.
    /// </summary>
    public partial class EditorForm : Form
    {
        private const int DEFAULT_MESSAGE_TIME = 3000;

        private RecentFilesHandler recentFiles;

        #region Form Text/Application name

        private string text;
        /// <summary>
        /// Gets or sets the title of the form. This is automatically appended with the current filename.
        /// </summary>
        /// <returns>The title of the form (not including the current filename).</returns>
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
        /// <summary>
        /// Gets or sets the file extension used by the editor.
        /// </summary>
        public string FileExtension
        {
            get { return extension; }
            set
            {
                if (value != null && value.TrimStart('.').Length == 0)
                    value = null;
                extension = value.TrimStart('.');
                openFileDialog1.Filter = string.Format(EditorResources.FileDescription, Text) + "|*." + (extension ?? EditorResources.DefaultExtension);
                saveFileDialog1.Filter = string.Format(EditorResources.FileDescription, Text) + "|*." + (extension ?? EditorResources.DefaultExtension);
            }
        }

        #endregion

        #region FileHandle fields

        private Encoding encoding;

        private FileInfo _file = null;
        /// <summary>
        /// Gets a <see cref="FileInfo"/> object representing the currently opened file.
        /// </summary>
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
        /// <summary>
        /// Gets a value indicating whether a file is currently open.
        /// </summary>
        /// <value>
        ///   <c>true</c> if a file is currently open; otherwise, <c>false</c>.
        /// </value>
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

#pragma warning disable 1591
        protected sealed override void OnClosing(CancelEventArgs e)
        {
            if (CloseFile() != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            else
                e.Cancel = false;
        }
#pragma warning restore

        /// <summary>
        /// Creates a new (unsaved) file in the editor.
        /// </summary>
        /// <returns>A <see cref="DialogResult"/> describing the succes of the operation. <see cref="DialogResult.OK"/> implies that the operation was successful.</returns>
        public DialogResult NewFile()
        {
            DialogResult res = CloseFile();
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
        /// <summary>
        /// Opens a file from disc using a dialog to select the file.
        /// </summary>
        /// <returns>A <see cref="DialogResult"/> describing the succes of the operation. <see cref="DialogResult.OK"/> implies that the operation was successful.</returns>
        public DialogResult OpenFile()
        {
            DialogResult res;
            if (FileOpened)
            {
                res = CloseFile();
                if (res != System.Windows.Forms.DialogResult.OK)
                    return res;
            }

            openFileDialog1.FileName = "";
            res = openFileDialog1.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK)
                return res;

            return OpenFile(openFileDialog1.FileName);
        }
        /// <summary>
        /// Opens a file from disc by specifying its path.
        /// </summary>
        /// <param name="filepath">The file path of the file to open.</param>
        /// <returns>A <see cref="DialogResult"/> describing the succes of the operation. <see cref="DialogResult.OK"/> implies that the operation was successful.</returns>
        public DialogResult OpenFile(string filepath)
        {
            if (FileOpened)
            {
                DialogResult res = CloseFile();
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
        /// <summary>
        /// Saves the currently open file on disc. If the file does not exist on disc, this is equivalent of calling the <see cref="SaveFileAs"/> method.
        /// </summary>
        /// <returns>A <see cref="DialogResult"/> describing the succes of the operation. <see cref="DialogResult.OK"/> implies that the operation was successful.</returns>
        public DialogResult SaveFile()
        {
            if (!FileOpened)
                return System.Windows.Forms.DialogResult.Cancel;

            if (!File.Exists)
                return SaveFileAs();

            using (FileStream fs = new FileStream(File.FullName, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fs, encoding))
                writer.Write(codeTextBox1.Text);
            changed = false;

            return DialogResult.OK;
        }
        /// <summary>
        /// Saves the currently open file on disc by selecting a destination path using a dialog.
        /// </summary>
        /// <returns>A <see cref="DialogResult"/> describing the succes of the operation. <see cref="DialogResult.OK"/> implies that the operation was successful.</returns>
        public DialogResult SaveFileAs()
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
        /// <summary>
        /// Closes the file after prompting to save changes to the file.
        /// </summary>
        /// <returns>A <see cref="DialogResult"/> describing the succes of the operation. <see cref="DialogResult.OK"/> implies that the operation was successful.</returns>
        public DialogResult CloseFile()
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
                    res = SaveFile();

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

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorForm"/> class.
        /// </summary>
        public EditorForm()
        {
            InitializeComponent();

            this.codeTextBox1.ErrorAdded += (s, e) => this.errorTextBox1.AddError(e.Error);
            this.codeTextBox1.ErrorsCleared += (s, e) => this.errorTextBox1.ClearErrors();

            this.Text = EditorResources.DefaultTitle;
            this.recentFiles = new RecentFilesHandler();

            #region FileHandle initialize

            newToolStripMenuItem.Click += (s, e) => NewFile();
            openToolStripMenuItem.Click += (s, e) => OpenFile();

            saveToolStripMenuItem.Click += (s, e) => SaveFile();
            saveAsToolStripMenuItem.Click += (s, e) => SaveFileAs();

            closeToolStripMenuItem.Click += (s, e) => CloseFile();
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

            Font consolas = new Font("Consolas", 10);
            if (consolas.Name == "Consolas")
                codeTextBox1.Font = consolas;
            else
                consolas.Dispose();
        }

        /// <summary>
        /// Gets the last compilation <see cref="CodeTextBox.Result"/> generated by the <see cref="ICompilerExecuter"/> in the <see cref="CodeTextBox"/> of this <see cref="EditorForm"/>.
        /// Consider using the <see cref="WaitForResult"/> method if the most resent result is required.
        /// </summary>
        public CodeTextBox.Result LastResult
        {
            get { return codeTextBox1.LastResult; }
        }

        /// <summary>
        /// Waits for the current compilation process to finish and returns its <see cref="CodeTextBox.Result"/>.
        /// </summary>
        /// <returns>A <see cref="CodeTextBox.Result"/> detailing the result of the currently executing compilation process.</returns>
        public CodeTextBox.Result WaitForResult()
        {
            return codeTextBox1.WaitForResult();
        }

        /// <summary>
        /// Shows a message in the status strip in the bottom of the <see cref="EditorForm"/>.
        /// </summary>
        /// <param name="text">The text message to display.</param>
        /// <param name="duration">The time, in milliseconds, the message is displayed.</param>
        public void ShowMessage(string text, int duration = DEFAULT_MESSAGE_TIME)
        {
            ShowMessage(null, text, duration);
        }
        /// <summary>
        /// Shows a message and an image in the status strip in the bottom of the <see cref="EditorForm"/>.
        /// </summary>
        /// <param name="image">The image to display.</param>
        /// <param name="text">The text message to display.</param>
        /// <param name="duration">The time, in milliseconds, the message is displayed.</param>
        public void ShowMessage(Image image, string text, int duration = DEFAULT_MESSAGE_TIME)
        {
            messageTimer.Interval = duration;
            messageTimer.Stop();
            messageTimer.Start();

            fillerLabel.Image = image;
            fillerLabel.Text = text;
        }
        /// <summary>
        /// Shows a message and an icon in the status strip in the bottom of the <see cref="EditorForm"/>.
        /// </summary>
        /// <param name="icon">The icon to display.</param>
        /// <param name="text">The text message to display.</param>
        /// <param name="duration">The time, in milliseconds, the message is displayed.</param>
        public void ShowMessage(MessageIcons icon, string text, int duration = DEFAULT_MESSAGE_TIME)
        {
            Image iconImage;

            switch (icon)
            {
                case MessageIcons.Accept:
                    iconImage = EditorResources.accept; break;
                case MessageIcons.Error:
                    iconImage = EditorResources.error; break;
                case MessageIcons.Warning:
                    iconImage = EditorResources.warning; break;
                case MessageIcons.Working:
                    iconImage = EditorResources.working; break;
                default:
                    throw new ArgumentException("Unknown message icon.");
            }

            ShowMessage(iconImage, text, duration);
        }

        private void messageTimer_Tick(object sender, EventArgs e)
        {
            messageTimer.Stop();

            fillerLabel.Image = null;
            fillerLabel.Text = "";
        }

        /// <summary>
        /// Adds a menu item to the top menu bar in the <see cref="EditorForm"/>.
        /// </summary>
        /// <param name="text">The text displayed on the menu item.</param>
        /// <returns>The <see cref="ToolStripMenuItem"/> that was added to the menu bar.</returns>
        public ToolStripMenuItem AddMenuItem(string text)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(text);
            AddMenuItem(item);
            return item;
        }
        /// <summary>
        /// Adds a <see cref="ToolStripItem"/> to the top menu bar in the <see cref="EditorForm"/>.
        /// </summary>
        /// <param name="item">The <see cref="ToolStripItem"/> that is added to the menu bar.</param>
        public void AddMenuItem(ToolStripItem item)
        {
            this.menuStrip1.Items.Add(item);
        }

        private bool filetoolsenabled = false;
        /// <summary>
        /// Gets a value indicating whether tool menu items, that are only available when a file is open, should be enabled.
        /// For instance; the Save functionality will only be enabled when this value is <c>true</c>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if file-related tools should be enabled; otherwise, <c>false</c>.
        /// </value>
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

        /// <summary>
        /// Occurs when the <see cref="FiletoolsEnabled"/> property changes.
        /// </summary>
        public event EventHandler FiletoolsEnabledChanged;
        /// <summary>
        /// Raises the <see cref="E:FiletoolsEnabledChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnFiletoolsEnabledChanged(EventArgs e)
        {
            if (FiletoolsEnabledChanged != null)
                FiletoolsEnabledChanged(this, e);
        }

        /// <summary>
        /// Gets or sets the <see cref="ICompilerExecuter"/> used by the <see cref="CodeTextBox"/> contained by this <see cref="EditorForm"/>.
        /// </summary>
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
        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
        }

        private class RecentFilesHandler
        {
            /// <summary>
            /// Defines the maximum number of elements in the list
            /// </summary>
            private const int MAXLISTSIZE = 50;
            private List<string> files;

            public RecentFilesHandler()
            {
                this.files = new List<string>(getPropertyFiles());
            }

            private IEnumerable<string> getPropertyFiles()
            {
                if (EditorSettings.Default.RecentFiles == null || EditorSettings.Default.RecentFiles.Length == 0)
                    yield break;

                foreach (var s in EditorSettings.Default.RecentFiles.Split(new char[] { '?' }, StringSplitOptions.RemoveEmptyEntries))
                    yield return s;
            }

            public void AddRecent(string filepath)
            {
                if (filepath == null)
                    throw new ArgumentNullException("filepath");

                filepath = Path.GetFullPath(filepath);

                if (filepath.EndsWith("/") || filepath.EndsWith("\\"))
                    throw new ArgumentException("File path cannot end in / or \\ - it must be the path of a file.", "filepath");

                if (!isValid(filepath))
                    throw new ArgumentException("File path is not valid.", "filepath");

                files.Insert(0, filepath);

                string filesString = filepath;
                filepath = filepath.ToLower();
                foreach (var f in getPropertyFiles().Take(MAXLISTSIZE))
                    if (f.ToLower() != filepath)
                        filesString += "?" + f;

                EditorSettings.Default.RecentFiles = filesString;
                EditorSettings.Default.Save();
            }

            private bool isValid(string filepath)
            {
                string filename = Path.GetFileName(filepath);
                filepath = filepath.Substring(0, filepath.Length - filename.Length);

                foreach (var c in Path.GetInvalidFileNameChars())
                    if (filename.Contains(c))
                        return false;

                foreach (var c in Path.GetInvalidPathChars())
                    if (filepath.Contains(c))
                        return false;

                return true;
            }

            public IEnumerable<string> Take(int count)
            {
                return getPropertyFiles().Take(count);
            }

            public IEnumerable<string> TakeExisting(int count)
            {
                int c = 0;
                foreach (var f in getPropertyFiles())
                {
                    if (new FileInfo(f).Exists)
                        yield return f;

                    if (c++ == count)
                        break;
                }
            }
        }
    }
}
