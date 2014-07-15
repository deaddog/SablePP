using SablePP.Tools.Generate.CSharp;

namespace SablePP.Compiler.Generate.Parsing
{
    public class TokenIndexBuilder : GenerateVisitor
    {
        private ClassElement classElement;
        private int index = 0;

        public TokenIndexBuilder(ClassElement classElement)
        {
            this.classElement = classElement;
        }

        public override void CaseATokens(Nodes.ATokens node)
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

            base.CaseATokens(node);

            classElement.EmitNewline();

            classElement.Add(none = new MethodElement("private int getIndex(EOF node)"));
            none.Body.EmitLine("return {0};", index);

            this.classElement.EmitRegionEnd();
        }

        public override void CaseAToken(Nodes.AToken node)
        {
            if (node.Identifier.AsToken.Declaration.IsIgnored)
                return;

            MethodElement m;
            classElement.Add(m = new MethodElement("private int getIndex({0} node)", true, node.ClassName));
            m.Body.EmitLine("return {0};", index++);
        }
    }
}
