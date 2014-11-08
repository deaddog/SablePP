namespace SablePP.Compiler.Execution
{
    partial class SablePPEditor
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.fillerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lineLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.positionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.codeTextBox1 = new SablePP.Tools.Editor.CodeTextBox();
            this.errorView1 = new SablePP.Tools.Editor.ErrorView();
            this.messageTimer1 = new SablePP.Tools.Editor.MessageTimer();
            this.liveCodeSplitter = new System.Windows.Forms.SplitContainer();
            this.liveCodeControl1 = new SablePP.Compiler.Execution.LiveCodeControl();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveCodeSplitter)).BeginInit();
            this.liveCodeSplitter.Panel1.SuspendLayout();
            this.liveCodeSplitter.Panel2.SuspendLayout();
            this.liveCodeSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillerLabel,
            this.lineLabel,
            this.positionLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 563);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(904, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // fillerLabel
            // 
            this.fillerLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fillerLabel.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.fillerLabel.Name = "fillerLabel";
            this.fillerLabel.Size = new System.Drawing.Size(764, 17);
            this.fillerLabel.Spring = true;
            this.fillerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineLabel
            // 
            this.lineLabel.AutoSize = false;
            this.lineLabel.Name = "lineLabel";
            this.lineLabel.Size = new System.Drawing.Size(60, 17);
            this.lineLabel.Text = "Line: 0";
            this.lineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = false;
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(60, 17);
            this.positionLabel.Text = "Pos: 0";
            this.positionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Enabled = false;
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
            this.splitContainer1.Size = new System.Drawing.Size(880, 533);
            this.splitContainer1.SplitterDistance = 402;
            this.splitContainer1.TabIndex = 4;
            // 
            // codeTextBox1
            // 
            this.codeTextBox1.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.codeTextBox1.BackBrush = null;
            this.codeTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codeTextBox1.CharHeight = 15;
            this.codeTextBox1.CharWidth = 7;
            this.codeTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.codeTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.codeTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeTextBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTextBox1.IsReplaceMode = false;
            this.codeTextBox1.Location = new System.Drawing.Point(0, 0);
            this.codeTextBox1.Name = "codeTextBox1";
            this.codeTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.codeTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.codeTextBox1.Size = new System.Drawing.Size(880, 402);
            this.codeTextBox1.TabIndex = 0;
            this.codeTextBox1.Zoom = 100;
            this.codeTextBox1.CompilationCompleted += new System.EventHandler(this.codeTextBox1_SelectionChanged);
            this.codeTextBox1.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.codeTextBox1_TextChanged);
            this.codeTextBox1.SelectionChanged += new System.EventHandler(this.codeTextBox1_SelectionChanged);
            // 
            // errorView1
            // 
            this.errorView1.CodeTextBox = this.codeTextBox1;
            this.errorView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorView1.FullRowSelect = true;
            this.errorView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.errorView1.HideSelection = false;
            this.errorView1.Location = new System.Drawing.Point(0, 0);
            this.errorView1.MultiSelect = false;
            this.errorView1.Name = "errorView1";
            this.errorView1.Size = new System.Drawing.Size(880, 127);
            this.errorView1.TabIndex = 0;
            this.errorView1.UseCompatibleStateImageBehavior = false;
            this.errorView1.View = System.Windows.Forms.View.Details;
            // 
            // messageTimer1
            // 
            this.messageTimer1.Label = this.fillerLabel;
            // 
            // liveCodeSplitter
            // 
            this.liveCodeSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.liveCodeSplitter.Location = new System.Drawing.Point(12, 27);
            this.liveCodeSplitter.Name = "liveCodeSplitter";
            // 
            // liveCodeSplitter.Panel1
            // 
            this.liveCodeSplitter.Panel1.Controls.Add(this.splitContainer1);
            // 
            // liveCodeSplitter.Panel2
            // 
            this.liveCodeSplitter.Panel2.Controls.Add(this.liveCodeControl1);
            this.liveCodeSplitter.Panel2Collapsed = true;
            this.liveCodeSplitter.Size = new System.Drawing.Size(880, 533);
            this.liveCodeSplitter.SplitterDistance = 467;
            this.liveCodeSplitter.TabIndex = 6;
            // 
            // liveCodeControl1
            // 
            this.liveCodeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liveCodeControl1.Location = new System.Drawing.Point(0, 0);
            this.liveCodeControl1.Name = "liveCodeControl1";
            this.liveCodeControl1.Size = new System.Drawing.Size(96, 100);
            this.liveCodeControl1.TabIndex = 0;
            // 
            // SablePPEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 585);
            this.Controls.Add(this.liveCodeSplitter);
            this.Controls.Add(this.statusStrip1);
            this.Name = "SablePPEditor";
            this.Text = "SablePPEditor";
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.liveCodeSplitter, 0);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.codeTextBox1)).EndInit();
            this.liveCodeSplitter.Panel1.ResumeLayout(false);
            this.liveCodeSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.liveCodeSplitter)).EndInit();
            this.liveCodeSplitter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel fillerLabel;
        private System.Windows.Forms.ToolStripStatusLabel lineLabel;
        private System.Windows.Forms.ToolStripStatusLabel positionLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Tools.Editor.CodeTextBox codeTextBox1;
        private Tools.Editor.ErrorView errorView1;
        private Tools.Editor.MessageTimer messageTimer1;
        private System.Windows.Forms.SplitContainer liveCodeSplitter;
        private LiveCodeControl liveCodeControl1;
    }
}