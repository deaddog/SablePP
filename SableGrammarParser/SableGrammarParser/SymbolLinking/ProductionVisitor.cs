using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
{
    public class ProductionVisitor : BaseProductionVisitor<DProduction, DAlternative>
    {
        private Dictionary<string, DAProduction> astProductions;

        public ProductionVisitor(IEnumerable<KeyValuePair<string, DToken>> tokens,
                                 IEnumerable<KeyValuePair<string, DAProduction>> astProductions)
            : base(tokens, true)
        {
            this.astProductions = new Dictionary<string, DAProduction>();
            foreach (var a in astProductions)
                this.astProductions.Add(a.Key, a.Value);
        }

        protected override DProduction Construct(AProduction node)
        {
            return new DProduction(node);
        }
        protected override DAlternative Construct(AAlternativename node)
        {
            return new DAlternative(node);
        }

        public override void CaseACleanProdtranslation(ACleanProdtranslation node)
        {
            CasePProdtranslation(node.GetIdentifier());
        }
        public override void CaseAStarProdtranslation(AStarProdtranslation node)
        {
            CasePProdtranslation(node.GetIdentifier());
        }
        public override void CaseAPlusProdtranslation(APlusProdtranslation node)
        {
            CasePProdtranslation(node.GetIdentifier());
        }
        public override void CaseAQuestionProdtranslation(AQuestionProdtranslation node)
        {
            CasePProdtranslation(node.GetIdentifier());
        }
        private void CasePProdtranslation(TIdentifier identifier)
        {
            DAProduction declaration = null;
            if (astProductions.TryGetValue(identifier.Text, out declaration))
                identifier.SetDeclaration(declaration);
            else
                RegisterError(identifier, "The AST production {0} has not been defined.", identifier);
        }
    }
}
