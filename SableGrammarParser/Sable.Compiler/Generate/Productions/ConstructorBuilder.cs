using System;

using Sable.Tools.Generate.CSharp;
using Sable.Compiler.node;

namespace Sable.Compiler.Generate.Productions
{
    public class ConstructorBuilder : GenerateVisitor
    {
        private ClassElement classElement;

        public ConstructorBuilder(ClassElement classElement)
        {
            this.classElement = classElement;
        }
    }
}
