﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.SableCC
{
    public class UnhandledGrammarErrorException : Exception
    {
        public UnhandledGrammarErrorException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
