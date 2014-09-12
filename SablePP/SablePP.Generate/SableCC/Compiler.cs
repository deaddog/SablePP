using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

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

        private const int SABLE_MAX_WAIT = 500;

        private void ValidateWithSableCC(Start<PGrammar> root, CompilationOptions compilationOptions)
        {
            SableGrammarEmitter emitter;
            using (FileStream fss = new FileStream(TemporarySableGrammarPath, FileMode.Create))
            {
                emitter = new SableGrammarEmitter(fss);
                emitter.Visit(root);
            }

            using (Process proc = StartSableCC())
            {
                if (proc.ExitCode != 0)
                {
                    string errorText = proc.StandardError.ReadToEnd();
                    string sableCCgrammar;
                    using (StreamReader reader = new StreamReader(TemporarySableGrammarPath))
                        sableCCgrammar = reader.ReadToEnd();
                    SableCCLogger.LogFromGrammar(compilationOptions.Input, sableCCgrammar, errorText);

                    string[] text = errorText.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i].StartsWith("\tat "))
                            break;
                        handleSableException(compilationOptions.ErrorManager, emitter, text[i]);
                    }
                }
                else
                {
                    string lexerDestination = Path.Combine(SableOutputDirectory, "sablecc_lexer.cs");
                    string parserDestination = Path.Combine(SableOutputDirectory, "sablecc_parser.cs");

                    if (File.Exists(lexerDestination))
                        File.Delete(lexerDestination);
                    File.Move(Path.Combine(SableOutputDirectory, "lexer.cs"), lexerDestination);

                    if (File.Exists(parserDestination))
                        File.Delete(parserDestination);
                    File.Move(Path.Combine(SableOutputDirectory, "parser.cs"), parserDestination);
                }
                proc.Close();
            }
        }

        private Process StartSableCC()
        {
            var processInfo = new ProcessStartInfo(
                JavaExecutable,
                "-jar sablecc.jar -d \"" + SableOutputDirectory + "\" -t csharp \"" + TemporarySableGrammarPath + "\"")
            {
                CreateNoWindow = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                WorkingDirectory = ExecutingDirectory
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
        private void handleSableException(ErrorManager errorManager, SableGrammarEmitter emitter, string text)
        {
            Match m = Regex.Match(text, "java.lang.RuntimeException: \\[(?<line>[0-9]+),(?<char>[0-9]+)\\] (?<text>.*)");
            if (m.Success)
            {
                int eLine = int.Parse(m.Groups["line"].Value);
                int eChar = int.Parse(m.Groups["char"].Value);

                var position = emitter.TranslatePosition(eLine, eChar);

                string eText = m.Groups["text"].Value;

                if (eLine == 0 || eChar == 0)
                    errorManager.Register("SableCC: {2} at {{{0},{1}}}", eLine, eChar, eText);
                else
                    errorManager.Register(new CompilerError(ErrorType.Error, position, position, "SableCC: " + eText));
            }
            else
                errorManager.Register(text);
        }
    }
}
