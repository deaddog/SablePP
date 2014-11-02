﻿using System;
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

        protected override void OnNewFileCreated()
        {
            splitContainer1.Enabled = true;

            codeTextBox1.Text = EditorSettings.Default.DefaultCode;
            codeTextBox1.Focus();
            codeTextBox1.SelectionLength = 0;
            codeTextBox1.SelectionStart = EditorSettings.Default.DefaultStart;

            if (codeTextBox1.Text == string.Empty)
                codeTextBox1.OnTextChangedDelayed(codeTextBox1.Range);

            codeTextBox1.ClearUndo();

            base.OnNewFileCreated();
        }
    }
}
