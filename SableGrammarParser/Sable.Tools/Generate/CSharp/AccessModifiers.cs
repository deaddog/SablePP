using System;
using System.Collections.Generic;

namespace Sable.Tools.Generate.CSharp
{
    public enum AccessModifiers
    {
        @public = 1,
        @private = 2,
        @protected = 4,
        @partial = 8,
        @new = 16,
        @internal = 32,
        @abstract = 64,
        @virtual = 128,
        @override = 256
    }

    internal static class AccessModifiersExtension
    {
        public static void Emit(this AccessModifiers modifiers, Action<string, UseSpace, UseSpace, object[]> emitter)
        {
            List<AccessModifiers> mods = new List<AccessModifiers>(SplitModifiers(modifiers));
            mods.Sort(compare);
            foreach (var a in mods)
                emitter(a.ToString(), UseSpace.NotPreferred, UseSpace.Preferred, null);
        }

        private static IEnumerable<AccessModifiers> SplitModifiers(AccessModifiers modifiers)
        {
            foreach (AccessModifiers am in Enum.GetValues(typeof(AccessModifiers)))
                if (modifiers.HasFlag(am))
                    yield return am;
        }

        private static int compare(AccessModifiers mod1, AccessModifiers mod2)
        {
            return ToValue(mod1).CompareTo(ToValue(mod2));
        }

        private static int ToValue(AccessModifiers mod)
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
