namespace SablePP.Compiler.Nodes.Identifiers
{
    public class StateIdentifier : TIdentifier
    {
        private StateIdentifier declaration;
        private bool first;

        public StateIdentifier(TIdentifier identifier, bool first)
            : base(identifier.Text, identifier.Line, identifier.Position)
        {
            this.declaration = this;
            this.first = first;
        }

        public StateIdentifier(TIdentifier identifier, StateIdentifier declaration)
            : base(identifier.Text, identifier.Line, identifier.Position)
        {
            this.declaration = declaration;
            this.first = declaration.first;
        }

        public bool IsDeclaration
        {
            get { return this.declaration == this; }
        }

        public StateIdentifier Declaration
        {
            get { return declaration; }
        }

        public bool IsFirst
        {
            get { return first; }
        }
    }
}
