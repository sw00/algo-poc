using FixClient.Models;
using QuickFix;
using QuickFix.DataDictionary;
using QuickFix.Fields;
using QuickFix.FIX50;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixClient
{
    public static class Fix50MessageBuilder
    {
        public static QuickFix.Message ToFixMessage(FixOrder order)
        {
            var dd = new DataDictionary();
            var clOrdId = new ClOrdID(Guid.NewGuid().ToString());
            int ordTypeId = (int)order.OrderType;

            var map = dd.GetMapForMessage(order.MsgType.ToString());

            var orderMsg = new NewOrderSingle(
                clOrdId,
                new Side(char.Parse(order.Side.ToString())),
                new TransactTime(DateTime.Now),
                new OrdType('2') //TODO: fix this
                );

            orderMsg.Set(new HandlInst('1'));
            orderMsg.Set(new OrderQty(order.OrderQuantity));
            orderMsg.Set(new TimeInForce('1')); //Day
            orderMsg.Set(new Price(order.Price));
            
           
            return orderMsg;
        }
        
    }
}
