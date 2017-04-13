using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se74.Net.Driver
{
    public class Se74Driver
    {
        public static Se74Driver Current { get; private set; }

        public IWebDriver Driver { get; private set; }
        public IDriverProvider Provider { get; private set; }

        private Se74Driver(IDriverProvider provider)
        {
            Driver = provider.NewDriver();
        }

        public static void New(IDriverProvider provider)
        {
            Release();
            Current = new Se74Driver(provider);
            Current.Provider = provider;
        }

        public static void Release()
        {
            if (Current!=null && Current.Driver!=null)
            {
                Current.Driver.Quit();
            }
        }

    }
}
