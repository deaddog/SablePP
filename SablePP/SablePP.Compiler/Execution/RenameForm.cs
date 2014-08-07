using SablePP.Compiler.Nodes;
using System;
using System.Windows.Forms;

namespace SablePP.Compiler.Execution
{
    public partial class RenameForm : Form
    {
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
    }
}
