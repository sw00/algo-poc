using FixClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SimulatorTests
{
    public class BuyOrderFixture : IDisposable
    {
        public BuyOrder DefaultBuyOrder = new BuyOrder();
        public void Dispose()
        {
            //nothing
        }
    }

    public class BuyOrderTest : IClassFixture<BuyOrderFixture>
    {
        private readonly BuyOrder _defaultBuyOrder;

        public BuyOrderTest(BuyOrderFixture fixture)
        {
            _defaultBuyOrder = fixture.DefaultBuyOrder;
        }

        [Fact]
        public void Should_Have_Side_Value_Of_One()
        {
            Assert.Equal(1, _defaultBuyOrder.Side);
        }
        
        [Fact]
        public void Should_Have_OrderBook_Value_Of_One()
        {
            Assert.Equal(1, _defaultBuyOrder.OrderBook);
        }

        [Fact]
        public void Should_Have_OrderType_Value_Of_D()
        {
            Assert.Equal('D', _defaultBuyOrder.MsgType);
        }

        [Fact]
        public void Should_Have_OrderType_Value_Of_Limit()
        {
            Assert.Equal(OrderType.Limit, _defaultBuyOrder.OrderType);
        }

        [Fact]
        public void Should_Have_DisplayQuantity_Value_Of_Zero()
        {
            Assert.Equal(0, _defaultBuyOrder.DisplayQuantity);
        }

        [Fact]
        public void Should_Have_OrderCapacity_Value_Of_A()
        {
            Assert.Equal('A', _defaultBuyOrder.OrderCapacity);
        }

        [Fact]
        public void Should_Have_SecurityIdSource_Value_Of_8()
        {
            Assert.Equal(8, _defaultBuyOrder.SecurityIdSource);
        }

        [Fact]
        public void Should_Have_TransactionTime_Default_To_Now()
        {
            var before = DateTime.Now;
            Thread.Sleep(1);
            var buyOrder = new BuyOrder();
            Thread.Sleep(1);
            var after = DateTime.Now;

            Assert.True(before < buyOrder.TransactionTime && buyOrder.TransactionTime < after);
        }

        [Fact]
        public void Should_Throw_Exception_For_Invalid_Account_Format()
        {
            Assert.Throws<FormatException>(delegate
            {
                var buyOrder = new BuyOrder
                {
                    Account = "123456789"
                };
            });
        }

        [Fact]
        public void Can_Assign_Valid_Account_Number()
        {
            var buyOrder = new BuyOrder
            {
                Account = "12345678"
            };

            Assert.Equal("12345678", buyOrder.Account);
        }

        [Fact]
        public void Should_Throw_Format_Exception_For_Invalid_SecurityID()
        {
            Assert.Throws<FormatException>(delegate
            {
                var buyOrder = new BuyOrder
                {
                    SecurityId = "12jknbjhg&er"
                };
            });
        }

        [Fact]
        public void Can_Assign_Valid_SecurityID()
        {
            var buyOrder = new BuyOrder
            {
                SecurityId = "123Four5678"
            };

            Assert.Equal("123Four5678", buyOrder.SecurityId);
        }
    }
}
