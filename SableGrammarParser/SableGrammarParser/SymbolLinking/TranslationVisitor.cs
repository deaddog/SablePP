using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
{
    public class TranslationVisitor : DeclarationVisitor
    {
        private LookupDictionary<string, DProduction> astProductions;

        public TranslationVisitor(IDictionary<string, DProduction> astProductions)
        {
            this.astProductions = new LookupDictionary<string, DProduction>(astProductions);
        }

        public override void CaseAAlternative(AAlternative node)
        {
            StartVisitor(new AlternativeVisitor(astProductions), node);
        }

        public override void InACleanProdtranslation(ACleanProdtranslation node)
        {
            linkAst(node.GetIdentifier());

            base.InACleanProdtranslation(node);
        }
        public override void InAStarProdtranslation(AStarProdtranslation node)
        {
            linkAst(node.GetIdentifier());

            base.InAStarProdtranslation(node);
        }
        public override void InAPlusProdtranslation(APlusProdtranslation node)
        {
            linkAst(node.GetIdentifier());

            base.InAPlusProdtranslation(node);
        }
        public override void InAQuestionProdtranslation(AQuestionProdtranslation node)
        {
            linkAst(node.GetIdentifier());

            base.InAQuestionProdtranslation(node);
        }
        private void linkAst(TIdentifier identifier)
        {
            DProduction production = null;
            if (astProductions.TryGetValue(identifier.Text, out production))
                identifier.SetDeclaration(production);
            else
                RegisterError(identifier, "The AST node {0} has not been defined.", identifier);
        }

        private class AlternativeVisitor : DeclarationVisitor
        {
            private LookupDictionary<string, DProduction> astProductions;
            private AAlternative alternative = null;

            public AlternativeVisitor(LookupDictionary<string, DProduction> astProductions)
            {
                this.astProductions = astProductions;
            }

            public override void InAAlternative(AAlternative node)
            {
                this.alternative = node;

                base.InAAlternative(node);
            }

            public override void InANewTranslation(ANewTranslation node)
            {
                DProduction production = null;
                if (astProductions.TryGetValue(node.GetProduction().Text, out production))
                    node.GetProduction().SetDeclaration(production);
                else
                    RegisterError(node.GetProduction(), "The AST node {0} has not been defined.", node.GetProduction());

                base.InANewTranslation(node);
            }
            public override void InANewalternativeTranslation(ANewalternativeTranslation node)
            {
                DProduction production = null;
                if (astProductions.TryGetValue(node.GetProduction().Text, out production))
                {
                    node.GetProduction().SetDeclaration(production);

                    LookupDictionary<string, DAlternativeName> alternatives = AlternativesLocater.Alternatives(production);
                    DAlternativeName alternative = null;
                    if (alternatives.TryGetValue(node.GetAlternative().Text, out alternative))
                        node.GetAlternative().SetDeclaration(alternative);
                    else
                        RegisterError(node.GetAlternative(), "The AST alternative {0} has not been defined.", node.GetAlternative());
                }
                else
                    RegisterError(node.GetProduction(), "The AST node {0} has not been defined.", node.GetProduction());

                base.InANewalternativeTranslation(node);
            }

            public override void InAIdTranslation(AIdTranslation node)
            {
                Declaration declaration = ElementLocater.Declaration(alternative, node.GetIdentifier());
                if (declaration != null)
                    node.GetIdentifier().SetDeclaration(declaration);

                base.InAIdTranslation(node);
            }
            public override void InAIddotidTranslation(AIddotidTranslation node)
            {
                Declaration declaration = ElementLocater.Declaration(alternative, node.GetIdentifier());
                if (declaration != null)
                    node.GetIdentifier().SetDeclaration(declaration);

                DProduction production = null;
                if (astProductions.TryGetValue(node.GetProduction().Text, out production))
                    node.GetProduction().SetDeclaration(production);
                else
                    RegisterError(node.GetProduction(), "The AST node {0} has not been defined.", node.GetProduction());

                base.InAIddotidTranslation(node);
            }
        }

        private class AlternativesLocater : DeclarationVisitor
        {
            private Dictionary<string, DAlternativeName> alternatives;

            private AlternativesLocater()
            {
                this.alternatives = new Dictionary<string, DAlternativeName>();
            }

            public static LookupDictionary<string, DAlternativeName> Alternatives(DProduction production)
            {
                AlternativesLocater locater = new AlternativesLocater();
                production.Production.Apply(locater);
                return new LookupDictionary<string, DAlternativeName>(locater.alternatives);
            }

            public override void CaseAAlternativename(AAlternativename node)
            {
                if (node.GetName().IsAlternativeName)
                    alternatives.Add(node.GetName().Text, node.GetName().AsAlternativeName);
            }
        }

        private class ElementLocater : DeclarationVisitor
        {
            private bool lookingForName = true;
            private bool looking = true;
            private string lookFor;
            private Declaration result;

            private ElementLocater(TIdentifier identifier)
                : this(identifier.Text)
            {
            }
            private ElementLocater(string lookFor)
            {
                this.lookFor = lookFor;
                this.result = null;
            }

            public static Declaration Declaration(AAlternative alternative, TIdentifier identifier)
            {
                ElementLocater locater = new ElementLocater(identifier);
                alternative.Apply(locater);
                locater.lookingForName = false;
                if (locater.looking)
                    alternative.Apply(locater);
                return locater.result;
            }

            public override void CaseAElementname(AElementname node)
            {
                if (looking && lookingForName && node.GetName().Text == lookFor)
                {
                    looking = false;
                    result = node.GetName().Declaration;
                }
            }

            public override void CaseACleanElementid(ACleanElementid node)
            {
                if (looking && !lookingForName && node.GetIdentifier().Text == lookFor)
                {
                    looking = false;
                    result = node.GetIdentifier().Declaration;
                }
                else
                    base.CaseACleanElementid(node);
            }
            public override void CaseATokenElementid(ATokenElementid node)
            {
                if (looking && !lookingForName && node.GetIdentifier().Text == lookFor)
                {
                    looking = false;
                    result = node.GetIdentifier().Declaration;
                }
                else
                    base.CaseATokenElementid(node);
            }
            public override void CaseAProductionElementid(AProductionElementid node)
            {
                if (looking && !lookingForName && node.GetIdentifier().Text == lookFor)
                {
                    looking = false;
                    result = node.GetIdentifier().Declaration;
                }
                else
                    base.CaseAProductionElementid(node);
            }
        }
    }
}
