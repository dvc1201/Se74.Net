using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBlue.HomeWork.UITests
{
    [TestClass]
    public class FirstSample : BaseUITest
    {

        [TestMethod]
        public void UseContext()
        {
            Assert.IsNotNull(Test);
            Assert.IsNotNull(Test.Driver);
        }


        [TestMethod]
        public void OpenCalculator()
        {
            Test.Calculator
                .Open()
                .SetCountryCode("AUT")
                .SetAmount("500");
        }
    }
}
