using SablePP.Compiler.Nodes;
using SablePP.Generate;
using System;

namespace SablePP.Compiler
{
    internal static class ModifiersExtension
    {
        public static Modifiers GetModifier(this PModifier node)
        {
            if (node == null)
                return Modifiers.Single;
            if (node is AQuestionModifier)
                return Modifiers.Optional;
            if (node is APlusModifier)
                return Modifiers.OneOrMany;
            if (node is AStarModifier)
                return Modifiers.ZeroOrMany;

            throw new ArgumentException("Unable to determine modifier for " + node);
        }
    }
}
