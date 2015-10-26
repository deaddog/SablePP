using SablePP.Tools.Nodes;
using System.Collections.Generic;

namespace SablePP.Tools.Editor
{
    public interface IDeclarationRenamer
    {
        IEnumerable<Token> FindRenamees(Token token, CodeTextBox.Result result);
        bool IsNameValid(Token token, string newName);
    }
}
