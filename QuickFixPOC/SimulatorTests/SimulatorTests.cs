using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimulatorTests
{
    public class SimulatorTests
    {
        [Fact]
        public void Should_LoadMessagesFromFilePath()
        {
            string path = "Data/03.JSE_Indices_recv_log.txt";
            var app = new Application(path);

            Assert.True(app.messages.Count > 0);
        }
    }
}
