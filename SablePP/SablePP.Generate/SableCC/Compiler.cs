using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace SablePP.Generate.SableCC
{
    internal class Compiler : IDisposable
    {
        private readonly string _executing_ = null;
        private readonly string _temporary_ = null;
        private readonly string _grammarPath = null;

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

        private Compiler()
        {
            // Sets executing directory
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Uri uri = new Uri(assembly.CodeBase);
            _executing_ = Path.GetDirectoryName(uri.LocalPath);

            // Sets temporary directory
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName().Replace(".", ""));

            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);

            _temporary_ = tempDir;
            _grammarPath = Path.Combine(_temporary_, "grammar.sablecc");
        }
        void IDisposable.Dispose()
        {
            if (_temporary_ == null)
                return;
            else
            {
                if (Directory.Exists(_temporary_))
                    Directory.Delete(_temporary_, true);
            }
        }

        public static CompilationResult ValidateWithSableCC(Grammar grammar)
        {
            using (Compiler cp = new Compiler())
            {
                SablePP.Tools.SafeNameDictionary generatedVariables;

                Builder.BuildToFile(grammar, cp._grammarPath, out generatedVariables);

                var output = cp.StartSableCC();

                if (output.ExitCode != 0)
                    return new CompilationResult(output.handleSableException());
                else
                {
                    CompilationResult result = new CompilationResult();

                    result.SetLexerTables(File.ReadAllText(Path.Combine(cp._temporary_, "lexer.cs")));
                    result.SetParserTables(File.ReadAllText(Path.Combine(cp._temporary_, "parser.cs")));
                    result.SetErrorMessageTable(File.ReadAllText(Path.Combine(cp._temporary_, "parser.cs")), generatedVariables);

                    return result;
                }
            }
        }

        private const int SABLE_MAX_WAIT = 500;

        private Output StartSableCC()
        {
            var processInfo = new ProcessStartInfo(
                JavaExecutable,
                "-jar sablecc.jar -d \"" + _temporary_ + "\" -t csharp \"" + _grammarPath + "\"")
            {
                CreateNoWindow = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                WorkingDirectory = _executing_
            };

            Process proc;
            if ((proc = Process.Start(processInfo)) == null)
                throw new ApplicationException("Java not found - visit Java.com to install.");

            StringBuilder outputText = new StringBuilder();
            while (!proc.WaitForExit(100))
                outputText.Append(proc.StandardError.ReadToEnd());

            Output output = new Output(proc.ExitCode, outputText.ToString());
            proc.Close();
            proc.Dispose();

            return output;
        }
    }
}
