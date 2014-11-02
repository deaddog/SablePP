using SablePP.Tools.Generate.CSharp;
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
            emitConstructor(node.SharedElements, null, node.SharedElements);
            classElement.EmitNewline();
        }
        private void emitConstructor(AbstractAlternative node)
        {
            emitConstructor(node.Elements, node.SharedElements, node.UniqueElements);
            classElement.EmitNewline();
        }

        private void emitConstructor(AbstractAlternative.Element[] parameters, AbstractAlternative.Element[] chain, AbstractAlternative.Element[] fields)
        {
            string chainCall = null;
            if (chain != null)
                chainCall = "base(" + string.Join(", ", chain.Select(x => variables[x])) + ")";

            var constructor = new MethodElement("public {0}()", chainCall, true, classElement.Name);
            classElement.Add(constructor);

            foreach (var e in fields)
                emitConstructorAssignment(constructor, e);
            foreach (var e in parameters)
                emitConstructorParameter(constructor, e);
        }

        private void emitConstructorAssignment(MethodElement constructor, AbstractAlternative.Element node)
        {
            switch (node.Modifier)
            {
                case Modifiers.Single:
                case Modifiers.Optional:
                    constructor.Body.EmitLine("this.{0} = {1};", node.Name, variables[node]);
                    break;
                case Modifiers.OneOrMany:
                case Modifiers.ZeroOrMany:
                    constructor.Body.EmitLine("this.{0} = new NodeList<{1}>(this, {0}, {2});",
                        variables[node],
                        node.GeneratedName,
                        node.Modifier == Modifiers.ZeroOrMany ? "true" : "false");
                    break;
            }
        }
        private void emitConstructorParameter(MethodElement constructor, AbstractAlternative.Element node)
        {
            switch (node.Modifier)
            {
                case Modifiers.Single:
                case Modifiers.Optional:
                    constructor.Parameters.Add("{0} {1}", node.GeneratedName, variables[node]);
                    break;
                case Modifiers.OneOrMany:
                case Modifiers.ZeroOrMany:
                    constructor.Parameters.Add("IEnumerable<{0}> {1}", node.GeneratedName, variables[node]);
                    break;
            }
        }
    }
}
