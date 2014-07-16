using SablePP.Compiler.Generate.Productions;
using SablePP.Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Compiler.Generate.Parsing
{
    public class SimpleReductionBuilder : ReductionBuilder
    {
        private Dictionary<object, string> names;

        private string GetVariable(SablePP.Compiler.Generate.Productions.ProductionElement node)
        {
            string name;
            if (!names.TryGetValue(node, out name))
            {
                var type = node.ProductionOrTokenClass;
                name = GetVariable(type.ToLower());

                names.Add(node, name);
            }
            return name;
        }
        private string GetVariable(AAlternative node)
        {
            string name;
            if (!names.TryGetValue(node, out name))
            {
                var type = node.ClassName;
                name = GetVariable(type.ToLower());

                names.Add(node, name);
            }
            return name;
        }
        private string GetVariable(PElement node)
        {
            string name;
            if (!names.TryGetValue(node, out name))
            {
                var type = node.GeneratedTypeName;
                name = GetVariable(type.ToLower());

                names.Add(node, name);
            }
            return name;
        }

        public SimpleReductionBuilder()
            :base()
        {
            this.names = new Dictionary<object, string>();
        }

        private List<ProductionElement> questions;
        private int caseCounter;

        public override void CaseAAlternative(AAlternative node)
        {
            var elements = ProductionElement.GetAllElements(node);

            this.questions = elements.Where(x => x.ElementType == ElementTypes.Question || x.ElementType == ElementTypes.Star).ToList();

            int max = 1 << questions.Count;
            for (caseCounter = 0; caseCounter < max; caseCounter++)
            {
                CreateNewCase();

                for (int i = elements.Length - 1; i >= 0; i--)
                    Pop(elements[i], IsOn(elements[i], i));

                code.EmitLine("{0} {1} = new {0}(", node.ClassName, GetVariable(node));
                code.IncreaseIndentation();

                for (int i = 0; i < elements.Length; i++)
                {
                    code.EmitLine("{0}{1}", Argument(elements[i], IsOn(elements[i], i)), i < elements.Length - 1 ? "," : "");
                }

                code.DecreaseIndentation();
                code.EmitLine(");");

                code.EmitLine("Push({0}, {1});", GoTo, GetVariable(node));
            }
        }

        private bool IsOn(ProductionElement node, int index)
        {
            index = questions.IndexOf(node);
            return !(index >= 0 && ((1 << index) & caseCounter) == 0);
        }

        private void Pop(ProductionElement node, bool on)
        {
            switch (node.ElementType)
            {
                case ElementTypes.Simple:
                    var name = GetVariable(node);
                    code.EmitLine("{0} {1} = Pop<{0}>();", node.ProductionOrTokenClass, GetVariable(node));
                    break;

                case ElementTypes.Question:
                    int index = 1 << questions.IndexOf(node);
                    if ((index & caseCounter) > 0)
                        code.EmitLine("{0} {1} = Pop<{0}>();", node.ProductionOrTokenClass, GetVariable(node));
                    break;

                case ElementTypes.Plus:
                    code.EmitLine("List<{0}> {1} = Pop<List<{0}>>();", node.ProductionOrTokenClass, GetVariable(node));
                    break;

                case ElementTypes.Star:
                    if (on)
                        code.EmitLine("List<{0}> {1} = Pop<List<{0}>>();", node.ProductionOrTokenClass, GetVariable(node));
                    else
                        code.EmitLine("List<{0}> {1} = new List<{0}>();", node.ProductionOrTokenClass, GetVariable(node));
                    break;
            }
        }

        private string Argument(ProductionElement node, bool on)
        {
            switch (node.ElementType)
            {
                case ElementTypes.Simple:
                case ElementTypes.Plus:
                case ElementTypes.Star:
                    return GetVariable(node);
                case ElementTypes.Question:
                    if (on)
                        return GetVariable(node);
                    else
                        return null;
            }
            throw new InvalidOperationException("Unknown element type: " + node.ElementType);
        }
    }
}
