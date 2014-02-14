using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Tools.Generate.CSharp
{
    internal class AccessModifierElement : CodeElement
    {
        private AccessModifiers modifiers;

        public AccessModifierElement(AccessModifiers modifiers)
        {
            this.modifiers = modifiers;
        }

        public AccessModifiers Modifiers
        {
            get { return modifiers; }
            set { modifiers = value; }
        }

        internal override UseSpace Append
        {
            get { return UseSpace.Preferred; }
        }

        internal override UseSpace Prepend
        {
            get { return UseSpace.NotPreferred; }
        }

        internal override void Generate(CodeStreamWriter streamwriter)
        {
            streamwriter.WriteString(buildString(modifiers));
        }

        private static string buildString(AccessModifiers modifiers)
        {
            var strings = from m in splitModifiers(modifiers)
                          orderby toValue(m) ascending
                          select m;

            return string.Join(" ", strings);
        }
        private static IEnumerable<AccessModifiers> splitModifiers(AccessModifiers modifiers)
        {
            foreach (AccessModifiers am in Enum.GetValues(typeof(AccessModifiers)))
                if (modifiers.HasFlag(am) && am != AccessModifiers.None)
                    yield return am;
        }
        private static int toValue(AccessModifiers mod)
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
