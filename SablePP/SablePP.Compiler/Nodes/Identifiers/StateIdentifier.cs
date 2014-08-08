namespace SablePP.Compiler.Nodes.Identifiers
{
    public class StateIdentifier : DeclarationIdentifier
    {
        private bool first;

        public StateIdentifier(TIdentifier identifier, bool first)
            : base(identifier.Text, identifier.Line, identifier.Position)
        {
            base.Declaration = this;
            this.first = first;
        }

        public StateIdentifier(TIdentifier identifier, StateIdentifier declaration)
            : base(identifier.Text, identifier.Line, identifier.Position)
        {
            base.Declaration = declaration;
            this.first = declaration.first;
        }

        public bool IsDeclaration
        {
            get { return this.Declaration == this; }
        }

        new public StateIdentifier Declaration
        {
            get { return base.Declaration as StateIdentifier; }
        }

        public bool IsFirst
        {
            get { return first; }
        }
    }
}
