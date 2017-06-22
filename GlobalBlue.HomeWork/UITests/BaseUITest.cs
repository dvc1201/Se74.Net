using GlobalBlue.HomeWork.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Se74.Net.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBlue.HomeWork.UITests
{
    public class BaseUITest
    {

        protected GbhwContext Test => GbhwContext.Current;

        [TestInitialize]
        public void InitTest()
        {
            Se74Driver.New(new ChromeProvider());
            GbhwContext.New();
        }

        [TestCleanup]
        public void CleanTest()
        {
            GbhwContext.Release();
            Se74Driver.Release();
        }
    }
}
