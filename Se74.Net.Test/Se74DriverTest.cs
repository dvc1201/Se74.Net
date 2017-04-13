using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Se74.Net.Test.Context;
using OpenQA.Selenium;

namespace Se74.Net.Test
{
    [TestClass]
    public class Se74DriverTest : BaseSe74Test
    {
        [TestMethod]
        public void ContextIsReady()
        {
            Assert.IsNotNull(Test);
            Assert.IsTrue(Test is MySe74Context);
            Assert.IsNotNull(Driver);
            Assert.IsTrue(Driver is IWebDriver);
        }
    }
}
