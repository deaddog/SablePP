using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class HighlightrulesTable : DeclarationTable<PHighlightrule>
    {
        protected override DeclarationIdentifier<PHighlightrule> construct(TIdentifier identifier, PHighlightrule declaration)
        {
            return new DeclarationIdentifier<PHighlightrule>(identifier, declaration);
        }

        protected override TIdentifier getIdentifier(PHighlightrule declaration)
        {
            return declaration.Name;
        }
    }
}
