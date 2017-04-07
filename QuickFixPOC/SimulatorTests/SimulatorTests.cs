using Moq;
using QuickFix;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimulatorTests
{
    public class MockSessionCreator : ISessionCreator
    {
        Mock<Session> _mockSession = new Mock<Session>();


        public Mock<Session> getMockSession()
        {
            return _mockSession;
        }

        public Session LookupSession(SessionID sessionId)
        {
            return _mockSession.Object;
        }
    }


    public class SimulatorTests
    {
        [Fact]
        public void Should_LoadMessagesFromFilePath()
        {
            string path = "Data/03.JSE_Indices_recv_log.txt";
            var app = new Simulator.AcceptorApp(path, new MockSessionCreator());

            Assert.True(app.messages.Count > 0);
        }

    }
}
