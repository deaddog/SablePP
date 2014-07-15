using SablePP.Tools.Nodes;

namespace SablePP.Compiler.Nodes.Identifiers
{
    public abstract class DeclarationIdentifier<T> : TIdentifier where T : Production
    {
        private T declaration;

        public DeclarationIdentifier(TIdentifier identifier, T declaration)
            : base(identifier.Text, identifier.Line, identifier.Position)
        {
            this.declaration = declaration;
        }

        public T Declaration
        {
            get { return declaration; }
        }
    }
}
