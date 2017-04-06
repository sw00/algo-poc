using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simulator;
using Xunit;

namespace FixTests
{
    public class SimulatorTests
    {
        Application app;

        [TestInitialize]
        public void Setup()
        {
            app = new Application("03.JSE_Indices_recv_log.txt");
        }

        [Fact]
        public void Should_LoadMessagesFromFilePath()
        {
            Assert.IsTrue(app.messages.Count > 0);
        }
    }
}
