using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Se74.Net.Elements
{
    public class CheckBox : Se74Element
    {
        public CheckBox(By by, string name = "", string comment = "") : base(by, name, comment)
        {
        }

        public bool Selected
        {
            get { return SafeBool(() => IsSelected()); }
        }

        private bool IsSelected(IWebElement element=null)
        {
            var field = element ?? this.FindElement();
            return field.Selected;
        }


        public void Clear()
        {
            Set(false);
        }


        public void Set(bool value=true)
        {
            Log("CheckBox Set: {0}", value);
            DriverX.WaitUntil(() => this.Ready);
            var field = FindElement();
            if (!IsSelected(field)==value)
            {
                field.Click();
            }
        }

    }
}
