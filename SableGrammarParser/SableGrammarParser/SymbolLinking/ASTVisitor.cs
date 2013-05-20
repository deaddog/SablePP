using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
{
    public class ASTVisitor : BaseProductionVisitor<DAProduction, DAAlternative>
    {
        private string production;
        private DAAlternative alternative;

        public ASTVisitor(IEnumerable<KeyValuePair<string, DToken>> tokens)
            : base(tokens, false)
        {
        }

        protected override DAProduction Construct(AProduction node)
        {
            return new DAProduction(node);
        }
        protected override DAAlternative Construct(AAlternativename node)
        {
            return new DAAlternative(node);
        }

        public override void InAProduction(AProduction node)
        {
            production = node.GetIdentifier().Text;
        }
        public override void OutAProduction(AProduction node)
        {
            if (node.GetProdtranslation() != null)
                RegisterError(node.GetProdtranslation(), "AST nodes cannot be translated.");

            production = null;
        }
        public override void OutAAlternativename(AAlternativename node)
        {
            alternative = GetAlternativeName(node.GetName().Text);
        }
        public override void OutAAlternative(AAlternative node)
        {
            base.OutAAlternative(node);
            alternative = null;
        }

        public override void InAProductions(AProductions node)
        {
            base.InAProductions(node);
        }

        public override void CaseAFullTranslation(AFullTranslation node)
        {
            base.CaseAFullTranslation(node);
            RegisterError(node, "AST nodes cannot be translated.");
        }
    }
}
