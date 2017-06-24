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

        public override void SetValue(string value)
        {
            var field = this.FindReadyElement();
            field.Click();
            field.Clear();
            field.SendKeys(value);
        }

    }
}
