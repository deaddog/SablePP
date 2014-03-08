﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public partial class LiveCodeEditor : Form
    {
        private Form parentForm;

        public Form ParentForm
        {
            get { return parentForm; }
            set
            {
                if (!DesignMode)
                {
                    if (parentForm != null)
                    {
                        parentForm.LocationChanged -= updateBounds;
                        parentForm.SizeChanged -= updateBounds;
                    }
                    if (value != null)
                    {
                        value.LocationChanged += updateBounds;
                        value.SizeChanged += updateBounds;
                    }
                }

                this.parentForm = value;
            }
        }

        void updateBounds(object sender, EventArgs e)
        {
            Form form = sender as Form;
        }

        public LiveCodeEditor()
        {
            InitializeComponent();

            Font consolas = new Font("Consolas", 10);
            if (consolas.Name == "Consolas")
                codeTextBox1.Font = consolas;
            else
                consolas.Dispose();
        }

        private void codeTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.Close();
            }
        }
    }
}
