using FixClient.Contracts;
using FixClient.Logging;
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
        private ILogger _logger;

        public TradeClient(ILogger logger)
        {
            _logger = logger;
        }
        
        public bool Send(FixOrder order)
        {
            var msg = Fix50MessageBuilder.ToFixMessage(order);
            _logger.LogMessage(msg);
            //TODO: implement actual Session.send(msg);
            return true;
        }

    }
}
