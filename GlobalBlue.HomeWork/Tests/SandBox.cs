using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlobalBlue.HomeWork.Services;

namespace GlobalBlue.HomeWork.Tests
{
    [TestClass]
    public class SandBox : BaseTest
    {
        [TestMethod]
        public void TestCalculator()
        {
            var refund = Test.CalculatorService.Calculate(40, 1200m);
        }
    }
}
