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

        private IEnumerable<ProductionElement> getSharedElements(AProduction node)
        {
            var alternatives = (node.Productionrule as AProductionrule).Alternatives;

            var shared = getElements(alternatives[0] as AAlternative).ToList();

            for (int i = 1; i < alternatives.Count; i++)
            {
                var elements = getElements(alternatives[i] as AAlternative);

                for (int s = 0; s < shared.Count; s++)
                {
                    var t = elements.FirstOrDefault(x => x.PropertyName == shared[s].PropertyName);
                    if (t == null || t.ElementType != shared[s].ElementType)
                        shared.RemoveAt(s--);
                }
            }

            foreach (var s in shared)
                yield return s;
        }

        private IEnumerable<ProductionElement> getElements(AAlternative node)
        {
            var eP = (node.Elements as AElements).Element;

            PElement[] elements = new PElement[eP.Count];
            eP.CopyTo(elements, 0);

            for (int i = 0; i < elements.Length; i++)
                yield return new ProductionElement(elements[i]);
        }
        private IEnumerable<ProductionElement> getUndefined(IEnumerable<ProductionElement> existing, AAlternative node)
        {
            var elements = getElements(node);

            foreach (var v in existing)
            {
                var e = elements.FirstOrDefault(x => x.PropertyName == v.PropertyName);
                if (e == null)
                    yield return v;
                else if (e.ElementType != v.ElementType)
                    yield return v;
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
