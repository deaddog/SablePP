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
        private static string _temporary_ = null;

        private static object pathLock = new object();

        static PathInformation()
        {
            // Sets executing directory
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Uri uri = new Uri(assembly.CodeBase);
            _executing_ = Path.GetDirectoryName(uri.LocalPath);

            // Sets temporary directory
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName().Replace(".", ""));

            if(!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);

            _temporary_ = tempDir;
        }

        public static string ExecutingDirectory
        {
            get { return _executing_; }
        }

        public static void CleanTemporaryFiles()
        {
            lock (pathLock)
                if (_temporary_ == null)
                    return;
                else
                {
                    if (Directory.Exists(_temporary_))
                        Directory.Delete(_temporary_, true);

                    _temporary_ = null;
                }
        }

        public static string TemporaryDirectory
        {
            get
            {
                if (_temporary_ == null)
                    throw new InvalidOperationException("TemporaryDirectory cannot be access after CleanTemporaryFiles has been called.");

                return _temporary_;
            }
        }
        public static string SableOutputDirectory
        {
            get
            {
                string sableDir = Path.Combine(TemporaryDirectory, "sable");

                DirectoryInfo dir = new DirectoryInfo(sableDir);
                if (!dir.Exists)
                    dir.Create();

                return sableDir;
            }
        }

        public static string TemporaryGrammarPath
        {
            get { return TemporaryDirectory + "\\grammar.sablecc"; }
        }
        public static string TemporarySableGrammarPath
        {
            get { return SableOutputDirectory + "\\grammar.sablecc"; }
        }
    }
}
