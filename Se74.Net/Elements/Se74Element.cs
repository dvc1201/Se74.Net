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

        public virtual bool Displayed
        {
            get
            {
                try
                {
                    return FindElement().Displayed;
                }
                catch
                {
                    return false;
                }
            }
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
