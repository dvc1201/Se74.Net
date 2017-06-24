using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBlue.HomeWork.Context;
using Se74.Net.Elements;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using GlobalBlue.HomeWork.WebObjects;
using System.Threading;

namespace GlobalBlue.HomeWork.PageObjects
{
    public class GbhwCalculator : BaseGbhwPage<GbhwCalculator>
    {

        private SelectTag Country;
        private PurchaseAmount Amount;
        private Se74Element ResetButton;
        private Se74Element AddButton;
        private Se74Element InvalidInput;
        private Se74Element MinimumError;

        public GbhwCalculator(GbhwContext context) : base(context)
        {
            Country = new SelectTag(By.Name("jurisdictions"));
            Amount = new PurchaseAmount(By.Name("purchase_amount"));
            ResetButton = new Se74Element(By.CssSelector("a.btn-reset"));
            AddButton = new Se74Element(By.CssSelector("a.add-purchase"));
            InvalidInput = new Se74Element(By.XPath("//h4[.='Invalid Input']"));
            MinimumError = new Se74Element(By.XPath("//h4[.='You need to purchase at least']"));
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

        internal void AddPurchases(Table table)
        {
            var purchases = table.CreateSet<PurchaseItem>();
            foreach (var purchase in purchases)
            {
                SetAmount(purchase.Amount);
                Test.Pause(2);
                if (purchase.CalculatedRefund.StartsWith("@INVALID"))
                {
                    Test.DriverX.WaitUntil(() => InvalidInput.Displayed);

                } else if (purchase.CalculatedRefund.StartsWith("@MINIMUM"))
                {
                    Test.DriverX.WaitUntil(() => MinimumError.Displayed);

                }
                else
                {
                    AddButton.Click();
                }
            }
        }

        public GbhwCalculator SetAmount(string amount)
        {
            Amount.SetValue(amount);
            return this;
        }



        internal class PurchaseItem
        {
            public string Amount;
            public string CalculatedRefund;
        }
    }
}
