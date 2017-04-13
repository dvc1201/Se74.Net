using OpenQA.Selenium;
using Se74.Net.Driver;
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

        public void Pause(int seconds=1)
        {
            Thread.Sleep(seconds * 1000);
        }
    }
}
