using System;
using System.IO;

namespace Util
{
    static class Logger
    {
        static string _logfilepath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\your_app_name_here\\";
        public static void AppendLog(string entry)
        {
            try
            {
                if (!Directory.Exists(_logfilepath)) Directory.CreateDirectory(_logfilepath);
                string CurrentLog = _logfilepath + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".log";
                FileInfo logFile = new FileInfo(CurrentLog);
                string logEntry = (DateTime.Now.Hour < 10) ? DateTime.Now.ToString() + ":  " + entry : DateTime.Now.ToString() + ": " + entry;
                File.AppendAllText(logFile.FullName, logEntry + Environment.NewLine);
            }
            catch
            {
                // Ignore or take some other desired action here.
            }
        }
    }
}
