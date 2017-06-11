using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se74.Net.Logger
{
    public class ConsoleLog : ISe74Logger
    {
        public void Log(string log, params object[] list)
        {
            System.Console.WriteLine(log, list);
        }
    }
}
