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
    }
}
