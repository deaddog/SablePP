using SablePP.Tools.Nodes;

namespace SablePP.Compiler.Nodes.Identifiers
{
    public class DeclarationIdentifier<T> : DeclarationIdentifier where T : Production
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
        private Node declaration;

        public DeclarationIdentifier(string text, int line, int position, Node declaration)
            : base(text, line, position)
        {
            this.declaration = declaration;
        }

        public DeclarationIdentifier(string text, int line, int position)
            : this(text, line, position, null)
        {
        }

        public Node Declaration
        {
            get { return declaration; }
            protected set { declaration = value; }
        }
    }
}
