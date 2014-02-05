using FastColoredTextBoxNS;
using SablePP.Compiler.Nodes;
using SablePP.Tools;

namespace SablePP.Compiler.Execution
{
    public class IdentifierHighlighter : IHighlighter
    {
        Style IHighlighter.GetStyle(Tools.Nodes.Token token)
        {
            if (token is TIdentifier)
                return getStyle(token as TIdentifier);
            else
                return null;
        }

        private Style getStyle(TIdentifier identifier)
        {
            return null;
        }
    }
}
