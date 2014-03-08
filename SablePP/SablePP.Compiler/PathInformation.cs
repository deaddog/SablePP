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

        public static string ExecutingDirectory
        {
            get
            {
                if (_executing_ == null)
                {
                    var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                    Uri uri = new Uri(assembly.CodeBase);
                    _executing_ = Path.GetDirectoryName(uri.LocalPath);
                }
                return _executing_;
            }
        }

        public static void CleanTemporaryFiles()
        {
            lock (pathLock)
                if (_temporary_ == null)
                    return;
                else
                {
                    DirectoryInfo dir = new DirectoryInfo(_temporary_);
                    if (dir.Exists)
                        DeleteRecursive(dir);

                    _temporary_ = null;
                }
        }
        private static void DeleteRecursive(DirectoryInfo dir)
        {
            foreach (var f in dir.GetFiles())
                f.Delete();
            foreach (var d in dir.GetDirectories())
                DeleteRecursive(d);
            dir.Delete();
        }

        public static string TemporaryDirectory
        {
            get
            {
                lock (pathLock)
                    if (_temporary_ == null)
                    {
                        string tempDir = Path.Combine(ExecutingDirectory, "temp");

                        DirectoryInfo dir = new DirectoryInfo(tempDir);
                        if (!dir.Exists)
                            dir.Create();

                        tempDir = Path.Combine(tempDir, DateTime.Now.ToString("yyyyMMdd.HHmmss.fff"));

                        dir = new DirectoryInfo(tempDir);
                        if (!dir.Exists)
                            dir.Create();

                        _temporary_ = tempDir;
                    }

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
    }
}
