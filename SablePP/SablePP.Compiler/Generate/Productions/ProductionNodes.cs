using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sable.Compiler.Analysis;
using Sable.Compiler.Nodes;
using Sable.Tools.Generate.CSharp;
using Sable.Tools.Nodes;

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

            nameElement = fileElement.CreateNamespace(packageName + ".Nodes");
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

            classElement = nameElement.CreateClass(name, AccessModifiers.@public | AccessModifiers.@abstract | AccessModifiers.partial, "Production<" + name + ">");
            base.CaseAProduction(node);
        }

        public override void CaseAAlternative(AAlternative node)
        {
            string name = "A" + productionName;
            if(node.HasAlternativename)
                name = "A" + ToCamelCase((node.Alternativename as AAlternativename).Name.Text) + productionName;

            classElement = nameElement.CreateClass(name, AccessModifiers.@public | AccessModifiers.partial, "P" + productionName);

            new FieldBuilder(classElement).Visit(node);
            classElement.EmitNewLine();
            new ConstructorBuilder(classElement).Visit(node);
            classElement.EmitNewLine();
            new PropertiesBuilder(classElement).Visit(node);
            classElement.EmitNewLine();
            new ReplaceMethodBuilder(classElement).Visit(node);
            new GetChildrenMethodBuilder(classElement).Visit(node);
            classElement.EmitNewLine();
            new CloneMethodBuilder(classElement).Visit(node);
            new ToStringMethodBuilder(classElement).Visit(node);
        }
    }
}
