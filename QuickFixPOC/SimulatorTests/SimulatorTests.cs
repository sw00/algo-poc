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
        Mock<Session> _mockSession;

        public Mock<Session> getMockSession()
        {
            return _mockSession;
        }

        public Session LookupSession(SessionID sessionId)
        {
            _mockSession = new Mock<Session>();
          
            return _mockSession.Object;
        }
    }


    public class SimulatorTests
    {
        [Fact]
        public void Should_LoadMessagesFromFilePath()
        {
            string path = "Data/03.JSE_Indices_recv_log.txt";
            var app = new Simulator.Application(path, new MockSessionCreator());

            Assert.True(app.messages.Count > 0);
        }

        [Fact]
        public void Should_SendMessages()
        {
            string path = "Data/03.JSE_Indices_recv_log.txt";
            var mockSessionCreator = new MockSessionCreator();

            var app = new Simulator.Application(path, mockSessionCreator);

            app.OnLogon(new SessionID("", "", ""));

            mockSessionCreator.getMockSession().Verify(s => s.Send(It.IsAny<Message>()), Times.Exactly(1));         


        }
    }
}
