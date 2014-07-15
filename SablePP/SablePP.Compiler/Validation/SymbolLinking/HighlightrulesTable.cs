using SablePP.Compiler.Nodes;
using SablePP.Compiler.Nodes.Identifiers;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class HighlightrulesTable : Table<HightlightruleIdentifier, PHighlightrule>
    {
        protected override HightlightruleIdentifier construct(TIdentifier identifier, PHighlightrule declaration)
        {
            return new HightlightruleIdentifier(identifier, declaration);
        }

        protected override TIdentifier getIdentifier(PHighlightrule declaration)
        {
            return declaration.Name;
        }
    }
}
