using SablePP.Tools.Generate.CSharp;
using SablePP.Compiler.Nodes;
using System.Collections.Generic;

namespace SablePP.Compiler.Generate.Productions
{
    public class FieldBuilder
    {
        private ClassElement classElement;

        public static void Emit(ClassElement classElement, AProduction node)
        {
            var fields = ProductionElement.GetSharedElements(node);
            if (fields.Length > 0)
            {
                emit(classElement, fields);
                classElement.EmitNewline();
            }
        }
        public static void Emit(ClassElement classElement, AAlternative node)
        {
            var fields = ProductionElement.GetUniqueElements(node);
            if (fields.Length > 0)
            {
                emit(classElement, fields);
                classElement.EmitNewline();
            }
        }

        private static void emit(ClassElement classElement, IEnumerable<ProductionElement> elements)
        {
            FieldBuilder builder = new FieldBuilder() { classElement = classElement };
            foreach (var e in elements)
                builder.emitElement(e);
        }

        private void emitElement(ProductionElement node)
        {
            switch (node.ElementType)
            {
                case ElementTypes.Simple:
                case ElementTypes.Question:
                    classElement.EmitField("private " + node.ProductionOrTokenClass + " " + node.FieldName);
                    break;
                case ElementTypes.Plus:
                case ElementTypes.Star:
                    classElement.EmitField("private NodeList<" + node.ProductionOrTokenClass + "> " + node.FieldName);
                    break;
            }
        }
    }
}
