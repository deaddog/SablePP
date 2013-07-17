using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sable.Compiler
{
    internal static class CommonMethods
    {
        public static string ToCamelCase(this string text)
        {
            text = string.Join(" ", from s in text.Split(' ') select char.ToUpper(s[0]) + s.Substring(1));
            while (text.Contains('_'))
            {
                int index = text.IndexOf('_');
                text = text.Substring(0, index) + char.ToUpper(text[index + 1]) + text.Substring(index + 2);
            }
            return text;
        }
    }
}
