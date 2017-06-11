using OpenQA.Selenium;
using Se74.Net.Logger;
using Se74.Net.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se74.Net.Context
{
    public class Se74Page<C, P> where C:Se74Context where P:Se74Page<C, P>
    {
        protected C Test { get; private set; }
        public IWebDriver Driver => Test.Driver;
        public Se74Report Report => Test.Report;

        public Se74Page(C context)
        {
            Test = context;
        }

        public P Pause(int seconds=1)
        {
            Test.Pause(seconds);
            return this as P;
        }

        public void Log(string log, params object[] list)
        {
            Report.Log(log, list);
        }


    }
}
