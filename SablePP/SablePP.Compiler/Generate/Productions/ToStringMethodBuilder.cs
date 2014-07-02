using System;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate;
using SablePP.Tools.Generate.CSharp;

namespace SablePP.Compiler.Generate.Productions
{
    public class ToStringMethodBuilder
    {
        public static void Emit(ClassElement classElement, AAlternative node)
        {
            var elements = ProductionElement.GetAllElements(node);

            MethodElement method;
            classElement.Add(method = new MethodElement("public override string ToString()"));

            PatchElement formatString = new PatchElement();
            method.Body.Emit("return string.Format(\"");
            method.Body.InsertElement(formatString);
            method.Body.Emit("\"");

            for (int i = 0; i < elements.Length; i++)
            {
                if (i > 0)
                    formatString.Emit(" ");

                formatString.Emit("{{{0}}}", i);
                method.Body.Emit(", {0}", elements[i].PropertyName);
            }

            method.Body.EmitLine(");");
        }
    }
}
