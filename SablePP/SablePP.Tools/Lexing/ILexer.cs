using SablePP.Tools.Nodes;

namespace SablePP.Tools.Lexing
{
    public interface ILexer
    {
        Token Peek();
        Token Next();
    }
}
