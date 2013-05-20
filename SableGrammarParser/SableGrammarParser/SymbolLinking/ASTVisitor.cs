using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
{
    public class ASTVisitor : BaseProductionVisitor<DAProduction, DAAlternative>
    {
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

        public override void CaseAProduction(AProduction node)
        {
            base.CaseAProduction(node);
            if (node.GetProdtranslation() != null)
                RegisterError(node.GetProdtranslation(), "AST nodes cannot be translated.");
        }
        public override void CaseAFullTranslation(AFullTranslation node)
        {
            base.CaseAFullTranslation(node);
            RegisterError(node, "AST nodes cannot be translated.");
        }
    }
}
