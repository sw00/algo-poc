using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using QuickFix;
using System.Threading;

namespace Simulator
{
    public class AcceptorApp : QuickFix.IApplication
    {
        public List<string> messages;
        private Session _session;
        
        public AcceptorApp(string filename)
        {
            messages = File.ReadLines(filename).ToList();
        }

        public AcceptorApp(string filename, Session fakeSession)
        {
            messages = File.ReadLines(filename).ToList();
        }

        public void FromAdmin(Message message, SessionID sessionID)
        {
            throw new NotImplementedException();
        }

        public void FromApp(Message message, SessionID sessionID)
        {
            throw new NotImplementedException();
        }

        public void OnCreate(SessionID sessionID)
        {
            _session = Session.LookupSession(sessionID);
        }

        public void OnLogon(SessionID sessionID)
        {
     
            foreach (var message in messages)
            {
                var logEntry = new LogEntry(message);
                _session.Send(logEntry.Message);
                Thread.Sleep(5000);
            }
        }

        public void OnLogout(SessionID sessionID)
        {
            throw new NotImplementedException();
        }

        public void ToAdmin(Message message, SessionID sessionID)
        {
            throw new NotImplementedException();
        }

        public void ToApp(Message message, SessionID sessionId)
        {
            throw new NotImplementedException();
        }
    }
}
