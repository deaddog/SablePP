﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SablePP.Generate.RegularExpressions
{
    public class LiteralRegExp : RegExp
    {
        private string content;

        public LiteralRegExp(char content)
        {
            this.content = content.ToString();
        }
        public LiteralRegExp(string content)
        {
            if (content == null)
                throw new ArgumentNullException("content");

            if (content.Length == 0)
                throw new ArgumentOutOfRangeException("content", "A literal regular expression cannot be defined as an empty string.");

            this.content = content;
        }

        public bool IsChar
        {
            get { return content.Length == 1; }
        }
        public char? Char
        {
            get { return IsChar ? content[0] : (char?)null; }
        }

        public bool IsString
        {
            get { return content.Length > 1; }
        }
        public string Content
        {
            get { return IsString ? content : null; }
        }
    }
}
