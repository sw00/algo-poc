﻿using FixClient;
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
            var buyOrder = new BuyOrder { Account = "12345678",
                                          SecurityId = "SampleID4567",
                                          Price = 64500 };

            bool result = tradeClient.Send(buyOrder);

            Assert.True(result);
        }

        [Fact]
        public void Should_Successfully_Send_SellOrder()
        {
            var tradeClient = new TradeClient();

            var sellOrder = new SellOrder { Account = "87654321",
                                            SecurityId = "SID4567",
                                            Price = 11300 };

            bool result = tradeClient.Send(sellOrder);

            Assert.True(result);
        }
    }
}
