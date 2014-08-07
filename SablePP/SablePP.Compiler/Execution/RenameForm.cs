using SablePP.Compiler.Nodes;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public partial class RenameForm : Form
    {
        private string type;
        private string name;

        private readonly Regex identifierRegex = new Regex("^[a-z][a-z0-9]*(_[a-z][a-z0-9]*)*$");

        public static string GetDeclarationType(DeclarationIdentifier identifier)
        {
            if (identifier.IsPAlternative)
                return "alternative";
            else if (identifier.IsPElement)
                return "production element";
            else if (identifier.IsPHelper)
                return "helper";
            else if (identifier.IsPProduction)
            {
                var ast = identifier.AsPProduction.GetFirstParent<AASTSection>();
                if (ast == null)
                    return "production";
                else
                    return "ast production";
            }
            else if (identifier.IsPToken)
                return "token";
            else if (identifier.IsState)
                return "state";
            else
                return null;
        }

        public RenameForm()
        {
            InitializeComponent();
        }

        public RenameForm(DeclarationIdentifier identifier)
            : this()
        {
            this.type = GetDeclarationType(identifier);
            this.name = identifier.Text;

            this.Text = string.Format(this.Text, name);
            this.label1.Text = string.Format(this.label1.Text, name, type);
            this.textBox1.Text = name;
        }

        public string IdentifierName
        {
            get { return textBox1.Text; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            renameButton.Enabled = identifierRegex.IsMatch(textBox1.Text);
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
