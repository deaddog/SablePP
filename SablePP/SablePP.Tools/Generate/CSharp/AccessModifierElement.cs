using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            get { return modifiers == AccessModifiers.None ? UseSpace.Never : UseSpace.Preferred; }
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
                    return 5;
                case AccessModifiers.@new:
                    return 0;
                case AccessModifiers.@internal:
                    return 2;
                case AccessModifiers.@sealed:
                    return 3;
                case AccessModifiers.@abstract:
                case AccessModifiers.@virtual:
                case AccessModifiers.@override:
                case AccessModifiers.@static:
                    return 4;
                case AccessModifiers.@explicit:
                case AccessModifiers.@implicit:
                    return 6;
                case AccessModifiers.@operator:
                case AccessModifiers.@extern:
                    return 7;
                default:
                    throw new NotImplementedException();
            }
        }

        private static Regex parseRegex;
        static AccessModifierElement()
        {
            string enums = string.Empty;
            foreach (string mod in Enum.GetNames(typeof(AccessModifiers)))
                if (mod != "None")
                    enums += mod + "|";
            enums = enums.TrimEnd('|');
            parseRegex = new Regex("((" + enums + ") +)+");
        }

        public static AccessModifierElement Parse(string signature, out int start, out int length)
        {
            Match match = parseRegex.Match(signature);

            if (match.Success)
            {
                string val = match.Value.TrimEnd(' ');

                start = match.Index;
                length = val.Length;

                AccessModifiers modifiers = AccessModifiers.None;
                string[] arr = val.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var mod in arr)
                {
                    AccessModifiers temp;
                    if (Enum.TryParse<AccessModifiers>(mod, out temp))
                        modifiers |= temp;
                }

                return new AccessModifierElement(modifiers);
            }
            else
            {
                start = 0;
                length = 0;

                return new AccessModifierElement(AccessModifiers.None);
            }
        }
    }
}
