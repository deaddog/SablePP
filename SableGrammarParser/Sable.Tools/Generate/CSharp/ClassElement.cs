using System;
using System.Collections.Generic;

namespace Sable.Tools.Generate.CSharp
{
    public class ClassElement : ComplexElement
    {
        private string name;
        private AccessModifiers modifiers;
        private PatchElement contents;

        public ClassElement(string name, AccessModifiers modifiers)
        {
            this.name = name;
            this.modifiers = modifiers;
            this.contents = new PatchElement();

            EmitAccessModifiers();
            emit("class", UseSpace.Always, UseSpace.Always);
            emit(name, UseSpace.Always, UseSpace.NotPreferred);

            emitNewLine();
            emit("{", UseSpace.Never, UseSpace.Never);
            emitNewLine();
            increaseIndentation();
            insertElement(contents);
            decreaseIndentation();
            emit("}", UseSpace.Never, UseSpace.Never);
            emitNewLine();
        }

        private IEnumerable<AccessModifiers> SplitModifiers()
        {
            foreach (AccessModifiers am in Enum.GetValues(typeof(AccessModifiers)))
                if (modifiers.HasFlag(am))
                    yield return am;
        }

        private void EmitAccessModifiers()
        {
            List<AccessModifiers> mods = new List<AccessModifiers>(SplitModifiers());
            mods.Sort(compare);
            foreach (var a in mods)
                emit(a.ToString(), UseSpace.NotPreferred, UseSpace.Preferred);
        }

        private int compare(AccessModifiers mod1, AccessModifiers mod2)
        {
            return ToValue(mod1).CompareTo(ToValue(mod2));
        }

        private int ToValue(AccessModifiers mod)
        {
            switch (mod)
            {
                case AccessModifiers.@public:
                case AccessModifiers.@private:
                case AccessModifiers.@protected:
                    return 1;
                case AccessModifiers.@partial:
                    return 4;
                case AccessModifiers.@new:
                    return 0;
                case AccessModifiers.@internal:
                    return 2;
                case AccessModifiers.@abstract:
                case AccessModifiers.@virtual:
                case AccessModifiers.@override:
                    return 3;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
