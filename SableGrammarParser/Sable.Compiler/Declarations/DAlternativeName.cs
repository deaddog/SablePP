﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sable.Compiler.Nodes;

namespace Sable.Compiler
{
    /// <summary>
    /// Represents the declaration of a alternative name identifier.
    /// </summary>
    public class DAlternativeName : Declaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DAlternativeName"/> class.
        /// </summary>
        /// <param name="node">The alternative name node from which this <see cref="DAlternativeName"/> should be constructed.</param>
        public DAlternativeName(AAlternativename name)
            : base(name.GetName())
        {
        }
    }
}
