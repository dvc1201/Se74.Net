using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Se74.Net.Logger;
using Se74.Net.Report;
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
        public int DefaultTimeOut = 60;
        public Se74Report Report => Se74Report.Current ?? forceReport();

        private Se74Report forceReport()
        {
            Se74Report.New(new ConsoleLog());
            return Se74Report.Current;
        }



        private Se74Driver(IDriverProvider provider)
        {
            Driver = provider.NewDriver();
        }


        private bool SafeCondition(Func<bool> condition)
        {
            try
            {
                return condition.Invoke();
            } catch
            {
                return false;
            }
        }


        private int TimeOut(int timeout=-1)
        {
            return timeout < 1 ? DefaultTimeOut : timeout;
        }

        public void WaitUntil(Func<bool> condition, int timeout=-1)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            wait.Until(delegate { return SafeCondition(condition); });
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
                Current.Driver.Dispose();
            }
        }

    }
}
