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
                            if (element.GeneratesAsList)
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

            string className = node.ClassName;
            string varName = translationVariables[node] = GetVariable(className + "list");

            code.EmitLine("List<{0}> {1} = new List<{0}>();", className, varName);

            for (int i = 0; i < node.Elements.Count; i++)
            {
                var translation = node.Elements[i];
                var translationName = translationVariables[translation];

                if (translationName != "null")
                    if (translation.IsList)
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
                string arg = translationVariables[node.Arguments[i]];
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
                string arg = translationVariables[node.Arguments[i]];
                code.EmitLine("{0}{1}", arg, i < node.Arguments.Count - 1 ? "," : "");
            }

            code.DecreaseIndentation();
            code.EmitLine(");");
        }
    }
}
