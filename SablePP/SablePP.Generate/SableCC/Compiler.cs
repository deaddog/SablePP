using Microsoft.Win32;

namespace SablePP.Generate.SableCC
{
    internal static class Compiler
    {
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
