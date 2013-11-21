﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler
{
    /// <summary>
    /// Represents the declaration of a helper identifier.
    /// </summary>
    public class DHelper : Declaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DHelper"/> class.
        /// </summary>
        /// <param name="node">The helper node from which this <see cref="DHelper"/> should be constructed.</param>
        public DHelper(AHelper node)
            : base(node.Identifier)
        {
        }

        public override string ToString()
        {
            return "H:" + base.ToString();
        }
    }
}
