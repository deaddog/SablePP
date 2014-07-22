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
        private TextStyle greyStyle = new TextStyle(new SolidBrush(Color.Gray), null, FontStyle.Regular);

        Style IHighlighter.GetStyle(Tools.Nodes.Token token)
        {
            if (token is TIdentifier)
                return getStyle(token as TIdentifier);
            else
                return null;
        }

        private Style getStyle(TIdentifier identifier)
        {
            if (identifier.IsPToken)
            {
                var e = identifier.GetFirstParent<PElement>();
                if (e == null || !e.HasElementname)
                    return tokenStyle;
                else
                    return greyStyle;
            }
            else if (identifier.IsPProduction)
            {
                var e = identifier.GetFirstParent<PElement>();
                if (e == null || !e.HasElementname)
                    return productionStyle;
                else
                    return greyStyle;
            }
            else if (identifier.IsPElement)
            {
                var id = identifier.AsPElement.Declaration.Elementid.Identifier;
                if (id.IsPToken)
                    return tokenStyle;
                else if (id.IsPProduction)
                    return productionStyle;
            }
            return null;
        }
    }
}
