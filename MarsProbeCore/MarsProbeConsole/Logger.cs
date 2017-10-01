using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProbeConsole
{
    public static class Logger
    {
        private static StreamWriter _writer;
        public static void Log(string logMessage, string logType, string logSource)
        {
            if (!Directory.Exists(@"C:\tmp\logs"))
            {
                Directory.CreateDirectory(@"C:\tmp\logs");
            }
            using (_writer = new StreamWriter(@"C:\tmp\logs\" + DateTime.Now.ToString("yyyyMMdd") + ".log", append: true))
            {
                _writer.WriteLine(string.Format("{0} [{1}] {2} - {3}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), logType, logSource, logMessage));
            }
        }

        /// <summary>
        /// Usage: select the type and use the ToString() method 
        /// to pass the LogType to the Log() method as a string
        /// </summary>
        public enum LogType { ERROR, INFO, WARNING };
    }
}
