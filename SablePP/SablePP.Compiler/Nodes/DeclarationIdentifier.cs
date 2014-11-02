using SablePP.Tools.Nodes;

namespace SablePP.Compiler.Nodes
{
    public class DeclarationIdentifier<T> : DeclarationIdentifier where T : Production, IDeclaration
    {
        public DeclarationIdentifier(TIdentifier identifier, T declaration)
            : base(identifier.Text, identifier.Line, identifier.Position, declaration)
        {
        }

        new public T Declaration
        {
            get { return base.Declaration as T; }
        }
    }

    public class DeclarationIdentifier : TIdentifier
    {
        private IDeclaration declaration;

        public DeclarationIdentifier(string text, int line, int position, IDeclaration declaration)
            : base(text, line, position)
        {
            this.declaration = declaration;
        }

        public IDeclaration Declaration
        {
            get { return declaration; }
            protected set { declaration = value; }
        }
    }
}
