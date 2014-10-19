using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal partial class BProduction
    {
        private void emitConstructor(AbstractProduction node)
        {
            emit(node.SharedElements, null, node.SharedElements);
            classElement.EmitNewline();
        }
        private void emitConstructor(AbstractAlternative node)
        {
            emit(node.Elements, node.SharedElements, node.UniqueElements);
            classElement.EmitNewline();
        }

        private void emit(AbstractAlternative.Element[] parameters, AbstractAlternative.Element[] chain, AbstractAlternative.Element[] fields)
        {
            string chainCall = null;
            if (chain != null)
                chainCall = "base(" + string.Join(", ", chain.Select(x => variables[x])) + ")";

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
