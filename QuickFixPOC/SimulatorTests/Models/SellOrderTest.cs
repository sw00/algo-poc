using FixClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimulatorTests.Models
{
    public class SellOrderTest
    {
        [Fact]
        public void Should_Have_Side_Value_Of_Two()
        {
            var sellOrder = new SellOrder();
            Assert.Equal(2, sellOrder.Side);
        }
    }
}
