using OpenQA.Selenium;
using Se74.Net.Driver;
using Se74.Net.Report;
using Se74.Net.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Se74.Net.Context
{
    public class Se74Context
    {
        public Se74Driver DriverX => Se74Driver.Current;
        public IWebDriver Driver => DriverX.Driver;
        public Se74Report Report => Se74Report.Current ?? forceReport();

        private Se74Report forceReport()
        {
            Se74Report.New(new ConsoleLog());
            return Se74Report.Current;
        }

        public void Pause(int seconds=1)
        {
            Thread.Sleep(seconds * 1000);
        }

        public void Log(string log, params object[] list)
        {
            Report.Log(log, list);
        }

    }
}
