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
        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private ClassElement classElement;
        private string productionName;

        private ProductionNodes()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Collections.Generic");
            fileElement.Using.Add(SablePP.Generate.Namespaces.Nodes);
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

            FieldBuilder.Emit(classElement, node);
            ConstructorBuilder.Emit(classElement, node);
            PropertiesBuilder.Emit(classElement, node);

            base.CaseAProduction(node);
        }

        public override void CaseAAlternative(AAlternative node)
        {
            string name = "A" + productionName;
            if (node.HasAlternativename)
                name = "A" + ToCamelCase((node.Alternativename as AAlternativename).Name.Text) + productionName;

            nameElement.Add(classElement = new ClassElement("public partial class {0} : P{1}", name, productionName));

            FieldBuilder.Emit(classElement, node);
            ConstructorBuilder.Emit(classElement, node);
            PropertiesBuilder.Emit(classElement, node);
            ReplaceMethodBuilder.Emit(classElement, node);
            GetChildrenMethodBuilder.Emit(classElement, node);
            CloneMethodBuilder.Emit(classElement, node);
            ToStringMethodBuilder.Emit(classElement, node);
        }
    }
}
