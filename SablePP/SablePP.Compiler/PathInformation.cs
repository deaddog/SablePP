using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;

namespace SablePP.Compiler
{
    public static class PathInformation
    {
        private static string _executing_ = null;

        static PathInformation()
        {
            // Sets executing directory
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Uri uri = new Uri(assembly.CodeBase);
            _executing_ = Path.GetDirectoryName(uri.LocalPath);
        }

        public static string ExecutingDirectory
        {
            get { return _executing_; }
        }
    }
}
