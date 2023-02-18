using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerTest
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            logger.Message = "This is a test of the Logger class.";
            // -------------------------------------------------
            // Category is optional
            // -------------------------------------------------
            //logger.Category = "test";
            logger.AppendLog();
        }
    }
}
