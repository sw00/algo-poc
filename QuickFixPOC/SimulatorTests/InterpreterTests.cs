using QuickFix;
using QuickFix.Fields;
using Simulator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimulatorTests
{
    public class InterpreterTests
    {
        [Fact]
        public void Should_StripLogTimestampFromMessageLine()
        {
            var logString = "20111124-09:51:32.830 8=FIXT.1.19=12935=X52=20111124-07:52:41.1981180=JSEFTSEP1181=10579268=1279=055=J210269=3270=47877.45451=-47.18273=07:53:45.00083=21610=146";
            var logEntry = new LogEntry(logString);

            DateTime date;
            DateTime.TryParse("20111124-09:51:32.830", out date);
            Assert.Equal(date, logEntry.Timestamp);
        }

        [Fact]
        public void Should_Throw_FormatException()
        {
            var logString = "20111124-09:51:32.8308=FIXT.1.19=12935=X52=20111124-07:52:4";

            Assert.Throws<FormatException>(delegate
            {
                var logEntry = new LogEntry(logString);
            });
        }

        [Fact]
        public void Should_Extract_A_Message()
        {
            string logString = File.ReadLines("Data/SingleFixLogLine.txt").ToArray()[1];
            var logEntry = new LogEntry(logString);

            var message = logEntry.Message;

            Assert.Equal("120", message.Header.GetField(Tags.BodyLength));
            Assert.Equal("180", message.Trailer.GetField(Tags.CheckSum));
        }

    }
}
