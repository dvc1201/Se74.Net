using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace GlobalBlue.HomeWork.StepDefinitions
{
    [Binding]
    public sealed class DemoSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        Stack<int> stack = new Stack<int>();
 

        [Given("I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see http://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            stack.Push(number);
        }

        [When("I press add")]
        public void WhenIPressAdd()
        {
            stack.Push(stack.Pop() + stack.Pop());
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(result, stack.Peek());
        }
    }
}
