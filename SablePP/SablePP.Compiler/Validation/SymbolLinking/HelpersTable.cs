using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class HelpersTable : DeclarationTable<PHelper>
    {
        protected override DeclarationIdentifier<PHelper> construct(TIdentifier identifier, PHelper declaration)
        {
            return new DeclarationIdentifier<PHelper>(identifier, declaration);
        }

        protected override TIdentifier getIdentifier(PHelper declaration)
        {
            return declaration.Identifier;
        }
    }
}
