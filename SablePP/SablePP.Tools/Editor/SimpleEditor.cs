using FastColoredTextBoxNS;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SablePP.Tools.Editor
{
    /// <summary>
    /// Extends the <see cref="EditorForm"/> by providing a <see cref="CodeTextBox"/> and a <see cref="ErrorView"/> for displaying code, running compilation and displaying errors.
    /// This editor can be modified to some extend and provides the basic functionality required for most simple programming-languages.
    /// </summary>
    public partial class SimpleEditor : EditorForm
    {
        private const int DEFAULT_MESSAGE_TIME = 3000;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleEditor"/> class.
        /// </summary>
        public SimpleEditor()
            : base()
        {
            InitializeComponent();

            HookEditToTextBox(codeTextBox1);

            Font consolas = new Font("Consolas", 10);
            if (consolas.Name == "Consolas")
                codeTextBox1.Font = consolas;
            else
                consolas.Dispose();
        }

        /// <summary>
        /// Updates the <see cref="SimpleEditor"/> interface and raises the <see cref="E:NewFileCreated" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnNewFileCreated(EventArgs e)
        {
            splitContainer1.Enabled = true;

            codeTextBox1.Text = EditorSettings.Default.DefaultCode;
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

            base.OnFileClosed(e);
        }

        /// <summary>
        /// Gets the <see cref="CodeTextBox"/> contained by this form.
        /// Use caution when accessing this control, as it handles all interaction with the compiler.
        /// </summary>
        public CodeTextBox CodeTextBox
        {
            get { return codeTextBox1; }
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
            base.MarkFileAsChanged();
        }

        private void EditorForm_DragEnter(object sender, DragEventArgs e)
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
        private void EditorForm_DragDrop(object sender, DragEventArgs e)
        {
            OpenFile(GetDraggedFiles(e)[0]);
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
    }
}
