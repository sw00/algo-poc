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
        public void Should_Convert_BuyOrder_To_NeworderSingle_FixMessage()
        {
            var buyOrder = new BuyOrder { Account = "12345678",
                                          SecurityId = "SampleID4567",
                                          Price = 64500 };

            Message msg = Fix50MessageBuilder.ToFixMessage(buyOrder);

            Assert.Equal("D", msg.Header.GetField(Tags.MsgType));
            Assert.Equal("1", msg.GetField(Tags.Side));
            Assert.Equal("64500", msg.GetField(Tags.Price));
        }

        [Fact]
        public void Should_Convert_SellOrder_To_NewOrderSingle_FixMessage()
        {
            var sellOrder = new SellOrder { Account = "87654321",
                                           SecurityId = "SID4567",
                                           Price = 11300 };

            Message msg = Fix50MessageBuilder.ToFixMessage(sellOrder);

            Assert.Equal("D", msg.Header.GetField(Tags.MsgType));
            Assert.Equal("2", msg.GetField(Tags.Side));
            Assert.Equal("11300", msg.GetField(Tags.Price));
        }
    }
}
