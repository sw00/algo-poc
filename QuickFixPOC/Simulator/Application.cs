using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Simulator
{
    public class Application
    {
        public List<string> messages;
        
        public Application(string filename)
        {
            messages = File.ReadLines(filename).ToList();
        }
    }
}
