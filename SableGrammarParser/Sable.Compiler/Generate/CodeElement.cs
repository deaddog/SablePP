using System;

namespace Sable.Compiler.Generate
{
    public abstract class CodeElement
    {
        protected CodeElement()
        {
        }

        public abstract UseSpace Append
        {
            get;
        }
        public abstract UseSpace Prepend
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

        public abstract void Generate(CodeStreamWriter streamwriter);
    }
}
