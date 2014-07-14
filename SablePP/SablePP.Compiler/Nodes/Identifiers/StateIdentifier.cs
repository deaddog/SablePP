namespace SablePP.Compiler.Nodes.Identifiers
{
    public class StateIdentifier : TIdentifier
    {
        private StateIdentifier declaration;

        public StateIdentifier(TIdentifier identifier, StateIdentifier declaration)
            : base(identifier.Text, identifier.Line, identifier.Position)
        {
            if (declaration == null)
                this.declaration = this;
            else
                this.declaration = declaration;
        }

        public bool IsDeclaration
        {
            get { return this.declaration == this; }
        }

        public StateIdentifier Declaration
        {
            get { return declaration; }
        }
    }
}
