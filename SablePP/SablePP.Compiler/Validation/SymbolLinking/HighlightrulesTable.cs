using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class HighlightrulesTable : DeclarationTable<HighlightruleIdentifier, PHighlightrule>
    {
        protected override HighlightruleIdentifier construct(TIdentifier identifier, PHighlightrule declaration)
        {
            return new HighlightruleIdentifier(identifier, declaration);
        }

        protected override TIdentifier getIdentifier(PHighlightrule declaration)
        {
            return declaration.Name;
        }
    }
}
