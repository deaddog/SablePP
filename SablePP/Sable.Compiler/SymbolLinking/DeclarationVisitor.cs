﻿using System;
using System.Collections.Generic;

using Sable.Compiler.Nodes;

using Sable.Tools.Error;

namespace Sable.Compiler.SymbolLinking
{
    public class DeclarationVisitor : Error.ErrorVisitor
    {
        public DeclarationVisitor(ErrorManager errorManager)
            : base(errorManager)
        {
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            DeclarationTables declarations = new DeclarationTables();

            if (node.HasHelpers)
                HelperVisitor.LoadHelperDeclarations(node.Helpers, declarations, this.ErrorManager);

            if (node.HasStates)
                StateVisitor.LoadStateDeclarations(node.States, declarations, this.ErrorManager);

            if (node.HasTokens)
                TokenVisitor.LoadTokenDeclarations(node.Tokens, declarations, this.ErrorManager);

            if (node.HasIgnoredtokens)
                IgnoredTokenVisitor.SetIgnoredTokens(node.Ignoredtokens, declarations, this.ErrorManager);

            if (node.HasProductions)
                ProductionVisitor.LoadProductionDeclarations(node.Productions, declarations, this.ErrorManager);

            if (node.HasAstproductions)
                ProductionVisitor.LoadProductionDeclarations(node.Astproductions, declarations, this.ErrorManager);

            if (node.HasProductions)
                TranslationVisitor.SetIdentifiersInTranslations(node.Productions, declarations, this.ErrorManager);
        }
    }
}
