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

        [TestMethod]
        public void TestCheckBox()
        {
            Test.Log("TestCase level log");
            var form = Test.Form
                .Open();
            form.Maths.Set();
            Assert.IsTrue(form.Maths.Selected);
            form.Maths.Clear();
            Assert.IsFalse(form.Maths.Selected);
        }


        [TestMethod]
        public void TestDropdown()
        {
            Test.Log("TestCase level log");
            var form = Test.Form
                .Open();
            form.Dropdown.SelectByText("Physics");
            Assert.AreEqual("Physics", form.Dropdown.SelectedValue);
            form.Dropdown.SelectByValue("Maths");
            Assert.AreEqual("Maths", form.Dropdown.SelectedText);
        }



    }
}
