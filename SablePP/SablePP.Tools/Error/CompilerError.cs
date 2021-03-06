﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using SablePP.Tools.Nodes;

namespace SablePP.Tools.Error
{
    /// <summary>
    /// Describes a compiler error and the position at which it has occured.
    /// </summary>
    public class CompilerError
    {
        private Position start, end;
        private string errorMessage;
        private ErrorType errorType;

        private static string endWithPeriod(string input)
        {
            Match m = Regex.Match(input, @"[\.\!\?]$");
            if (!m.Success)
                return input + ".";
            else
                return input;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilerError"/> class.
        /// </summary>
        /// <param name="errorType">The <see cref="ErrorType"/> of the <see cref="CompilerError"/>.</param>
        /// <param name="start">The start <see cref="Position"/> of the error.</param>
        /// <param name="end">The end <see cref="Position"/> of the error.</param>
        /// <param name="errorMessage">The error message associated with the <see cref="CompilerError"/>.</param>
        public CompilerError(ErrorType errorType, Position start, Position end, string errorMessage)
        {
            this.errorType = errorType;
            this.start = start;
            this.end = end;
            this.errorMessage = endWithPeriod(errorMessage);
        }

        /// <summary>
        /// Gets the start <see cref="Position"/> of the error.
        /// </summary>
        /// <value>
        /// The start <see cref="Position"/> of the error.
        /// </value>
        public Position Start
        {
            get { return start; }
        }
        /// <summary>
        /// Gets the end <see cref="Position"/> of the error.
        /// </summary>
        /// <value>
        /// The end <see cref="Position"/> of the error.
        /// </value>
        public Position End
        {
            get { return end; }
        }

        /// <summary>
        /// Gets the error message associated with the error.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage
        {
            get { return errorMessage; }
        }

        /// <summary>
        /// Gets the type of the error.
        /// </summary>
        public ErrorType ErrorType
        {
            get { return errorType; }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents the location and message of this <see cref="CompilerError"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents the location and message of this <see cref="CompilerError"/>.
        /// </returns>
        public override string ToString()
        {
            if (start.Line == 0 || start.Character == 0)
                return string.Format("[N/A] {0}", errorMessage);
            else
                return string.Format("[{0}, {1}] {2}", start.Line, start.Character, errorMessage);
        }
    }
}
