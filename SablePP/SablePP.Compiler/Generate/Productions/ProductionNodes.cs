using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate.CSharp;
using SablePP.Tools.Nodes;

namespace SablePP.Compiler.Generate.Productions
{
    public class ProductionNodes : ProductionVisitor
    {
        #region Production Elements Analysis

        private Dictionary<string, ElementTypes> getSharedElements(AProduction node)
        {
            var alternatives = (node.Productionrule as AProductionrule).Alternatives;

            var e = getDictionary(alternatives[0] as AAlternative);
            for (int i = 1; i < alternatives.Count; i++)
            {
                foreach (var r in getUndefined(e.ToArray(), alternatives[i] as AAlternative))
                    e.Remove(r);
            }

            return e;
        }

        private Dictionary<string, ElementTypes> getDictionary(AAlternative node)
        {
            Dictionary<string, ElementTypes> dict = new Dictionary<string, ElementTypes>();

            foreach (var element in (node.Elements as AElements).Element)
            {
                var name = GetPropertyName(element);
                var type = element.GetElementType();

                dict.Add(name, type);
            }

            return dict;
        }
        private IEnumerable<string> getUndefined(KeyValuePair<string, ElementTypes>[] existing, AAlternative node)
        {
            var dict = getDictionary(node);

            foreach (var v in existing)
            {
                if (!dict.ContainsKey(v.Key))
                    yield return v.Key;
                else if (dict[v.Key] != v.Value)
                    yield return v.Key;
            }
        }

        #endregion

        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private ClassElement classElement;
        private string productionName;

        private ProductionNodes()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Collections.Generic");
            fileElement.Using.Add(ToolsNamespace.Nodes);
        }

        public static FileElement BuildCode(Start<PGrammar> astRoot)
        {
            ProductionNodes n = new ProductionNodes();
            n.Visit(astRoot);
            return n.fileElement;
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            string packageName = node.PackageName;

            fileElement.Add(nameElement = new NameSpaceElement(packageName + ".Nodes"));
            fileElement.Using.Add(packageName + ".Analysis");

            if (node.HasAstproductions)
                Visit(node.Astproductions);
            else if (node.HasProductions)
                Visit(node.Productions);
        }

        public override void CaseAProduction(AProduction node)
        {
            this.productionName = ToCamelCase(node.Identifier.Text);
            string name = "P" + productionName;

            nameElement.Add(classElement = new ClassElement("public abstract partial class {0} : Production<{0}>", name));
            base.CaseAProduction(node);
        }

        public override void CaseAAlternative(AAlternative node)
        {
            string name = "A" + productionName;
            if (node.HasAlternativename)
                name = "A" + ToCamelCase((node.Alternativename as AAlternativename).Name.Text) + productionName;

            nameElement.Add(classElement = new ClassElement("public partial class {0} : P{1}", name, productionName));

            new FieldBuilder(classElement).Visit(node);
            classElement.EmitNewline();
            new ConstructorBuilder(classElement).Visit(node);
            classElement.EmitNewline();
            new PropertiesBuilder(classElement).Visit(node);
            classElement.EmitNewline();
            new ReplaceMethodBuilder(classElement).Visit(node);
            new GetChildrenMethodBuilder(classElement).Visit(node);
            classElement.EmitNewline();
            new CloneMethodBuilder(classElement, "P" + productionName).Visit(node);
            new ToStringMethodBuilder(classElement).Visit(node);
        }
    }
}
