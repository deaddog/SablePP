using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Editor
{
    public class SimpleEditor : EditorForm
    {
        public SimpleEditor()
            :base()
        {
        }

        protected override void OnNewFileCreated(EventArgs e)
        {
            splitContainer1.Enabled = true;

            codeTextBox1.Text = EditorSettings.Default.DefaultCode;
            codeTextBox1.Focus();
            codeTextBox1.SelectionLength = 0;
            codeTextBox1.SelectionStart = EditorSettings.Default.DefaultStart;

            if (codeTextBox1.Text == string.Empty)
                codeTextBox1.OnTextChangedDelayed(codeTextBox1.Range);

            codeTextBox1.ClearUndo();

            base.OnNewFileCreated(e);
        }

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

        protected override void OnFileSaving(FileSavingEventArgs e)
        {
            e.Content = codeTextBox1.Text;

            base.OnFileSaving(e);
        }
    }
}
