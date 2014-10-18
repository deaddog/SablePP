using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal partial class BProduction
    {
        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private ClassElement classElement;

        private BProduction()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Collections.Generic");
            fileElement.Using.Add(SablePP.Generate.Namespaces.Nodes);
        }

        public static FileElement BuildCode(Grammar node)
        {
            BProduction n = new BProduction();
            n.Visit(node);
            return n.fileElement;
        }

        private void Visit(Grammar node)
        {
            fileElement.Add(nameElement = new NameSpaceElement(node.Namespace + ".Nodes"));
            fileElement.Using.Add(node.Namespace + ".Analysis");

            foreach (var prod in node.AbstractProductions)
                Visit(prod);
        }

        private void Visit(AbstractProduction node)
        {
            nameElement.Add(classElement = new ClassElement("public abstract partial class {0} : Production<{0}>", node.Name));

            FieldBuilder.Emit(classElement, node);
            ConstructorBuilder.Emit(classElement, node);
            PropertiesBuilder.Emit(classElement, node);
        }

        private void Visit(AbstractAlternative node)
        {
            nameElement.Add(classElement = new ClassElement("public partial class {0} : P{1}", node.Name, node.Production.Name));

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
