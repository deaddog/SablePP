using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate.CSharp;

namespace SablePP.Compiler.Generate.Productions
{
    public class CloneMethodBuilder : ProductionVisitor
    {
        private MethodElement method;

        public static void Emit(ClassElement classElement, AAlternative node)
        {
            var elements = ProductionElement.GetAllElements(node);

            CloneMethodBuilder builder = new CloneMethodBuilder();
            classElement.Add(builder.method = new MethodElement("public override {0} Clone()", true, node.ProductionName));

            builder.method.Body.Emit("return new {0}(", classElement.Name);
            for (int i = 0; i < elements.Length; i++)
            {
                if (i > 0)
                    builder.method.Body.Emit(", ");
                builder.emitElement(elements[i]);
            }
            builder.method.Body.EmitLine(");");

            classElement.EmitNewline();
        }

        private void emitElement(ProductionElement node)
        {
            method.Body.Emit(node.PropertyName);

            switch (node.ElementType)
            {
                case ElementTypes.Simple:
                case ElementTypes.Question:
                    method.Body.Emit(".Clone()");
                    break;
            }
        }
    }
}
