using System;

using Sable.Tools.Generate.CSharp;
using Sable.Compiler.node;

namespace Sable.Compiler.Generate.Productions
{
    public class ApplyMethodsBuilder : ProductionVisitor
    {
        private ClassElement classElement;
        private MethodElement voidMethod;
        private MethodElement typeMethod;

        public ApplyMethodsBuilder(ClassElement classElement)
        {
            this.classElement = classElement;
        }

        public override void InAAlternative(AAlternative node)
        {
            voidMethod = classElement.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "Apply", "void");
            typeMethod = classElement.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "Apply", "T");
            typeMethod.TypeParameters.Add("T");

            voidMethod.Parameters.Add("a", "IAnalysis");
            typeMethod.Parameters.Add("a", "IReturnAnalysis<T>");
            typeMethod.Parameters.Add("arg", "T");

            voidMethod.EmitIdentifier(voidMethod.Parameters[0].Name);
            voidMethod.EmitPeriod();
            voidMethod.EmitIdentifier("Case" + classElement.Name);
            using (var par = voidMethod.EmitParenthesis())
                par.EmitThis();
            voidMethod.EmitSemicolon(true);

            typeMethod.EmitReturn();
            typeMethod.EmitIdentifier(typeMethod.Parameters[0].Name);
            typeMethod.EmitPeriod();
            typeMethod.EmitIdentifier("Case" + classElement.Name);
            using (var par = typeMethod.EmitParenthesis())
            {
                par.EmitThis();
                par.EmitComma();
                par.EmitIdentifier(typeMethod.Parameters[1].Name);
            }
            typeMethod.EmitSemicolon(true);
        }
    }
}
