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

        private RenameForm(IDeclarationRenamer renamer, Token token, string title, string message)
            : this()
        {
            if (renamer == null)
                throw new ArgumentNullException("renamer");
            if (token == null)
                throw new ArgumentNullException("token");

            this.renamer = renamer;
            this.token = token;

            if (title == null) title = string.Empty;
            this.Text = title;
            if (message == null) message = string.Empty;
            this.label1.Text = message;

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
