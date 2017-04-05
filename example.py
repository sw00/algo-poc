import quickfix
import sys

class Application(quickfix.Application):
        def onCreate(self, sessionID): return
        def onLogon(self, sessionID): return
        def onLogout(self, sessionID): return
        def toAdmin(self, message, sessionID): return
        def toApp(self, message, sessionID): return
        def fromAdmin(self, message, sessionID): return
        def fromApp(self, message, sessionID): return

if len(sys.argv) < 2: 
	exit(1)
else:
	fileName = sys.argv[1]

try:
        settings = quickfix.SessionSettings(fileName)
        application = Application()
        storeFactory = quickfix.FileStoreFactory(settings)
        logFactory = quickfix.FileLogFactory(settings)
        acceptor = quickfix.SocketInitiator(application, storeFactory, settings, logFactory)
        acceptor.start()
        # while condition == true: do something
        acceptor.stop()
except quickfix.ConfigError, e:
        print e
