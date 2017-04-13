using OpenQA.Selenium;
using Se74.Net.Context;
using Se74.Net.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se74.Net.Test.Context
{
    public class MySe74Context : Se74Context
    {

        public static MySe74Context Current { get; private set; }

        public IWebDriver Driver => Se74Driver.Current.Driver;


        private MySe74Context()
        {

        }

        public static void New()
        {
            Release();
            Current = new MySe74Context();
        }


        public static void Release()
        {
            Current = null;
        }


    }
}
