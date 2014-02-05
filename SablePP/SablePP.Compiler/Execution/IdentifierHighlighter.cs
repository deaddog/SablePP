using FastColoredTextBoxNS;
using SablePP.Compiler.Nodes;
using SablePP.Tools;
using System.Drawing;

namespace SablePP.Compiler.Execution
{
    public class IdentifierHighlighter : IHighlighter
    {
        private TextStyle tokenStyle = new TextStyle(new SolidBrush(Color.FromArgb(43, 145, 175)), null, FontStyle.Regular);
        private TextStyle productionStyle = new TextStyle(new SolidBrush(Color.Blue), null, FontStyle.Regular);

        Style IHighlighter.GetStyle(Tools.Nodes.Token token)
        {
            if (token is TIdentifier)
                return getStyle(token as TIdentifier);
            else
                return null;
        }

        private Style getStyle(TIdentifier identifier)
        {
            if (identifier.IsToken)
                return tokenStyle;
            else if (identifier.IsProduction)
                return productionStyle;
            return null;
        }
    }
}
