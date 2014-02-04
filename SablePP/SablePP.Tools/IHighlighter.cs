using FastColoredTextBoxNS;
using SablePP.Tools.Nodes;

namespace SablePP.Tools
{
    public interface IHighlighter
    {
        Style GetStyle(Token token);
    }
}
