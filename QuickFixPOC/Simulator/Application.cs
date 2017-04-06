using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using QuickFix;

namespace Simulator
{
    public interface ISessionCreator
    {
        Session LookupSession(SessionID sessionId);
    }

    public class SessionCreator : ISessionCreator
    {
        public Session LookupSession(SessionID sessionId)
        {
            return Session.LookupSession(sessionId);
        }
    }

    public class Application : QuickFix.IApplication
    {
        public List<string> messages;
        private Session _session;
        private ISessionCreator _createSession;
        
        public Application(string filename, ISessionCreator sessionCreator)
        {
            messages = File.ReadLines(filename).ToList();
            _createSession = sessionCreator;
        }

        public Application(string filename, Session fakeSession)
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
            _session = _createSession.LookupSession(sessionID);
        }

        public void OnLogon(SessionID sessionID)
        {
            
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
