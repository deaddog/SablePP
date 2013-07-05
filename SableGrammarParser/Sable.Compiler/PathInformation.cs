using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;

namespace Sable.Compiler
{
    public static class PathInformation
    {
        private static string _executing_ = null;
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

        public static string TemporaryDirectory
        {
            get
            {
                EnsureTemporaryDirectory();
                return ExecutingDirectory + "\\temp";
            }
        }
        public static string SableOutputDirectory
        {
            get
            {
                EnsureSableOutputDirectory();
                return ExecutingDirectory + "\\temp\\sable";
            }
        }

        public static void EnsureTemporaryDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(ExecutingDirectory + "\\temp");
            if (!dir.Exists)
                dir.Create();
        }
        public static void EnsureSableOutputDirectory()
        {
            EnsureTemporaryDirectory();
            DirectoryInfo dir = new DirectoryInfo(ExecutingDirectory + "\\temp\\sable");
            if (!dir.Exists)
                dir.Create();
        }

        private static string _javaDirectory_ = null;
        private static string javaDirectory
        {
            get
            {
                if (_javaDirectory_ == null)
                {
                    string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment";
                    using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey))
                    {
                        string currentVersion = baseKey.GetValue("CurrentVersion").ToString();
                        using (var homeKey = baseKey.OpenSubKey(currentVersion))
                            _javaDirectory_ = homeKey.GetValue("JavaHome").ToString();
                    }
                }
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
                if (_javaVersion_ == null)
                {
                    string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment";
                    using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey))
                    {
                        _javaVersion_ = baseKey.GetValue("CurrentVersion").ToString();
                    }
                }
                return _javaVersion_;
            }
        }
    }
}
