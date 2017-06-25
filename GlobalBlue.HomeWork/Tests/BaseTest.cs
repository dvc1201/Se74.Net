using GlobalBlue.HomeWork.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBlue.HomeWork.Tests
{
    public class BaseTest
    {
        protected GbhwContext Test => GbhwContext.Current;

        [TestInitialize]
        public void InitTest()
        {
            GbhwContext.New();
        }

        [TestCleanup]
        public void CleanTest()
        {
            GbhwContext.Release();
        }
    }
}
