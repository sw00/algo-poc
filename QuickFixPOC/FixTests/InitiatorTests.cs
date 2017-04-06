using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using QuickFix;
using System.Linq;

namespace FixTests
{
    [TestClass]
    public class InitiatorTests
    {


        [TestMethod]
        public void ReadInput()
        {
            var file = File.ReadLines("03.JSE_Indices_recv_log.txt").ToList();
            var line = file.FirstOrDefault();

            var dd = new QuickFix.DataDictionary.DataDictionary();

            var log = line.Split(' ');
            line = log[1];

            var factory = new QuickFix.DefaultMessageFactory();

            var msgType = Message.IdentifyType(line);

            Message msg = factory.Create("", msgType.getValue());
            msg.FromString(line, true, dd, dd, factory);

            Assert.AreEqual("0", msgType.Obj);

        }
    }
}
