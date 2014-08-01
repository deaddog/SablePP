using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SablePP.Compiler
{
    public static class SableCCLogger
    {
        public static void LogFromGrammar(string inputGrammar, string modifiedGrammar, string errorString)
        {
            DateTime time = DateTime.Now;

            string logDir = Path.Combine(PathInformation.ExecutingDirectory, "log");
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            string logPath = Path.Combine(logDir, time.ToString("yyyyMMdd.HHmmss.fff") + ".txt");
            using (StreamWriter writer = new StreamWriter(logPath))
            {
                string s = time.ToString("yyyy-MM-dd HH:mm:ss.fff");
                writer.WriteLine("### Date/Time ###");
                writer.WriteLine("Date: {0:yyyy-MM-dd}", time);
                writer.WriteLine("Time: {0:HH:mm:ss.fff}", time);

                writer.WriteLine("### SablePP grammar ###");
                writer.WriteLine(inputGrammar);
                writer.WriteLine("### SableCC grammar ###");
                writer.WriteLine(modifiedGrammar);
                writer.WriteLine("### SableCC error message ###");
                writer.WriteLine(errorString);
            }
        }
    }
}
