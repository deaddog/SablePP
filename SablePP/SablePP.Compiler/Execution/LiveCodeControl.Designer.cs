namespace SablePP.Compiler.Execution
{
    partial class LiveCodeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.codeTextBox1 = new SablePP.Tools.Editor.CodeTextBox();
            this.liveMessageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextBox1)).BeginInit();
            this.SuspendLayout();
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
            this.codeTextBox1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.codeTextBox1.IsReplaceMode = false;
            this.codeTextBox1.Location = new System.Drawing.Point(0, 0);
            this.codeTextBox1.Name = "codeTextBox1";
            this.codeTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.codeTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.codeTextBox1.Size = new System.Drawing.Size(300, 300);
            this.codeTextBox1.TabIndex = 0;
            this.codeTextBox1.Zoom = 100;
            // 
            // liveMessageLabel
            // 
            this.liveMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.liveMessageLabel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.liveMessageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.liveMessageLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liveMessageLabel.ForeColor = System.Drawing.Color.Black;
            this.liveMessageLabel.Location = new System.Drawing.Point(10, 240);
            this.liveMessageLabel.Name = "liveMessageLabel";
            this.liveMessageLabel.Size = new System.Drawing.Size(280, 50);
            this.liveMessageLabel.TabIndex = 2;
            this.liveMessageLabel.Text = "Text";
            this.liveMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LiveCodeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.liveMessageLabel);
            this.Controls.Add(this.codeTextBox1);
            this.Name = "LiveCodeControl";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.codeTextBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Tools.Editor.CodeTextBox codeTextBox1;
        private System.Windows.Forms.Label liveMessageLabel;
    }
}
