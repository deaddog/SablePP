using System;
using System.Collections.Generic;

namespace SablePP.Tools.Generate.CSharp
{
    [Flags]
    /// <summary>
    /// An enumeration of the various C# access modifiers
    /// </summary>
    public enum AccessModifiers
    {
        /// <summary>
        /// No access modifiers.
        /// </summary>
        None = 0,
        /// <summary>
        /// The public access modifier.
        /// </summary>
        @public = 1,
        /// <summary>
        /// The private access modifier.
        /// </summary>
        @private = 2,
        /// <summary>
        /// The protected access modifier.
        /// </summary>
        @protected = 4,
        /// <summary>
        /// The partial access modifier.
        /// </summary>
        @partial = 8,
        /// <summary>
        /// The new access modifier.
        /// </summary>
        @new = 16,
        /// <summary>
        /// The internal access modifier.
        /// </summary>
        @internal = 32,
        /// <summary>
        /// The abstract access modifier.
        /// </summary>
        @abstract = 64,
        /// <summary>
        /// The virtual access modifier.
        /// </summary>
        @virtual = 128,
        /// <summary>
        /// The override access modifier.
        /// </summary>
        @override = 256,
        /// <summary>
        /// The static access modifier.
        /// </summary>
        @static = 512,
        /// <summary>
        /// The explicit access modifier.
        /// </summary>
        @explicit = 1024,
        /// <summary>
        /// The implicit access modifier.
        /// </summary>
        @implicit = 2048,
        /// <summary>
        /// The operator access modifier.
        /// </summary>
        @operator = 4096,
        /// <summary>
        /// The sealed access modifier.
        /// </summary>
        @sealed = 8192,
        /// <summary>
        /// The extern access modifier.
        /// </summary>
        @extern = 16384
    }

    internal static class AccessModifiersExtension
    {
        public static void Emit(this AccessModifiers modifiers, Action<string, UseSpace, UseSpace, object[]> emitter)
        {
            if (modifiers == AccessModifiers.None)
                return;

            List<AccessModifiers> mods = new List<AccessModifiers>(SplitModifiers(modifiers));
            mods.Sort(compare);
            foreach (var a in mods)
                emitter(a.ToString(), UseSpace.NotPreferred, UseSpace.Preferred, null);
        }

        private static IEnumerable<AccessModifiers> SplitModifiers(AccessModifiers modifiers)
        {
            foreach (AccessModifiers am in Enum.GetValues(typeof(AccessModifiers)))
                if (modifiers.HasFlag(am) && am != AccessModifiers.None)
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
