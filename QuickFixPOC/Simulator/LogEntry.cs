using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickFix;
using QuickFix.DataDictionary;

namespace Simulator
{
    public class LogEntry
    {
        private string logline;

        public LogEntry()
        {
        }

        public LogEntry(string logline)
        {
            this.logline = logline;
            var logLineParts = logline.Split(' ');

            if (logLineParts.Count() != 2)
            {
                throw new FormatException("Invalid Log Line Format: Missing timestamp");
            }
            setTimestamp(logLineParts[0]);
            setMessage(logLineParts[1]);
        }

        public DateTime Timestamp;
        public Message Message;

        private void setTimestamp(string timestamp)
        {
                DateTime date;
                DateTime.TryParse(timestamp, out date);

                Timestamp = date;
        }

        private void setMessage(string message)
        {
            this.Message = new Message(message, false);
        }
    }
}
