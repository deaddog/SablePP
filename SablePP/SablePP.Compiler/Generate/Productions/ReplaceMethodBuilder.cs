using System;

using SablePP.Tools.Generate.CSharp;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Generate.Productions
{
    public class ReplaceMethodBuilder
    {
        private static readonly string newChild = "newChild";
        private static readonly string oldChild = "oldChild";

        private ClassElement classElement;
        private MethodElement method;

        public static void Emit(ClassElement classElement, AAlternative node)
        {
            var elements = ProductionElement.GetAllElements(node);

            ReplaceMethodBuilder builder = new ReplaceMethodBuilder() { classElement = classElement };
            classElement.Add(builder.method = new MethodElement("public override void ReplaceChild(Node {0}, Node {1})", true, oldChild, newChild));

            foreach (var e in elements)
                builder.emitElement(e);

            builder.method.Body.EmitLine("throw new ArgumentException(\"Node to be replaced is not a child in this production.\");");
        }

        private void emitElement(ProductionElement node)
        {
            switch (node.ElementType)
            {
                case ElementTypes.Simple:
                case ElementTypes.Question:
                    {
                        method.Body.EmitLine("if ({0} == {1})", node.PropertyName, oldChild);
                        method.Body.EmitLine("{");
                        method.Body.IncreaseIndentation();

                        if (node.ElementType == ElementTypes.Simple)
                        {
                            method.Body.EmitLine("if ({0} == null)", newChild);
                            method.Body.IncreaseIndentation();
                            method.Body.EmitLine("throw new ArgumentException(\"{0} in {1} cannot be null.\", \"{2}\");", node.PropertyName, classElement.Name, newChild);
                            method.Body.DecreaseIndentation();
                        }

                        method.Body.EmitLine("if (!({0} is {1}) && {0} != null)", newChild, node.ProductionOrTokenClass);
                        method.Body.IncreaseIndentation();
                        method.Body.EmitLine("throw new ArgumentException(\"Child replaced must be of same type as child being replaced with.\");");
                        method.Body.DecreaseIndentation();

                        method.Body.EmitLine("{0} = {1} as {2};", node.PropertyName, newChild, node.ProductionOrTokenClass);

                        method.Body.DecreaseIndentation();
                        method.Body.EmitLine("}");
                        method.Body.Emit("else ");
                    }
                    break;

                case ElementTypes.Plus:
                case ElementTypes.Star:
                    {
                        method.Body.EmitLine("if ({0} is {1} && {2}.Contains({0} as {1}))", oldChild, node.ProductionOrTokenClass, node.PropertyName);
                        method.Body.EmitLine("{");
                        method.Body.IncreaseIndentation();

                        method.Body.EmitLine("if (!({0} is {1}) && {0} != null)", newChild, node.ProductionOrTokenClass);
                        method.Body.IncreaseIndentation();
                        method.Body.EmitLine("throw new ArgumentException(\"Child replaced must be of same type as child being replaced with.\");");
                        method.Body.DecreaseIndentation();
                        method.Body.EmitNewLine();

                        method.Body.EmitLine("int index = {0}.IndexOf({1} as {2});", node.PropertyName, oldChild, node.ProductionOrTokenClass);
                        method.Body.EmitLine("if ({0} == null)", newChild);
                        method.Body.IncreaseIndentation();
                        method.Body.EmitLine("{0}.RemoveAt(index);", node.PropertyName);
                        method.Body.DecreaseIndentation();
                        method.Body.EmitLine("else");
                        method.Body.IncreaseIndentation();
                        method.Body.EmitLine("{0}[index] = {1} as {2};", node.PropertyName, newChild, node.ProductionOrTokenClass);
                        method.Body.DecreaseIndentation();

                        method.Body.DecreaseIndentation();
                        method.Body.EmitLine("}");
                        method.Body.Emit("else ");
                    }
                    break;
            }
        }
    }
}
