using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Se74.Net.Test
{
    [TestClass]
    public class S74ElementsTest : BaseSe74Test
    {
        [TestMethod]
        public void TestFormLink()
        {
            Test.Form
                .Open();
            Assert.IsTrue(Test.Form.FormLink.Displayed);
        }
    }
}
