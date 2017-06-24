using Se74.Net.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace GlobalBlue.HomeWork.WebObjects
{
    class PurchaseAmount : TextInput
    {
        public PurchaseAmount(By by, string name = "", string comment = "") : base(by, name, comment)
        {
        }

        public virtual void SetValue(string value)
        {
            DriverX.WaitUntil(() => this.Ready);
            var field = this.FindElement();
            field.Click();
            field.Clear();
            field.SendKeys(value);
        }

    }
}
