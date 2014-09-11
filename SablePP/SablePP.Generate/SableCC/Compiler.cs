using Microsoft.Win32;
using System;
using System.IO;

namespace SablePP.Generate.SableCC
{
    internal static class Compiler
    {
        #region TempPath

        private static string _executing_ = null;
        private static string _temporary_ = null;

        private static object pathLock = new object();

        static Compiler()
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

        #endregion

        #region Java

        private static bool _javaLoaded_ = false;
        private static void loadJavaInformation()
        {
            if (_javaLoaded_)
                return;

            if (!loadJavaFrom(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)))
                loadJavaFrom(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32));

            _javaLoaded_ = true;
        }

        private static bool loadJavaFrom(RegistryKey rootKey)
        {
            bool result = false;

            if (rootKey != null)
                using (var baseKey = rootKey.OpenSubKey("SOFTWARE\\JavaSoft\\Java Runtime Environment"))
                    if (baseKey != null)
                    {
                        string currentVersion = baseKey.GetValue("CurrentVersion").ToString();
                        using (var homeKey = baseKey.OpenSubKey(currentVersion))
                        {
                            _javaVersion_ = currentVersion;
                            _javaDirectory_ = homeKey.GetValue("JavaHome").ToString();
                            _javaFound_ = true;
                        }
                    }

            return result;
        }

        private static string _javaDirectory_ = null;
        private static string javaDirectory
        {
            get
            {
                loadJavaInformation();
                return _javaDirectory_;
            }
        }
        public static string JavaExecutable
        {
            get { return javaDirectory + "\\bin\\java.exe"; }
        }

        private static string _javaVersion_ = null;
        public static string JavaVersion
        {
            get
            {
                loadJavaInformation();
                return _javaVersion_;
            }
        }

        private static bool _javaFound_;
        public static bool JavaFound
        {
            get
            {
                loadJavaInformation();
                return _javaFound_;
            }
        }

        #endregion
    }
}
