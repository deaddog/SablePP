using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
                Builder.BuildToFile(grammar, cp._grammarPath);

                int exitCode;
                string standardError;

                using (Process proc = cp.StartSableCC())
                {
                    exitCode = proc.ExitCode;
                    standardError = proc.StandardError.ReadToEnd();

                    proc.Close();
                }

                if (exitCode != 0)
                    return new CompilationResult(cp.handleSableException(standardError));
                else
                {
                    string lexerDestination = Path.Combine(cp._temporary_, "sablecc_lexer.cs");
                    string parserDestination = Path.Combine(cp._temporary_, "sablecc_parser.cs");

                    if (File.Exists(lexerDestination))
                        File.Delete(lexerDestination);
                    File.Move(Path.Combine(cp._temporary_, "lexer.cs"), lexerDestination);

                    if (File.Exists(parserDestination))
                        File.Delete(parserDestination);
                    File.Move(Path.Combine(cp._temporary_, "parser.cs"), parserDestination);
                }
            }
        }

        private const int SABLE_MAX_WAIT = 500;

        private Process StartSableCC()
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

            int wait = 0;
            Process proc;
            if ((proc = Process.Start(processInfo)) == null)
                throw new ApplicationException("Java not found - visit Java.com to install.");

            while (!proc.WaitForExit(100))
            {
                wait += 100;
                int err = proc.StandardError.Peek();
                if (err > 0 && wait >= SABLE_MAX_WAIT)
                    proc.Kill();
            }

            return proc;
        }
        private CompilationError handleSableException(string standardError)
        {
            Regex errorRegex = new Regex(@"(?<type>shift|reduce)/reduce conflict in state");

            Match m = errorRegex.Match(standardError);
            if(!m.Success)
                throw new UnhandledGrammarErrorException(standardError);

            ErrorTypes type = m.Groups["type"].Value == "shift" ? ErrorTypes.ShiftReduce : ErrorTypes.ReduceReduce;

            return new CompilationError(type, standardError);
        }
    }
}
