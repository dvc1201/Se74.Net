using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Se74.Net.Elements
{
    public class TextInput : Se74Element
    {
        public TextInput(By by, string name = "", string comment = "") : base(by, name, comment)
        {
        }


        public virtual void SetValue(string value)
        {
            DriverX.WaitUntil(() => this.Ready);
            var field = this.FindElement();
            field.Click();
            field.Clear();
            field.SendKeys(value);
            field.SendKeys(Keys.Tab);
        }


        public virtual string GetValue()
        {
            var field = this.FindElement();
            return field.GetAttribute("value");
        }
    }
}
