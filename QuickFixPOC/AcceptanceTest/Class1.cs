using FixClient;
using QuickFix;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AcceptanceTest
{
    public class SimulatorTest
    {
        private ThreadedSocketAcceptor _server;
        private ThreadedSocketAcceptor _client;

        public SimulatorTest()
        {
            _server = createAppFrom(@"Config\acceptor.cfg");
            _client = createAppFrom(@"Config\initiator.cfg");
        }

        private ThreadedSocketAcceptor createAppFrom(string configFileName)
        {
            var app = new InitiatorApp();
            var settings = new SessionSettings(configFileName);
            var storeFactory = new FileStoreFactory(settings);
            var logFactory = new FileLogFactory(settings);
            return new ThreadedSocketAcceptor(app, storeFactory, settings, logFactory);
        }

       // [Fact]
        public void Should_Work()
        {
            _server.Start();
            _client.Start();
            Thread.Sleep(10000);
            _server.Stop();
            _client.Stop();
        }
    }
}
