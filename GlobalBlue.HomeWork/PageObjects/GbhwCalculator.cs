using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBlue.HomeWork.Context;
using Se74.Net.Elements;
using OpenQA.Selenium;

namespace GlobalBlue.HomeWork.PageObjects
{
    public class GbhwCalculator : BaseGbhwPage<GbhwCalculator>
    {

        private SelectTag Country;
        private TextInput Amount;

        public GbhwCalculator(GbhwContext context) : base(context)
        {
            Country = new SelectTag(By.Name("jurisdictions"));
            Amount = new TextInput(By.Name("purchase_amount"));
        }

        public GbhwCalculator Open()
        {
            this.Driver.Navigate().GoToUrl(Test.Config.CalculatorUrl);
            return this;
        }


        public GbhwCalculator SetCountryCode(string code)
        {
            Country.SelectByValue(code);
            return this;
        }


        public GbhwCalculator SetAmount(string amount)
        {
            Amount.SetValue(amount);
            return this;
        }
    }
}
