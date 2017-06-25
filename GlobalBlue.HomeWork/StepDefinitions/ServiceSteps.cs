using GlobalBlue.HomeWork.PageObjects;
using GlobalBlue.HomeWork.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GlobalBlue.HomeWork.StepDefinitions
{
    [Binding]
    public sealed class ServiceSteps : BaseStep
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        // For storing and retrieving scenario-specific data see http://go.specflow.org/doc-sharingdata 
        // To use the multiline text or the table argument of the scenario,
        // additional string/Table parameters can be defined on the step definition
        // method. 

        int Country;
        CalculatorClient Service => Test.CalculatorService;




        [Given(@"I use (.*) as Jurisdiction")]
        public void GivenIUseAsJurisdiction(int country)
        {
            this.Country = country;
        }

        [When(@"I Call the Calculator Service")]
        public void WhenICallTheCalculatorService(Table table)
        {
            AddPurchases(table);
        }

        [Then(@"no Error is detected")]
        public void ThenNoErrorIsDetected()
        {
        }


        internal void AddPurchases(Table table)
        {
            var purchases = table.CreateSet<GbhwCalculator.PurchaseItem>();
            foreach (var purchase in purchases)
            {
                if (purchase.CalculatedRefund.StartsWith("@INVALID"))
                {
                    var error = Service.CalculateFails(Country, purchase.Amount);
                }
                else if (purchase.CalculatedRefund.StartsWith("@MINIMUM"))
                {
                }
                else
                {
                    var refund = Service.Calculate(Country, purchase.DecAmount);
                    Assert.AreEqual(purchase.DecRefund, refund);
                }
            }
        }


    }
}
