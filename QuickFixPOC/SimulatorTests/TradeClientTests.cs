using FixClient;
using FixClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimulatorTests
{
    public class TradeClientTests
    {
        [Fact]
        public void Should_Successfully_Send_BuyOrder()
        {
            var tradeClient = new TradeClient();
            var buyOrder = new BuyOrder();

            bool result = tradeClient.Send(buyOrder);

            Assert.True(result);
        }

        [Fact]
        public void Should_Successfully_Send_SellOrder()
        {
            var tradeClient = new TradeClient();
            var sellOrder = new SellOrder();

            bool result = tradeClient.Send(sellOrder);

            Assert.True(result);
        }
    }
}
