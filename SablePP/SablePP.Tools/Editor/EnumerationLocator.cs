using SablePP.Tools.Analysis;
using SablePP.Tools.Nodes;
using System.Collections.Generic;

namespace SablePP.Tools.Editor
{
    public abstract class EnumerationLocator : IDeclarationLocator
    {
        public abstract Token FindDeclaration(Token token);

        public IEnumerable<Token> FindReferences(Token declaration, CodeTextBox.Result result)
        {
            foreach (var t in DepthFirstTreeWalker.GetTokens(result.Tree))
                if (IsReference(declaration, t))
                    yield return t;
        }
        protected abstract bool IsReference(Token declaration, Token token);
    }
}
