using SablePP.Tools.Nodes;
using System.Collections.Generic;
namespace SablePP.Tools.Editor
{
    public interface IDeclarationLocator
    {
        Token FindDeclaration(Token token);
        IEnumerable<Token> FindReferences(Token declaration, CodeTextBox.Result result);
    }
}
