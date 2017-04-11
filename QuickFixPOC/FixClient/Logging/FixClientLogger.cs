using QuickFix;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixClient.Logging
{

    public interface ILogger
    {
        void LogMessage(Message msg);
    }

    public class FixClientLogger : ILogger
    {
        private readonly FileInfo _logFile;

        public FixClientLogger(string path="c:\\FixLogs\\FixLog.txt")
        {
            _logFile = new FileInfo(path);
            _logFile.Directory.Create();
        }

        public void LogMessage(Message msg)
        {
            string message = msg.ToString();

            try
            {
                string logLine = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")} {message} {Environment.NewLine}";
                File.AppendAllText(_logFile.FullName, logLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
