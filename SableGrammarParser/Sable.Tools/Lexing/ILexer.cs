using Sable.Tools.Nodes;

namespace Sable.Tools.Lexing
{
    public interface ILexer
    {
        Token Peek();
        Token Next();
    }
}
