using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate;
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

        public override void CaseAAlternative(Nodes.AAlternative node)
        {
            CreateNewCase();

            var collection = node.Elements.Element;
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                var element = collection[i];
                string className = element.ClassName;
                elementVariables[element] = GetVariable(className);

                PProduction production = element.Elementid.Identifier.AsPProduction;

                if (node.HasTranslation && (production == null || hasAstProduction(production)))
                    code.EmitLine("{0} {1} = Pop<{0}>();", className, elementVariables[element]);
                else
                    code.EmitLine("Pop<object>();");
            }

            base.CaseAAlternative(node);

            if (node.HasTranslation)
                code.EmitLine("Push({0}, {1});", GoTo, translationVariables[node.Translation]);
            else
                code.EmitLine("Push({0}, new object());", GoTo);
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

        public override void CaseAIdTranslation(AIdTranslation node)
        {
            var element = node.Identifier.AsPElement.Declaration;
            translationVariables[node] = elementVariables[element];
        }
        public override void CaseAIddotidTranslation(AIddotidTranslation node)
        {
            var element = node.Identifier.AsPElement.Declaration;
            translationVariables[node] = elementVariables[element];
        }

        public override void CaseANewTranslation(ANewTranslation node)
        {
            string className = "A" + node.Production.AsPProduction.ClassName.Substring(1);
            translationVariables[node] = GetVariable(className);

            code.EmitLine("{0} {1} = new {0}(", className, translationVariables[node]);
            code.IncreaseIndentation();


            Visit(node.Arguments);
            var args = node.Arguments.Listitem;

            for (int i = 0; i < args.Count; i++)
            {
                string arg = translationVariables[(args[i] as ATranslationListitem).Translation];
                code.EmitLine("{0}{1}", arg, i < args.Count - 1 ? "," : "");
            }

            code.DecreaseIndentation();
            code.EmitLine(");");
        }
        public override void CaseANewalternativeTranslation(ANewalternativeTranslation node)
        {
            string className = node.Alternative.AsPAlternative.ClassName;
            translationVariables[node] = GetVariable(className);

            code.EmitLine("{0} {1} = new {0}(", className, translationVariables[node]);
            code.IncreaseIndentation();


            Visit(node.Arguments);
            var args = node.Arguments.Listitem;

            for (int i = 0; i < args.Count; i++)
            {
                string arg = translationVariables[(args[i] as ATranslationListitem).Translation];
                code.EmitLine("{0}{1}", arg, i < args.Count - 1 ? "," : "");
            }

            code.DecreaseIndentation();
            code.EmitLine(");");
        }
    }
}
