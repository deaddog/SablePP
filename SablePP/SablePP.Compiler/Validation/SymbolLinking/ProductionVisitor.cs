using System;
using System.Collections.Generic;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Error;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class ProductionVisitor : DeclarationVisitor
    {
        private DeclarationTables.DeclarationTable<DToken> tokens;
        private DeclarationTables.DeclarationTable<DProduction> productions;
        private DeclarationTables.DeclarationTable<DAlternativeName> alternatives;
        private DeclarationTables.DeclarationTable<DElementName> elements;

        private AAlternative currentAlternative;

        private ProductionVisitor(DeclarationTables declarations, ErrorManager errorManager, bool ast)
            : base(errorManager)
        {
            this.tokens = declarations.Tokens;
            this.productions = ast ? declarations.AstProductions : declarations.Productions;

            this.alternatives = null;
            this.elements = null;
        }

        public static void LoadProductionDeclarations(PProductions node, DeclarationTables declarations, ErrorManager errorManager)
        {
            new ProductionVisitor(declarations, errorManager, false).Visit(node);
        }
        public static void LoadProductionDeclarations(PAstproductions node, DeclarationTables declarations, ErrorManager errorManager)
        {
            new ProductionVisitor(declarations, errorManager, true).Visit(node);
        }

        public override void InAProductions(AProductions node)
        {
            foreach (var p in node.Productions)
                if (p is AProduction)
                {
                    AProduction prod = p as AProduction;
                    if (!productions.Declare(prod.Identifier))
                        RegisterError(prod.Identifier, "Production {0} has already been defined (line {1}).", prod.Identifier, productions[prod.Identifier].DeclarationToken.Line);
                }
                else
                    throw new Exception("Unknown production type.");
        }
        public override void InAAstproductions(AAstproductions node)
        {
            foreach (var p in node.Productions)
                if (p is AProduction)
                {
                    AProduction prod = p as AProduction;
                    if (!productions.Declare(prod.Identifier))
                        RegisterError(prod.Identifier, "AST production {0} has already been defined (line {1}).", prod.Identifier, productions[prod.Identifier].DeclarationToken.Line);
                }
                else
                    throw new Exception("Unknown production type.");
        }
        public override void InAProduction(AProduction node)
        {
            alternatives = new DeclarationTables.DeclarationTable<DAlternativeName>(id => new DAlternativeName(id));
            base.InAProduction(node);
        }
        public override void InAAlternative(AAlternative node)
        {
            elements = new DeclarationTables.DeclarationTable<DElementName>(id => new DElementName(id));
            this.currentAlternative = node;

            base.InAAlternative(node);
        }
        public override void InAAlternativename(AAlternativename node)
        {
            if (!alternatives.Declare(node.Name))
                RegisterError(node.Name, "Production alternative {0} is already in use (line {1}).", node.Name, alternatives[node.Name].DeclarationToken.Line);

            base.InAAlternativename(node);
        }

        public override void InAElementname(AElementname node)
        {
            if(!elements.Declare(node.Name))
                RegisterError(node.Name, "Element name {0} is already in use in this production.", node.Name);

            base.InAElementname(node);
        }
        public override void InACleanElementid(ACleanElementid node)
        {
            TIdentifier ident = node.Identifier;
            string text = ident.Text;

            if (tokens.Contains(text) && productions.Contains(text))
                RegisterError(ident, "Unable to determine if {0} refers to a token or a production. Use T.{1} or P.{1} to specify.", ident, text);
            else if (tokens.Link(ident))
            {
                if (tokens[text].Ignored)
                    RegisterError(node, "The ignored token {0} cannot be used in a production.", ident);
            }
            else if (!productions.Link(ident))
                RegisterError(ident, "The token or production {0} has not been defined.", ident);

            base.InACleanElementid(node);
        }
        public override void InATokenElementid(ATokenElementid node)
        {
            if (tokens.Link(node.Identifier))
            {
                if (tokens[node.Identifier.Text].Ignored)
                    RegisterError(node, "The ignored token {0} cannot be used in a production.", node.Identifier);
            }
            else
                RegisterError(node.Identifier, "The token {0} has not been defined.", node.Identifier);

            base.InATokenElementid(node);
        }
        public override void InAProductionElementid(AProductionElementid node)
        {
            if (!productions.Link(node.Identifier))
                RegisterError(node.Identifier, "The production {0} has not been defined.", node.Identifier);

            base.InAProductionElementid(node);
        }
    }
}
