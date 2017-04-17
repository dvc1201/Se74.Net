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

        [TestMethod]
        public void TestTextInput()
        {
            var form = Test.Form
                .Open();
            form.FirstName.SetValue("FirstName");
            Assert.AreEqual("FirstName", form.FirstName.GetValue());
        }
    }
}
