using OpenQA.Selenium;
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

        public Se74Page(C context)
        {
            Test = context;
        }

        public P Pause(int seconds=1)
        {
            Test.Pause(seconds);
            return this as P;
        }


    }
}
