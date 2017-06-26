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
        private IEnumerable<PurchaseItem> Purchases;
        private Se74Element InputRefund;
        private Se74Element TotalPurchase;
        private Se74Element TotalRefund;

        public GbhwCalculator(GbhwContext context) : base(context)
        {
            Country = new SelectTag(By.Name("jurisdictions"));
            Amount = new PurchaseAmount(By.Name("purchase_amount"));
            ResetButton = new Se74Element(By.CssSelector("a.btn-reset"));
            AddButton = new Se74Element(By.CssSelector("a.add-purchase"));
            InvalidInput = new Se74Element(By.XPath("//h4[.='Invalid Input']"));
            MinimumError = new Se74Element(By.XPath("//h4[.='You need to purchase at least']"));
            InputRefund = new Se74Element(By.CssSelector("div.input-row .refund-amount"));
            TotalPurchase = new Se74Element(By.CssSelector("div.total-row .total-purchase-amount"));
            TotalRefund = new Se74Element(By.CssSelector("div.total-row .total-refund-amount"));
        }

        public int NumberOfAddedPurchases
        {
            get
            {
                return Driver.FindElements(By.CssSelector("div.row-purchase-refund-amount")).Count;
            }
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
            Purchases = table.CreateSet<PurchaseItem>();
            foreach (var purchase in Purchases)
            {
                SetAmount(purchase.Amount);
                //Test.Pause(2);
                if (purchase.CalculatedRefund.StartsWith("@INVALID"))
                {
                    Test.DriverX.WaitUntil(() => InvalidInput.Displayed);

                } else if (purchase.CalculatedRefund.StartsWith("@MINIMUM"))
                {
                    Test.DriverX.WaitUntil(() => MinimumError.Displayed);

                }
                else
                {
                    Test.DriverX.WaitUntil(() => InputRefund.FindElement().Text.Replace(",","").Equals(purchase.CalculatedRefund));
                    Test.Pause(1);
                    AddButton.Click();
                }
            }
        }

        public GbhwCalculator Reset()
        {
            ResetButton.Click();
            return this;
        }

        public GbhwCalculator SetAmount(string amount)
        {
            Amount.SetValue(amount);
            return this;
        }


        public bool TotalsAreCalculatedProperly()
        {
            var totalPurchase = decimal.Parse(TotalPurchase.FindElement().Text.Replace(",", ""));
            var totalRefund = decimal.Parse(TotalRefund.FindElement().Text.Replace(",", ""));
            var expectedPurchase = Purchases.Where(e => e.DecRefund != 0.00m).Sum(od => od.DecAmount);
            var expectedRefund = Purchases.Sum(od => od.DecRefund);
            return totalPurchase.Equals(expectedPurchase) && totalRefund.Equals(expectedRefund);
        }

        public bool IsAfterReset()
        {
            return Country.Displayed && Amount.Displayed && NumberOfAddedPurchases==0
                && decimal.Parse(TotalPurchase.FindElement().Text.Replace(",", "")).Equals(0m)
                && decimal.Parse(TotalRefund.FindElement().Text.Replace(",", "")).Equals(0m);
        }


        internal class PurchaseItem
        {
            public string Amount;
            public string CalculatedRefund;

            public decimal DecAmount => ParseDecimal(Amount);
            public decimal DecRefund => ParseDecimal(CalculatedRefund);


            private decimal ParseDecimal(string value)
            {
                try
                {
                    return decimal.Parse(value);
                }
                catch (Exception)
                {
                    return 0.00m;
                }
            }
        }
    }
}
