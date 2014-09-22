using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    public class Parser
    {
        private ClassElement classElement;

        public Parser(ClassElement classElement)
        {
            this.classElement = classElement;
        }

        public override void Visit(Token[] node)
        {
            this.classElement.EmitRegionStart("Token Index", false);
            this.classElement.EmitNewline();

            MethodElement dyn;
            classElement.Add(dyn = new MethodElement("protected override int getTokenIndex(Token token)"));
            dyn.Body.EmitLine("return getIndex((dynamic)token);");

            classElement.EmitNewline();

            MethodElement none;
            classElement.Add(none = new MethodElement("private int getIndex(Token node)"));
            none.Body.EmitLine("return -1;");

            classElement.EmitNewline();

            int index = 0;
            foreach (var t in node)
                if(!t.Ignored)
                {
                    MethodElement m;
                    classElement.Add(m = new MethodElement("private int getIndex({0} node)", true, t.Name));
                    m.Body.EmitLine("return {0};", index++);
                }

            classElement.EmitNewline();

            classElement.Add(none = new MethodElement("private int getIndex(EOF node)"));
            none.Body.EmitLine("return {0};", index);

            this.classElement.EmitRegionEnd();
        }
    }
}
