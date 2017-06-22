using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBlue.HomeWork.Context
{
    public class GbhwConfig
    {

        public Uri CalculatorUrl { get; private set; }


        public GbhwConfig()
        {
            CalculatorUrl = new Uri("http://www.globalblue.com/tax-free-shopping/refund-calculator/");
        }
    }
}
