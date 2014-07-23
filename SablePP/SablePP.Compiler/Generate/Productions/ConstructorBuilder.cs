
using SablePP.Tools.Generate.CSharp;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Generate.Productions
{
    public class ConstructorBuilder
    {
        private MethodElement constructor;

        public static void Emit(ClassElement classElement, AProduction node)
        {
            var fields = ProductionElement.GetSharedElements(node);

            emit(classElement, fields, null, fields);
            classElement.EmitNewline();
        }
        public static void Emit(ClassElement classElement, AAlternative node)
        {
            emit(classElement, ProductionElement.GetAllElements(node), ProductionElement.GetSharedElements(node), ProductionElement.GetUniqueElements(node));
            classElement.EmitNewline();
        }

        private static void emit(ClassElement classElement, ProductionElement[] parameters, ProductionElement[] chain, ProductionElement[] fields)
        {
            string chainCall = null;
            if (chain != null)
            {
                chainCall = "base(";
                for (int i = 0; i < chain.Length; i++)
                {
                    if (i > 0)
                        chainCall += ", ";
                    chainCall += chain[i].FieldName;
                }
                chainCall += ")";
            }

            var constructor = new MethodElement("public {0}()", chainCall, true, classElement.Name);
            ConstructorBuilder builder = new ConstructorBuilder() { constructor = constructor };

            classElement.Add(constructor);

            foreach (var e in fields)
                builder.emitAssignment(e);
            foreach (var e in parameters)
                builder.emitParameter(e);
        }

        private void emitAssignment(ProductionElement node)
        {
            switch (node.ElementType)
            {
                case ElementTypes.Simple:
                case ElementTypes.Question:
                    constructor.Body.EmitLine("this.{0} = {1};", node.PropertyName, node.FieldName);
                    break;
                case ElementTypes.Plus:
                case ElementTypes.Star:
                    constructor.Body.EmitLine("this.{0} = new NodeList<{1}>(this, {0}, {2});",
                        node.FieldName,
                        node.ProductionOrTokenClass,
                        node.ElementType == ElementTypes.Star ? "true" : "false");
                    break;
            }
        }
        private void emitParameter(ProductionElement node)
        {
            switch (node.ElementType)
            {
                case ElementTypes.Simple:
                case ElementTypes.Question:
                    constructor.Parameters.Add("{0} {1}", node.ProductionOrTokenClass, node.FieldName);
                    break;
                case ElementTypes.Plus:
                case ElementTypes.Star:
                    constructor.Parameters.Add("IEnumerable<{0}> {1}", node.ProductionOrTokenClass, node.FieldName);
                    break;
            }
        }
    }
}
