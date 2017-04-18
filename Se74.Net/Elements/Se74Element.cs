using OpenQA.Selenium;
using Se74.Net.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se74.Net.Elements
{
    public class Se74Element
    {
        protected Se74Driver DriverX => Se74Driver.Current;
        protected IWebDriver Driver => DriverX.Driver;
        public By By { get; protected set; }

        public bool Displayed
        {
            get
            {
                    return SafeBool(() => IsDisplayed());
            }
        }

        public bool Enabled
        {
            get
            {
                return SafeBool(() => IsEnabled());
            }
        }


        public bool Ready
        {
            get
            {
                return SafeBool(() => IsReady());
            }
        }


        protected bool SafeBool(Func<bool> condition)
        {
            try
            {
                return condition.Invoke();
            }
            catch
            {
                return false;
            }
        }

        protected virtual bool IsDisplayed()
        {
            return FindElement().Displayed;
        }

        protected virtual bool IsEnabled()
        {
            return FindElement().Enabled;
        }

        protected virtual bool IsReady()
        {
            var field = this.FindElement();
            return field.Enabled && field.Displayed;
        }


        public Se74Element(By by, string name="", string comment="")
        {
            this.By = by;
        }

        public IWebElement FindElement()
        {
            return Driver.FindElement(this.By);
        }
    }
}
