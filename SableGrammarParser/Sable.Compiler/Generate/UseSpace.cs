using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sable.Compiler.Generate
{
    /// <summary>
    /// Space setting for code elements
    /// </summary>
    public enum UseSpace
    {
        /// <summary>
        /// Space is preferred
        /// </summary>
        Preferred,
        /// <summary>
        /// Space is not preferred
        /// </summary>
        NotPreferred,
        /// <summary>
        /// Space should always be inserted
        /// </summary>
        Always,
        /// <summary>
        /// Space should not be inserted
        /// </summary>
        Never
    }
}
