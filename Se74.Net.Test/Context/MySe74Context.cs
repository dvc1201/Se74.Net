using OpenQA.Selenium;
using Se74.Net.Context;
using Se74.Net.Driver;
using Se74.Net.Test.Pages;
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


        public WeatherHome Weather { get; private set; }



        private MySe74Context()
        {
            Weather = new WeatherHome(this);
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
