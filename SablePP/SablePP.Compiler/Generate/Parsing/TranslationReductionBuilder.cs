using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Compiler.Generate.Parsing
{
    public class TranslationReductionBuilder : ReductionBuilder
    {
        private readonly Dictionary<PTranslation, string> translationVariables;
        private readonly Dictionary<PElement, string> elementVariables;

        public TranslationReductionBuilder()
        {
            this.translationVariables = new Dictionary<PTranslation, string>();
            this.elementVariables = new Dictionary<PElement, string>();
        }

        private List<PElement> optionalElements;
        private int caseCounter;

        public override void CaseAAlternative(Nodes.AAlternative node)
        {
            this.optionalElements = node.Elements.Where(e => e.ElementType == ElementTypes.Question || e.ElementType == ElementTypes.Star).ToList();

            int max = 1 << optionalElements.Count;
            for (caseCounter = 0; caseCounter < max; caseCounter++)
            {
                CreateNewCase();

                var collection = node.Elements;
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    var element = collection[i];

                    PProduction production = element.Elementid.Identifier.AsPProduction;

                    if (IsOn(element))
                    {
                        string className = element.ClassName;

                        if (node.HasTranslation && (production == null || hasAstProduction(production)))
                            if (isList(element))
                            {
                                elementVariables[element] = GetVariable(className + "list");
                                code.EmitLine("List<{0}> {1} = Pop<List<{0}>>();", className, elementVariables[element]);
                            }
                            else
                            {
                                elementVariables[element] = GetVariable(className);
                                code.EmitLine("{0} {1} = Pop<{0}>();", className, elementVariables[element]);
                            }
                        else
                            code.EmitLine("Pop<object>();");
                    }
                }

                base.CaseAAlternative(node);

                if (node.HasTranslation)
                    code.EmitLine("Push({0}, {1});", GoTo, translationVariables[node.Translation]);
                else
                    code.EmitLine("Push({0}, new object());", GoTo);
            }
        }

        private bool IsOn(PElement node)
        {
            int index = optionalElements.IndexOf(node);
            return !(index >= 0 && ((1 << index) & caseCounter) == 0);
        }

        private bool hasAstProduction(PProduction production)
        {
            if (production.HasProdtranslation)
                return true;

            PGrammar grammar = production.GetFirstParent<PGrammar>();

            if (!grammar.HasAstproductions)
                return false;

            return grammar.Astproductions.Productions.Where(p => p.ClassName == production.ClassName).Any();
        }

        public override void CaseAFullTranslation(AFullTranslation node)
        {
            Visit(node.Translation);
            translationVariables[node] = translationVariables[node.Translation];
        }

        public override void CaseANullTranslation(ANullTranslation node)
        {
            translationVariables[node] = "null";
        }

        public override void CaseAListTranslation(AListTranslation node)
        {
            Visit(node.Elements);

            string className = getClassName(node.Elements[0].Translation);
            string varName = translationVariables[node] = GetVariable(className + "list");

            code.EmitLine("List<{0}> {1} = new List<{0}>();", className, varName);

            for (int i = 0; i < node.Elements.Count; i++)
            {
                var translation = node.Elements[i].Translation;
                var translationName = translationVariables[translation];

                if (translationName != "null")
                    if (isList(translation))
                        code.EmitLine("{0}.AddRange({1});", varName, translationName);
                    else
                        code.EmitLine("{0}.Add({1});", varName, translationName);
            }
        }

        public override void CaseAIdTranslation(AIdTranslation node)
        {
            var element = node.Identifier.AsPElement;
            if (IsOn(element))
                translationVariables[node] = elementVariables[element];
            else
                translationVariables[node] = "null";
        }
        public override void CaseAIddotidTranslation(AIddotidTranslation node)
        {
            var element = node.Identifier.AsPElement;
            if (IsOn(element))
                translationVariables[node] = elementVariables[element];
            else
                translationVariables[node] = "null";
        }

        public override void CaseANewTranslation(ANewTranslation node)
        {
            string className = "A" + node.Production.AsPProduction.ClassName.Substring(1);
            translationVariables[node] = GetVariable(className);

            Visit(node.Arguments);

            code.EmitLine("{0} {1} = new {0}(", className, translationVariables[node]);
            code.IncreaseIndentation();

            for (int i = 0; i < node.Arguments.Count; i++)
            {
                string arg = translationVariables[node.Arguments[i].Translation];
                code.EmitLine("{0}{1}", arg, i < node.Arguments.Count - 1 ? "," : "");
            }

            code.DecreaseIndentation();
            code.EmitLine(");");
        }
        public override void CaseANewalternativeTranslation(ANewalternativeTranslation node)
        {
            string className = node.Alternative.AsPAlternative.ClassName;
            translationVariables[node] = GetVariable(className);

            Visit(node.Arguments);

            code.EmitLine("{0} {1} = new {0}(", className, translationVariables[node]);
            code.IncreaseIndentation();

            for (int i = 0; i < node.Arguments.Count; i++)
            {
                string arg = translationVariables[node.Arguments[i].Translation];
                code.EmitLine("{0}{1}", arg, i < node.Arguments.Count - 1 ? "," : "");
            }

            code.DecreaseIndentation();
            code.EmitLine(");");
        }

        private string getClassName(PTranslation translation)
        {
            return getClassName((dynamic)translation);
        }

        private string getClassName(ANewTranslation translation)
        {
            return translation.Production.AsPProduction.ClassName;
        }
        private string getClassName(ANewalternativeTranslation translation)
        {
            return translation.Alternative.AsPAlternative.Production.ClassName;
        }
        private string getClassName(AIdTranslation translation)
        {
            var element = translation.Identifier.AsPElement;
            if (element.Elementid.Identifier.IsPAlternative)
                return element.Elementid.Identifier.AsPAlternative.Production.ClassName;
            else if (element.Elementid.Identifier.IsPProduction)
            {
                var p = element.Elementid.Identifier.AsPProduction;
                if (p != null && p.HasProdtranslation)
                    {
                        var id = p.Prodtranslation.Identifier;
                        if (id.IsPProduction)
                            return id.AsPProduction.ClassName;
                        else if (id.IsPToken)
                            return id.AsPToken.ClassName;
                        else
                            throw new InvalidOperationException();
                    }
                else
                    return element.Elementid.Identifier.AsPProduction.ClassName;
            }
            else if (element.Elementid.Identifier.IsPToken)
                return element.Elementid.Identifier.AsPToken.ClassName;
            else
                throw new System.NotImplementedException();
        }
        private string getClassName(AIddotidTranslation translation)
        {
            return translation.Production.AsPProduction.ClassName;
        }
        private string getClassName(AListTranslation translation)
        {
            return getClassName(translation.Elements[0].Translation);
        }

        private bool isList(PElement element)
        {
            if (!element.IsList)
            {
                var prod = element.Elementid.Identifier.AsPProduction;
                if (prod != null && prod.HasProdtranslation)
                {
                    var trans = prod.Prodtranslation;
                    return trans.HasModifier && (trans.Modifier is APlusModifier || trans.Modifier is AStarModifier);
                }
            }

            return element.IsList;
        }
        private bool isList(PTranslation translation)
        {
            return isList((dynamic)translation);
        }

        private bool isList(ANewTranslation translation)
        {
            return false;
        }
        private bool isList(ANewalternativeTranslation translation)
        {
            return false;
        }
        private bool isList(AIdTranslation translation)
        {
            return isList(translation.Identifier.AsPElement);
        }
        private bool isList(AIddotidTranslation translation)
        {
            return isList(translation.Identifier.AsPElement);
        }
        private bool isList(AListTranslation translation)
        {
            return true;
        }
        private bool isList(ANullTranslation translation)
        {
            return false;
        }
    }
}
