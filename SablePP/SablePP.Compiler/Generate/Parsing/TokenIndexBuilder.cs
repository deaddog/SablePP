using SablePP.Tools.Generate.CSharp;

namespace SablePP.Compiler.Generate.Parsing
{
    public class TokenIndexBuilder : GenerateVisitor
    {
        private ClassElement classElement;

        public TokenIndexBuilder(ClassElement classElement)
        {
            this.classElement = classElement;
        }
    }
}
