using SablePP.Tools.Nodes;
namespace SablePP.Tools.Editor
{
    public interface IDeclarationLocator
    {
        Token FindDeclaration(Token token);
    }
}
