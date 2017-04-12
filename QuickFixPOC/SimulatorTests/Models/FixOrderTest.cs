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
    public class FixOrderFixture : IDisposable
    {
        public FixOrder DefaultFixOrder = new FixOrder();
        public void Dispose()
        {
            //nothing
        }
    }

    public class FixOrderTest : IClassFixture<FixOrderFixture>
    {
        private readonly FixOrder _defaultFixOrder;

        public FixOrderTest(FixOrderFixture fixture)
        {
            _defaultFixOrder = fixture.DefaultFixOrder;
        }

        [Fact]
        public void Should_Have_Side_Value_Of_One()
        {
            var buyOrder = new FixOrder {
                Side = OrderSide.Buy
            };
            Assert.Equal(1, (int)buyOrder.Side);
        }

        [Fact]
        public void Should_Have_Side_Value_Of_Two()
        {
            var sellOrder = new FixOrder
            {
                Side = OrderSide.Sell
            };
            Assert.Equal(2, (int)sellOrder.Side);
        }

        [Fact]
        public void Should_Have_OrderBook_Value_Of_One()
        {
            Assert.Equal(1, _defaultFixOrder.OrderBook);
        }

        [Fact]
        public void Should_Have_OrderType_Value_Of_D()
        {
            Assert.Equal('D', _defaultFixOrder.MsgType);
        }

        [Fact]
        public void Should_Have_OrderType_Value_Of_Limit()
        {
            Assert.Equal(OrderType.Limit, _defaultFixOrder.OrderType);
        }

        [Fact]
        public void Should_Have_DisplayQuantity_Value_Of_Zero()
        {
            Assert.Equal(0, _defaultFixOrder.DisplayQuantity);
        }

        [Fact]
        public void Should_Have_OrderCapacity_Value_Of_A()
        {
            Assert.Equal('A', _defaultFixOrder.OrderCapacity);
        }

        [Fact]
        public void Should_Have_SecurityIdSource_Value_Of_8()
        {
            Assert.Equal(8, _defaultFixOrder.SecurityIdSource);
        }

        [Fact]
        public void Should_Have_TransactionTime_Default_To_Now()
        {
            var before = DateTime.Now;
            Thread.Sleep(1);
            var fixOrder = new FixOrder();
            Thread.Sleep(1);
            var after = DateTime.Now;

            Assert.True(before < fixOrder.TransactionTime && fixOrder.TransactionTime < after);
        }

        [Fact]
        public void Should_Throw_Exception_For_Invalid_Account_Format()
        {
            Assert.Throws<FormatException>(delegate
            {
                var fixOrder = new FixOrder
                {
                    Account = "123456789"
                };
            });
        }

        [Fact]
        public void Can_Assign_Valid_Account_Number()
        {
            var fixOrder = new FixOrder
            {
                Account = "12345678"
            };

            Assert.Equal("12345678", fixOrder.Account);
        }

        [Fact]
        public void Should_Throw_Format_Exception_For_Invalid_SecurityID()
        {
            Assert.Throws<FormatException>(delegate
            {
                var fixOrder = new FixOrder
                {
                    SecurityId = "12jknbjhg&er"
                };
            });
        }

        [Fact]
        public void Can_Assign_Valid_SecurityID()
        {
            var fixOrder = new FixOrder
            {
                SecurityId = "123Four5678"
            };

            Assert.Equal("123Four5678", fixOrder.SecurityId);
        }
    }
}
