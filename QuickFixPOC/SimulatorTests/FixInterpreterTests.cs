using FixClient;
using FixClient.Models;
using QuickFix;
using QuickFix.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimulatorTests
{
    public class FixInterpreterTests
    {

        [Fact]
        public void Should_Convert_SellOrder_To_NewOrderSingle_FixMessage()
        {
            var fixOrder = new FixOrder { Account = "87654321",
                                          Side = OrderSide.Sell,
                                           SecurityId = "SID4567",
                                           Price = 11300 };

            Message msg = Fix50MessageBuilder.ToFixMessage(fixOrder);

            Assert.Equal("D", msg.Header.GetField(Tags.MsgType));
            Assert.Equal("2", msg.GetField(Tags.Side));
            Assert.Equal("11300", msg.GetField(Tags.Price));
        }
    }
}
