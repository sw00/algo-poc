using FixClient.Contracts;
using FixClient.Models;
using QuickFix;
using System;
using System.Collections.Generic;
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
            return true;
        }
    }
}
