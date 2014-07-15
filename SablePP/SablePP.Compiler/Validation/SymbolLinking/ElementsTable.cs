using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class ElementsTable : Table<ElementIdentifier, PElement>
    {
        protected override ElementIdentifier construct(TIdentifier identifier, PElement declaration)
        {
            return new ElementIdentifier(identifier, declaration);
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
