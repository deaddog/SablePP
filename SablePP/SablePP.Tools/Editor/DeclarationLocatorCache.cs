using SablePP.Tools.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Tools.Editor
{
    internal class DeclarationLocatorCache : IDeclarationLocator
    {
        private IDeclarationLocator inner;
        private Token last;

        private Token declaration;
        private Token[] references;

        public DeclarationLocatorCache(IDeclarationLocator inner)
        {
            if (inner == null)
                throw new ArgumentNullException("inner");

            this.inner = inner;
            this.last = null;
            this.declaration = null;
            this.references = null;
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
                this.references = null;
            }

            return this.declaration;
        }
        public IEnumerable<Token> FindReferences(Token declaration, CodeTextBox.Result result)
        {
            if (declaration != this.declaration)
                foreach (var t in inner.FindReferences(declaration, result))
                    yield return t;

            if (references == null)
                references = inner.FindReferences(declaration, result).ToArray();

            foreach (var t in references)
                yield return t;
        }
    }
}
