using FixClient.Contracts;
using FixClient.Models;
using QuickFix;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixClient
{
    public class TradeClient : ITradeClient
    {
        public bool Send(BuyOrder order)
        {
            var msg = FixInterpreter.ToFixMessage(order);
            return LogMessage(msg);
        }

        public bool Send(SellOrder order)
        {
            var msg = FixInterpreter.ToFixMessage(order);
            return LogMessage(msg);
        }

        private bool LogMessage(Message msg)
        {
            string message = msg.ToString();
            string path = "c:\\FixLogs\\FixLog.txt";

            try
            {
                string logLine = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")} {message} {Environment.NewLine}";
                FileInfo file = new FileInfo(path);
                file.Directory.Create(); 
                File.AppendAllText(file.FullName, logLine);

            }catch (Exception ex)
            {
                return false; 
            }
            return true;
        }
    }
}
