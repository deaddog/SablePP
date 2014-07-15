using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class HelpersTable : Table<HelperIdentifier, PHelper>
    {
        protected override HelperIdentifier construct(TIdentifier identifier, PHelper declaration)
        {
            return new HelperIdentifier(identifier, declaration);
        }

        protected override TIdentifier getIdentifier(PHelper declaration)
        {
            return declaration.Identifier;
        }
    }
}
