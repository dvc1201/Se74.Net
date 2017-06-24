using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace GlobalBlue.HomeWork.StepDefinitions
{
    [Binding]
    public sealed class CalculatorSteps : BaseStep
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        // For storing and retrieving scenario-specific data see http://go.specflow.org/doc-sharingdata 

        [Given(@"I Open the Calculator")]
        public void GivenIOpenTheCalculator()
        {
            Test.Calculator.Open();
        }

        [Given(@"I select '(.*)' as country")]
        public void GivenISelectAsCountry(string country)
        {
            Test.Calculator.SetCountryCode(country);
        }

        [When(@"I Enter my Purchases")]
        public void WhenIEnterMyPurchases(Table table)
        {
            Test.Calculator.AddPurchases(table);
        }

        [Then(@"I should see that (.*) Purchases are displayed")]
        public void ThenIShouldSeeThatPurchasesAreAdded(int p0)
        {
        }

        [Then(@"I should see proper Calculated and Total values")]
        public void ThenIShouldSeeProperCalculatedAndTotalValues()
        {
        }

    }
}
