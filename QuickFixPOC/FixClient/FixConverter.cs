using FixClient.Models;
using QuickFix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixClient
{
    public static class FixConverter
    {
        public static string ToFixMessage(FixOrder order)
        {
            var msg = $"{DateTime.Now} Order Type {order.OrderType}, Side {order.Side} ";

            return msg;
        }
    }
}
