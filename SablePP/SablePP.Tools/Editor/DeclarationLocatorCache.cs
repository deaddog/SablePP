using SablePP.Tools.Nodes;
using System;

namespace SablePP.Tools.Editor
{
    internal class DeclarationLocatorCache : IDeclarationLocator
    {
        private IDeclarationLocator inner;
        private Token last;
        private Token declaration;

        public DeclarationLocatorCache(IDeclarationLocator inner)
        {
            if (inner == null)
                throw new ArgumentNullException("inner");

            this.inner = inner;
            this.last = null;
            this.declaration = null;
        }

        public IDeclarationLocator Inner
        {
            get { return inner; }
        }

        public Token FindDeclaration(Token token)
        {
            if (token != this.last)
            {
                this.last = token;
                this.declaration = inner.FindDeclaration(token);
            }

            return this.declaration;
        }
    }
}
