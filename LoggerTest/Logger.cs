using System;
using System.IO;
namespace LoggerTest
{
    public class Logger : ILogger
    {
        // -----------------------------------------------------
        // Change "LoggerTest" below to your app name or
        // whatever you want to call the folder where the log
        // file is to be stored.
        // -----------------------------------------------------
        // Of course you can change the entire _Logfile path
        // variable to something completely different if you
        // wish. I use the CommonApplicationData location since
        // it is a standard location for app data storage.
        // -----------------------------------------------------
        private string _logfilepath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\LoggerTest\\";
        private string _category = "info";
        public string Category { get; set; }
        // -----------------------------------------------------
        // Category is an optional verb that describes the type
        // of log entry. Examples: "info", "ERROR", etc.
        // Defaults to "info" if not specified.
        // -----------------------------------------------------
        public string Logged { get; set; }
        // -----------------------------------------------------
        // Logged is the date of the log entry (as a string).
        // -----------------------------------------------------
        public string Message { get; set; }
        // -----------------------------------------------------
        // Message is the actual content that is being logged.
        // -----------------------------------------------------
        public string Path { get; set; }
        // -----------------------------------------------------
        // Path is the log file path.
        // -----------------------------------------------------

        public void AppendLog()
        {
            // -------------------------------------------------
            // Ensure the log file directory exists.
            // -------------------------------------------------
            if (!Directory.Exists(_logfilepath)) Directory.CreateDirectory(_logfilepath);
            // -------------------------------------------------
            // Actual log file name includes date information.
            // -------------------------------------------------
            Path = _logfilepath + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".log";
            // -------------------------------------------------
            // Date/time stamp for the log entry.
            // -------------------------------------------------
            Logged = DateTime.Now.ToString();
            // -------------------------------------------------
            // Use "info" as default if no Category was specified.
            // -------------------------------------------------
            string cat = string.IsNullOrEmpty(Category) ? _category : Category;
            // -------------------------------------------------
            // Specific log entry format, prepending the date and category.
            // -------------------------------------------------
            string logEntry = (DateTime.Now.Hour < 10) ? DateTime.Now.ToString() + ":  [" + cat + "] " + Message : DateTime.Now.ToString() + ": [" + cat + "] " + Message;
            // -------------------------------------------------
            // Create a new log file each day if it doesn't exist. Otherwise, append. 
            // -------------------------------------------------
            FileInfo logFile = new FileInfo(Path);
            File.AppendAllText(logFile.FullName, logEntry + Environment.NewLine);
        }
    }
}
