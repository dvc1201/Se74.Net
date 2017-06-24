using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Se74.Net.Driver;

namespace Se74.Net.Elements
{
    public class SelectTag : Se74Element
    {
        public SelectTag(By by, string name = "", string comment = "") : base(by, name, comment)
        {
        }


        private SelectElement Selector()
        {
            if (!this.Displayed || !this.Enabled)
            {
                this.DriverX.WaitUntil(delegate { return this.Displayed && this.Enabled; });
            }
            SelectElement selector = new SelectElement(this.FindElement());
            return selector;

        }



        public void SelectByValue(string value)
        {
            Selector().SelectByValue(value);
        }

        public void SelectByText(string value)
        {
            Selector().SelectByText(value);
        }

        public string SelectedValue
        {
            get
            {
                return Selector().SelectedOption.GetAttribute("value");
            }
        }

        public string SelectedText
        {
            get
            {
                return Selector().SelectedOption.Text;
            }
        }
    }
}
