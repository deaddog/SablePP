using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class ElementsTable : DeclarationTable<PElement>
    {
        protected override DeclarationIdentifier<PElement> construct(TIdentifier identifier, PElement declaration)
        {
            return new DeclarationIdentifier<PElement>(identifier, declaration);
        }

        protected override TIdentifier getIdentifier(PElement declaration)
        {
            if (declaration.HasElementname)
                return declaration.Elementname.Name;
            else
                return declaration.Elementid.Identifier;
        }
    }
}
