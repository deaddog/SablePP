using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sable.Compiler.analysis;
using Sable.Compiler.node;
using Sable.Tools.Generate.CSharp;

namespace Sable.Compiler.Generate.Productions
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
        }

        public static FileElement BuildCode(Start astRoot)
        {
            ProductionNodes n = new ProductionNodes();
            astRoot.Apply(n);
            return n.fileElement;
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.GetPackage() != null)
                node.GetPackage().Apply(this);

            if (nameElement == null)
                nameElement = fileElement.CreateNamespace("SableCCPP.prods");

            if (node.GetAstproductions() != null)
                node.GetAstproductions().Apply(this);
            else if (node.GetProductions() != null)
                node.GetProductions().Apply(this);
        }

        public override void CaseTPackagename(TPackagename node)
        {
            nameElement = fileElement.CreateNamespace(node.Text + ".prods");
        }

        public override void CaseAProduction(AProduction node)
        {
            this.productionName = ToCamelCase(node.GetIdentifier().Text);
            string name = "P" + productionName;

            classElement = nameElement.CreateClass(name, AccessModifiers.@public | AccessModifiers.@abstract | AccessModifiers.partial, "Node<" + name + ">");
            base.CaseAProduction(node);
        }

        public override void CaseAAlternative(AAlternative node)
        {
            string name = "A" + productionName;
            if (node.GetAlternativename() != null)
                name = "A" + ToCamelCase((node.GetAlternativename() as AAlternativename).GetName().Text) + productionName;

            classElement = nameElement.CreateClass(name, AccessModifiers.@public | AccessModifiers.partial, "P" + productionName);

            node.Apply(new FieldBuilder(classElement));
            classElement.EmitNewLine();
            node.Apply(new ConstructorBuilder(classElement));
            classElement.EmitNewLine();
            node.Apply(new PropertiesBuilder(classElement));
            classElement.EmitNewLine();
            node.Apply(new ReplaceMethodBuilder(classElement));
            //apply
            classElement.EmitNewLine();
            node.Apply(new CloneMethodBuilder(classElement));
            node.Apply(new ToStringMethodBuilder(classElement));
        }
    }
}
