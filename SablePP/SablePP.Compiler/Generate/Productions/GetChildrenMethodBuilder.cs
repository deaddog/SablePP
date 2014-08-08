using SablePP.Tools.Generate.CSharp;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Generate.Productions
{
    public class GetChildrenMethodBuilder
    {
        private MethodElement method;

        public static void Emit(ClassElement classElement, AAlternative node)
        {
            var elements = ProductionElement.GetAllElements(node);

            GetChildrenMethodBuilder builder = new GetChildrenMethodBuilder();
            classElement.Add(builder.method = new MethodElement("protected override IEnumerable<Node> GetChildren()"));

            foreach (var e in elements)
                builder.emitElement(e);

            classElement.EmitNewline();
        }

        private void emitElement(ProductionElement node)
        {
            switch (node.ElementType)
            {
                case ElementTypes.Simple:
                    method.Body.EmitLine("yield return {0};", node.PropertyName);
                    break;

                case ElementTypes.Question:
                    method.Body.EmitLine("if (Has{0})", node.PropertyName);
                    method.Body.IncreaseIndentation();
                    method.Body.EmitLine("yield return {0};", node.PropertyName);
                    method.Body.DecreaseIndentation();
                    break;

                case ElementTypes.Plus:
                case ElementTypes.Star:
                    method.Body.EmitLine("{");
                    method.Body.IncreaseIndentation();

                    method.Body.EmitLine("{0}[] temp = new {0}[{1}.Count];", node.ProductionOrTokenClass, node.PropertyName);
                    method.Body.EmitLine("{0}.CopyTo(temp, 0);", node.PropertyName);
                    method.Body.EmitLine("for (int i = 0; i < temp.Length; i++)");
                    method.Body.IncreaseIndentation();
                    method.Body.EmitLine("yield return temp[i];");
                    method.Body.DecreaseIndentation();

                    method.Body.DecreaseIndentation();
                    method.Body.EmitLine("}");
                    break;
            }
        }
    }
}
