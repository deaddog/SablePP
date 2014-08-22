using System;

namespace SablePP.Generate
{
    public enum Modifiers
    {
        Optional,
        ZeroOrMany,
        OneOrMany
    }

    public static class ModifiersExtension
    {
        public static char ToChar(this Modifiers modifier)
        {
            switch (modifier)
            {
                case Modifiers.Optional:
                    return '?';
                case Modifiers.ZeroOrMany:
                    return '*';
                case Modifiers.OneOrMany:
                    return '+';

                default:
                    throw new ArgumentOutOfRangeException("modifier", "Unknown modifier.");
            }
        }

        public static bool Exists(this Modifiers modifier)
        {
            switch (modifier)
            {
                case Modifiers.Optional:
                case Modifiers.ZeroOrMany:
                case Modifiers.OneOrMany:
                    return true;
                default:
                    return false;
            }
        }
    }
}
