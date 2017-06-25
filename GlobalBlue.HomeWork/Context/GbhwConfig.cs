using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBlue.HomeWork.Context
{
    public class GbhwConfig
    {
        public string GbHost { get; private set; }
        public Uri CalculatorUrl { get; private set; }


        public GbhwConfig()
        {
            GbHost = "http://www.globalblue.com";
            CalculatorUrl = new Uri($"{GbHost}/tax-free-shopping/refund-calculator/");
        }
    }
}
