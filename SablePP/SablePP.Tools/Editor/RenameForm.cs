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

        public static string ShowDialog(IDeclarationRenamer renamer, Token token, string title = null, string message = null)
        {
            if (title == null)
                title = string.Format("Renaming \"{0}\"", token.Text);
            if (message == null)
                message = string.Format("Renaming \"{0}\" and all its references.\r\nSpecify a new name below:", token.Text);

            using (RenameForm rf = new RenameForm(renamer, token, title, message))
            {
                if (rf.ShowDialog() == DialogResult.OK)
                    return rf.DeclarationName;
                else
                    return null;
            }
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
