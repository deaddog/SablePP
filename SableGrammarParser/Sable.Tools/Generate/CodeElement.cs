using System;

namespace Sable.Tools.Generate
{
    public abstract class CodeElement
    {
        protected CodeElement()
        {
        }

        internal abstract UseSpace Append
        {
            get;
        }
        internal abstract UseSpace Prepend
        {
            get;
        }

        protected static bool useSpace(UseSpace append, UseSpace prepend)
        {
            switch (append)
            {
                case UseSpace.Preferred:
                    return prepend != UseSpace.Never;
                case UseSpace.NotPreferred:
                    return prepend == UseSpace.Preferred || prepend == UseSpace.Always;
                case UseSpace.Always:
                    return true;
                case UseSpace.Never:
                    return prepend == UseSpace.Always;
                default:
                    throw new InvalidOperationException();
            }
        }

        internal abstract void Generate(CodeStreamWriter streamwriter);
    }
}
