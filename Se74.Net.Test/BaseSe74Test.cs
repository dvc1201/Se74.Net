using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Se74.Net.Test.Context;
using Se74.Net.Driver;
using OpenQA.Selenium;

namespace Se74.Net.Test
{
    [TestClass]
    public class BaseSe74Test
    {
        protected MySe74Context Test => MySe74Context.Current;
        protected IWebDriver Driver => Test.Driver;

        [TestInitialize]
        public void TestInit()
        {
            Se74Driver.New(new ChromeProvider());
            MySe74Context.New();
        }

        [TestCleanup]
        public void TestClean()
        {
            MySe74Context.Release();
            Se74Driver.Release();
        }

    }
}
