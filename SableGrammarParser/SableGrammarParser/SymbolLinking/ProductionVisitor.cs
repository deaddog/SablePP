using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
{
    public class ProductionVisitor : BaseProductionVisitor
    {
        private Dictionary<string, DProduction> astProductions;

        public ProductionVisitor(IEnumerable<KeyValuePair<string, DToken>> tokens,
                                 IEnumerable<KeyValuePair<string,DProduction>> astProductions)
            : base(tokens, true)
        {
            this.astProductions = new Dictionary<string, DProduction>();
            foreach (var a in astProductions)
                this.astProductions.Add(a.Key, a.Value);
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
            DProduction declaration = null;
            if (astProductions.TryGetValue(identifier.Text, out declaration))
                identifier.SetDeclaration(declaration);
            else
                RegisterError(identifier, "The AST production {0} has not been defined.", identifier);
        }
    }
}
