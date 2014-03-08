namespace SablePP.Compiler.Execution
{
    partial class LiveCodeEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.codeTextBox1 = new SablePP.Tools.Editor.CodeTextBox();
            this.errorView1 = new SablePP.Tools.Editor.ErrorView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.codeTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.errorView1);
            this.splitContainer1.Size = new System.Drawing.Size(395, 382);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 2;
            // 
            // codeTextBox1
            // 
            this.codeTextBox1.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.codeTextBox1.BackBrush = null;
            this.codeTextBox1.CharHeight = 14;
            this.codeTextBox1.CharWidth = 8;
            this.codeTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.codeTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.codeTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeTextBox1.IsReplaceMode = false;
            this.codeTextBox1.Location = new System.Drawing.Point(0, 0);
            this.codeTextBox1.Name = "codeTextBox1";
            this.codeTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.codeTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.codeTextBox1.Size = new System.Drawing.Size(395, 265);
            this.codeTextBox1.TabIndex = 0;
            this.codeTextBox1.Zoom = 100;
            // 
            // errorView1
            // 
            this.errorView1.CodeTextBox = this.codeTextBox1;
            this.errorView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorView1.FullRowSelect = true;
            this.errorView1.Location = new System.Drawing.Point(0, 0);
            this.errorView1.MultiSelect = false;
            this.errorView1.Name = "errorView1";
            this.errorView1.Size = new System.Drawing.Size(395, 113);
            this.errorView1.TabIndex = 1;
            this.errorView1.UseCompatibleStateImageBehavior = false;
            this.errorView1.View = System.Windows.Forms.View.Details;
            // 
            // LiveCodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 382);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LiveCodeEditor";
            this.Text = "LiveCodeEditor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.codeTextBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Tools.Editor.CodeTextBox codeTextBox1;
        private Tools.Editor.ErrorView errorView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}