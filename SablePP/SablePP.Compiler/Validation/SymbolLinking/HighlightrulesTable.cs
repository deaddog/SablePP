﻿using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class HighlightrulesTable : DeclarationTable<PHighlightrule>
    {
        protected override DeclarationIdentifier<PHighlightrule> construct(TIdentifier identifier, PHighlightrule declaration)
        {
            return new DeclarationIdentifier<PHighlightrule>(identifier, declaration);
        }
    }
}
