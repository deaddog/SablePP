using SablePP.Tools.Nodes;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SablePP.Tools.Editor
{
    public partial class RenameForm : Form
    {
        private IDeclarationRenamer renamer;
        private Token token;

        private RenameForm()
        {
            InitializeComponent();
        }

        public RenameForm(IDeclarationRenamer renamer, Token token)
            : this()
        {
            if (renamer == null)
                throw new ArgumentNullException("renamer");
            if (token == null)
                throw new ArgumentNullException("token");

            this.renamer = renamer;
            this.token = token;

            this.Text = string.Format(this.Text, token.Text);
            this.label1.Text = string.Format(this.label1.Text, token.Text);
            this.textBox1.Text = token.Text;
        }

        public string DeclarationName
        {
            get { return textBox1.Text; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            renameButton.Enabled = renamer.IsNameValid(token, textBox1.Text);
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
